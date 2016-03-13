
using DepartmentEmployee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DepartmentEmployee.Controllers
{

    public class IsMobileDevice : ActionMethodSelectorAttribute
    {
        public override bool IsValidForRequest(ControllerContext controllerContext, System.Reflection.MethodInfo methodInfo)
        {
            return controllerContext.HttpContext.Request.Browser.IsMobileDevice;
        }
    }
    public class DepartmentController : Controller
    {
        private readonly IDepartmentDataSource _db;

        public DepartmentController(IDepartmentDataSource db)
        {

            _db = db;

        }
        
        
        public ActionResult Index(string searchTerm)
        {
            var departments = _db.Departments.Where(s => searchTerm == null || s.Name.StartsWith(searchTerm)).ToList();

            if (Request.IsAjaxRequest())
            {
                ViewBag.msg = "We found " + departments.Count.ToString() + " results...";
                return PartialView("_Index", departments);
            }
            else
            {
                return View(departments);
            }
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var department = _db.Departments.Single(d => d.Id == id);

            return View(department);
        }

        [HttpGet]
        public ActionResult Create()
        {
            Department department = new Department();

            return View(department);
        }

        [HttpPost]
        public ActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                _db.AddDepartment(department);
                _db.Save();
                return RedirectToAction("Index");
            }
            else
            {

                return View(department);
            }


        }
    }
}