using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace UniversityCourseAndResultManagement.Models
{
    public class AllocateClassRoom
    {
        [DisplayName("Department")]
        public int DepartmentId { get; set; }
        [DisplayName("Course")]
        public int CourseId { get; set; }
        [DisplayName("Room")]
        public int RoomId { get; set; }
        public string Day { get; set; }
        [DisplayName("From")]
        public DateTime TimeStart { get; set; }
        [DisplayName("To")]
        public DateTime TimeEnd { get; set; }
    }
}