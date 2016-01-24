using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityCourseAndResultManagement.Models
{
    public class StudentView
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Provide Name")]
        public string Name { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string RegNo { get; set; }

        public DateTime Date { get; set; }

        public string Address { get; set; }

        public string DepartmentName { get; set; }
    }
}