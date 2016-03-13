namespace DepartmentEmployee.Migrations
{

    using DepartmentEmployee.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DepartmentEmployee.Models.DepartmentDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DepartmentEmployee.Models.DepartmentDb context)
        {
            context.Departments.AddOrUpdate(new Department { Name = "IT",  Employees = new List<Employee> { new Employee { Name = "Pushpak", HireDate = new DateTime(1988, 07, 21) }, new Employee { Name = "Nirav", HireDate = new DateTime(2006, 07, 21) } } });
            context.Departments.AddOrUpdate(new Department { Name = "Finance", Employees = new List<Employee> { new Employee { Name = "Chirag", HireDate = new DateTime(1988, 07, 21) }, new Employee { Name = "Shishir", HireDate = new DateTime(2006, 07, 21) } } });

            context.Departments.AddOrUpdate(new Department { Name = "Accounting", Employees = new List<Employee> { new Employee { Name = "Sneha", HireDate = new DateTime(1988, 07, 21) }, new Employee { Name = "Jalpa", HireDate = new DateTime(2006, 07, 21) } } });

            for (int i = 0; i < 1000; i++)
            {
                context.Departments.AddOrUpdate(new Department { Name = i.ToString() });
            }
                context.SaveChanges();
        }
    }
}
