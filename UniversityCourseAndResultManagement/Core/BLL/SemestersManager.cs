using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagement.Core.Gateway;
using UniversityCourseAndResultManagement.Models;

namespace UniversityCourseAndResultManagement.Core.BLL
{
    public class SemestersManager
    { 
        SemestersGateway semesterGateway=new SemestersGateway();
        public List<Semester> GetAllSemester()
        {
            return semesterGateway.GetAllSemester();
        }
       
    }
}