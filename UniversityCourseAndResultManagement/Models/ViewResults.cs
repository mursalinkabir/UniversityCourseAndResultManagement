using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityCourseAndResultManagement.Models
{
    public class ViewResults
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string RegNo { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public string Grade { get; set; }

        public string DepartmentName { get; set; }
    }
}