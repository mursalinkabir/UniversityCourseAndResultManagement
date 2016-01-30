using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagement.Core.Gateway;
using UniversityCourseAndResultManagement.Models;

namespace UniversityCourseAndResultManagement.Core.BLL
{
    public class UnassignCourseManager
    {
        UnassignCourseGateway unassignCourseGateway=new UnassignCourseGateway();
        public string UnassignCourse(Course course)
        {



            if (unassignCourseGateway.UnassignCourses(course) > 0)
            {
                return "Unassign courses successfully.";
            }
            else
            {
                return "Unassign courses fail.";
            }



        }
    }
}