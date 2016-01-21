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

        public string SaveTeacher(Teacher teacher)
        {
            if (teacherGateway.IsEmailUnique(teacher))
            {
                return "Teacher Email must be unique !!!";
            }
            else
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

        }
    }
}