using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagement.Core.Gateway;
using UniversityCourseAndResultManagement.Models;

namespace UniversityCourseAndResultManagement.Core.BLL
{
    public class EnrollCourseManager
    {
        private EnrollCourseGateway enrollCourseGateway = new EnrollCourseGateway();

        public string Save(EnrollCourse enrollCourse)
        {
            if (enrollCourseGateway.IsStudentCurseExists(enrollCourse))
            {
                return "This student is already enrolled in this course";
            }
            else
            {
                if (enrollCourseGateway.Save(enrollCourse) > 0)
                {
                    return "Saved";
                }
                else
                {
                    return "Save failed";
                }
            }
        }
    }
}

