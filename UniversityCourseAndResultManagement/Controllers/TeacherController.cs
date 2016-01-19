using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseAndResultManagement.Core.BLL;

namespace UniversityCourseAndResultManagement.Controllers
{
    public class TeacherController : Controller
    {
        DepartmentManager departmentManager = new DepartmentManager();
        //
        // GET: /Teacher/
        public ActionResult Index()
        {
            return View();
        }
	}
}