using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DepartmentEmployee.Models
{
    public class CreateEmployeeViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int DepartmentID { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        public DateTime? HireDate { get; set; }
    }
}