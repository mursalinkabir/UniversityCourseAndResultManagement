using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagement.Core.Gateway;
using UniversityCourseAndResultManagement.Models;

namespace UniversityCourseAndResultManagement.Core.BLL
{
    public class StudentResultManager
    {
        StudentGateway studentGateway=new StudentGateway();
        StudentResultGateway studentResultGateway =new StudentResultGateway();
        public string Save(StudentResult studentResult)
        {
            if (studentResultGateway.IsStudentResultExists(studentResult))
            {
                return "This student is already evaluated";
            }
            else
            {
                if (studentResultGateway.Save(studentResult) > 0)
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