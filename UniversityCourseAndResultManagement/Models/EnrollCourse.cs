using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityCourseAndResultManagement.Models
{
    public class EnrollCourse
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please select a Registration NUmber")]
        public string RegNo { get; set; }
        public DateTime Date { get; set; }
        public int CourseId { get; set; }
    }
}