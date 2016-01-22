using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagement.Core.Gateway;
using UniversityCourseAndResultManagement.Models;

namespace UniversityCourseAndResultManagement.Core.BLL
{

    
    public class CourseViewManager
    {
        CourseViewGateway courseViewGateway=new CourseViewGateway();
        public List<CourseView> GetAllCoursesByDepartment(int DepartmentId)
        {
            return courseViewGateway.GetAllCoursesByDepartment(DepartmentId);
        }

    }
}