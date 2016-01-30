using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityCourseAndResultManagement.Models
{
    public class CourseSchedule
    {
        public int Id { get; set; }
         [Required(ErrorMessage = "Select  Department")]
        
        [DisplayName("Department")]
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int CourseId { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public int RoomId { get; set; }
        public string RoomNo { get; set; }
        public string Day { get; set; }
        public string ScheduleInfo { get; set; }
        //public string TimeEnd { get; set; }
        //public DateTime? TimeStart { get; set; }
        //public DateTime? TimeEnd { get; set; }
    }
}