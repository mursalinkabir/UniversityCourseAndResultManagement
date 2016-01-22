using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagement.Core.Gateway;
using UniversityCourseAndResultManagement.Models;

namespace UniversityCourseAndResultManagement.Core.BLL
{
    public class CourseManager
    {

        private CourseGateway courseGateway = new CourseGateway();

        public string Save(Course course)
        {
            if (courseGateway.IsCourseExists(course))
            {
                return "Course Code or Name already exist";
            }
            else
            {
                if (courseGateway.Save(course) > 0)
                {
                    return "Saved";
                }
                else
                {
                    return "Save failed";
                }
            }

        }

        //change by sayed
        public List<Course> GetAllCoursesByDepartment(int DepartmentId)
        {
            return courseGateway.GetAllCoursesByDepartment(DepartmentId);
        }
        //change by sayed
    }
}