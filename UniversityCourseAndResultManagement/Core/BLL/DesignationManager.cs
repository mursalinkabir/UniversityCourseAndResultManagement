using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagement.Core.Gateway;
using UniversityCourseAndResultManagement.Models;

namespace UniversityCourseAndResultManagement.Core.BLL
{
    public class DesignationManager
    {
        DesignationGateway designationGateway = new DesignationGateway();
        public List<Designation> GetAllDesignations()
        {
            return designationGateway.GetAllDesignations();
        }
    }
}