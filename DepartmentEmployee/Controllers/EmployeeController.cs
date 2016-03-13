
using DepartmentEmployee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DepartmentEmployee.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IDepartmentDataSource _db;

        public EmployeeController(IDepartmentDataSource db)
        {
            _db = db;

        }

        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Employee/Create
        public ActionResult Create(int departmentId)
        {
            CreateEmployeeViewModel vm = new CreateEmployeeViewModel();
            vm.DepartmentID = departmentId;

            return View(vm);
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(CreateEmployeeViewModel createEmployeeViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var department = _db.Departments.Single(d => d.Id == createEmployeeViewModel.DepartmentID);
                    var employee = new Employee();
                    employee.Name = createEmployeeViewModel.Name;
                    employee.HireDate = createEmployeeViewModel.HireDate;

                    department.Employees.Add(employee);
                    _db.Save();

                    return RedirectToAction("Details", "Department", new { id = createEmployeeViewModel.DepartmentID });
                }
                else
                {
                    return View(createEmployeeViewModel);
 
                }
            }
            catch
            {
                return View(createEmployeeViewModel);
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
