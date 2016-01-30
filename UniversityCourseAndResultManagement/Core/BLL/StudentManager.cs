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
                return "Email already exist";
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

        public StudentView GetAllStudentByEmail(string Email)
        {
            return studentGateway.GetAllStudentByEmail(Email);
        }

        public List<Student> GetAllStudent()
        {
            return studentGateway.GetAllStudent();
        }

        public Student GetAllStudentbyId(int id)
        {
            return studentGateway.GetAllStudentbyId(id);
        }

        public StudentView GetAllDepartmentNameById(int id)
        {
            return studentGateway.GetAllDepartmentNameById(id);
        }

        public Student GetAllStudentbyRegNo(string regNo)
        {
            return studentGateway.GetAllStudentbyRegNo(regNo);
        }

        public StudentView GetAllDepartmentNameByRegNo(string regNo)
        {
            return studentGateway.GetAllDepartmentNameByRegNo(regNo);
        }
    }
}

