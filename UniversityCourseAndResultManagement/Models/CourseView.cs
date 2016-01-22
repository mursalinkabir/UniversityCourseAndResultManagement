using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityCourseAndResultManagement.Models
{
    public class CourseView
    {
        public string Code { get; set; }
        
        public string Name { get; set; }
        
        public int DepartmentId { get; set; }
       
        public int SemesterId { get; set; }

        public int TecaherId { get; set; }
        public string SemesterName { get; set; }
        public string TeacherName { get; set; }
        public string DepartmentName { get; set; }
       
    }
}