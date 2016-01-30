using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityCourseAndResultManagement.Models
{
    public class AllocateClassRoom
    {
        [Required(ErrorMessage = "Please select a Department NUmber")]
        [DisplayName("Department")]
        public int DepartmentId { get; set; }
        [DisplayName("Course")]
        [Required(ErrorMessage = "Please select a Course")]
        public int CourseId { get; set; }
        [DisplayName("Room")]
        [Required(ErrorMessage = "Please select a Room")]
        public int RoomId { get; set; }
        [Required(ErrorMessage = "Please select a Day")]
        public string Day { get; set; }
         [Required(ErrorMessage = "Please select a start time")]
        [DisplayName("From")]
        public DateTime TimeStart { get; set; }
         [Required(ErrorMessage = "Please select a end time")]
        [DisplayName("To")]
        public DateTime TimeEnd { get; set; }
    }
}