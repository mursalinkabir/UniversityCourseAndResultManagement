using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseAndResultManagement.Core.BLL;
using UniversityCourseAndResultManagement.Models;

namespace UniversityCourseAndResultManagement.Controllers
{
    public class DepartmentController : Controller
    {
        //
        // GET: /Department/

        DepartmentManager departmentManager=new DepartmentManager();
        public ActionResult SaveDeparment()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SaveDeparment(Department department)
        {
            ViewBag.Message = departmentManager.SaveDepartment(department);
            return View();
        }

        public ActionResult ShowDepartment()
        {
            var departments = departmentManager.GetAllDepartments();
            return View(departments);
        }
        public ActionResult Index()
        {
            return View();
        }
	}
}