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
        private CourseGateway courseGateway = new CourseGateway();

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

        public List<Teacher> GetAllTeacherbyDeptID(int Id)
        {
            return teacherGateway.GetAllTeacherbyDeptID(Id);
        }

        public Teacher GetTeacherInfoById(int teacherId)
        {
            return teacherGateway.GetTeacherInfoById(teacherId);
        }

        public string UpdateRemainingCredit(int teacherId, int remainCredit,string CourseName)
        {
            
            
                if (teacherGateway.UpdateRemainingCredit(teacherId, remainCredit) > 0)
                {
                    return "Assign Remaining  to Credit successfully !!!";
                }
                else
                {
                    return "Assign Remaining  to Credit failure !!!";
                }
            
            
          

            
        }
    }
}