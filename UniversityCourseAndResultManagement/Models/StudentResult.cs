using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityCourseAndResultManagement.Models
{
    public class StudentResult
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "*Please select a Student Registration Number ")]
        [DisplayName("Student Reg. No.")]
        public string RegNo { get; set; }
        [DisplayName("Select Course")]
        [Required(ErrorMessage = "*Please select a Course")]
        public int CourseId { get; set; }
        [Required(ErrorMessage = "*Please select a Grade")]
        public string Grade { get; set; }
    }
}