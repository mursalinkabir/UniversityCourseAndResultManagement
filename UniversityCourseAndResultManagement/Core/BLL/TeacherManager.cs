using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagement.Core.Gateway;
using UniversityCourseAndResultManagement.Models;

namespace UniversityCourseAndResultManagement.Core.BLL
{
    public class TeacherManager
    {
        private TeacherGateway teacherGateway = new TeacherGateway();

        public string SaveDepartment(Teacher teacher)
        {
            if (teacherGateway.IsTeacherExists(teacher))
            {
                return "Teacher Name must be unique !!!";
            }
            else
            {
                if (teacherGateway.IsEmailUnique(teacher))
                {
                    if (teacherGateway.SaveTeacher(teacher) > 0)
                    {
                        return "Save successfully !!!";
                    }
                    else
                    {
                        return "Insertion failure !!!";
                    }
                }
                else
                {
                    return "Email is not unique";
                }
               
            }

        }
    }
}