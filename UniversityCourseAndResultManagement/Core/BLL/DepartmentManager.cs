using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagement.Core.Gateway;
using UniversityCourseAndResultManagement.Models;

namespace UniversityCourseAndResultManagement.Core.BLL
{
    public class DepartmentManager
    {
        private DepartmentGateway departmentGateway = new DepartmentGateway();

        public string SaveDepartment(Department department)
        {
            if (departmentGateway.IsDepartmentExists(department))
            {
                return "Department Name And Code must be unique !!!";
            }
            else
            {
                if (departmentGateway.SaveDepartment(department) > 0)
                {
                    return "Save successfully";
                }
                else
                {
                    return "Insertion failure !!!";
                }
            }

        }





        public List<Department> GetAllDepartments()
        {
            return departmentGateway.GetAllDepartments();
        }

        public Department GetAllCodebyDeptID(int departmentId)
        {
            return departmentGateway.GetAllCodebyDeptID(departmentId);
        }


        public List<Course> GetAllCourseNameByStudentRegNo(string regNo)
        {
            return departmentGateway.GetAllCourseNameByStudentRegNo(regNo);
        }

        public List<Course> GetAllCourseNameByRegNo(string regNo)
        {
            return departmentGateway.GetAllCourseNameByRegNo(regNo);
        }
    }
}