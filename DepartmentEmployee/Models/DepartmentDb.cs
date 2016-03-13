
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;

namespace DepartmentEmployee.Models
{
    public interface IDepartmentDataSource
    {
        IQueryable<Employee> Employees { get; }

        IQueryable<Department> Departments { get; }

        void AddDepartment(Department department);


        void AddEmployee(Employee employee);

        void Save();

    }


    public class Employee
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual DateTime? HireDate { get; set; }
    } 

    public class Department
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

       
        public virtual ICollection<Employee> Employees { get; set; }
    }

   
    public  class DepartmentDb : DbContext, IDepartmentDataSource
    {
        public DepartmentDb()
            : base("DefaultConnection")
        {

        }
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Department> Departments { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
        }

     
       



        IQueryable<Employee> IDepartmentDataSource.Employees
        {
            get { return Employees; }
        }

        IQueryable<Department> IDepartmentDataSource.Departments
        {
            get { return Departments; }
        }

        public void AddDepartment(Department department)
        {
            this.Departments.Add(department);


        }
        public void AddEmployee(Employee employee)
        {
            this.Employees.Add(employee);

        }

        public void Save()
        {
            this.SaveChanges();
        }
    }
}