using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagement.Core.Gateway;
using UniversityCourseAndResultManagement.Models;

namespace UniversityCourseAndResultManagement.Core.BLL
{
    public class CourseScheduleManager
    {
        CourseScheduleGateway courseScheduleGateway=new CourseScheduleGateway();

        public List<CourseSchedule> GetAllCourseScheduleByDepartment(int DepartmentId)
        {
            return courseScheduleGateway.GetAllCourseScheduleByDepartment(DepartmentId);
        }
       
    }
}