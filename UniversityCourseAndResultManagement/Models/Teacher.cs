using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityCourseAndResultManagement.Models
{
    public class Teacher
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public int DesignationId { get; set; }
        public string DepartmentId { get; set; }
        public int Credit { get; set; }
        public string CourseId { get; set; }
    }
}