using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.EnterpriseServices;
using System.Linq;
using System.Web;

namespace UniversityCourseAndResultManagement.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Provide Code")]
        [StringLength(10, MinimumLength =5,ErrorMessage = "Code must be atleast five(5) charecters long")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Provide Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Provide Credit")]
        [Range(0.5,5,ErrorMessage = "Credit Can not be less than 0.5 and more than 5")]
        public decimal Credit { get; set; }
        [Required(ErrorMessage = "Provide some description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Select  Department")]
        [DisplayName("Department")]
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "Select Semester")]
        [DisplayName("Semester")]
        public int SemesterId { get; set; }
        //change by sayed
        public int TecaherId { get; set; }
        public string SemesterName { get; set; }
        public string TeacherName { get; set; }
        public string DepartmentName { get; set; }

        //change by sayed
    }
}