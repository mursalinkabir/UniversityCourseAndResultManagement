using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagement.Core.Gateway;
using UniversityCourseAndResultManagement.Models;

namespace UniversityCourseAndResultManagement.Core.BLL
{
    public class StudentManager
    {
        StudentGateway studentGateway = new StudentGateway();
        public string Save(Student student)
        {
            if (studentGateway.IsEmailExists(student))
            {
                return "Course Code or Name already exist";
            }
            else
            {
                if (studentGateway.Save(student) > 0)
                {
                    return "Saved";
                }
                else
                {
                    return "Save failed";
                }
            }
        }

        public StudentView GetAllStudent(string Email)
        {
            return studentGateway.GetAllStudent(Email);
        }
    }
}

