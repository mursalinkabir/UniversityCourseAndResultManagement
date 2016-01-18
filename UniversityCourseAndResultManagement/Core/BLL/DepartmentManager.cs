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