using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityCourseAndResultManagement.Models
{
    public class EnrollCourse
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "*Please select a Registration NUmber")]
        [DisplayName("Student Reg. No.")]
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "*Please select a Registration NUmber")]
        public string RegNo { get; set; }
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "*Please select a Course")]
        [DisplayName("Select Course ")]
        public int CourseId { get; set; }
    }
}