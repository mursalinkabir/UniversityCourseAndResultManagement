using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseAndResultManagement.Core.BLL;
using UniversityCourseAndResultManagement.Models;

namespace UniversityCourseAndResultManagement.Controllers
{
    public class CourseSchedueController : Controller
    {
        //
        // GET: /CourseSchedue/

        DepartmentManager departmentManager=new DepartmentManager();
        CourseScheduleManager courseScheduleManager=new CourseScheduleManager();
        public ActionResult CourseSchedule()
        {


            var departments = departmentManager.GetAllDepartments();


            ViewBag.Departments = departments;

            ViewBag.PostBack = false;
            return View();

        }

        [HttpPost]
        public ActionResult CourseSchedule(int DepartmentId)
        {
            var departments = departmentManager.GetAllDepartments();
            ViewBag.Departments = departments;
            var schedule = courseScheduleManager.GetAllCourseScheduleByDepartment(DepartmentId);
            ViewBag.Schedule = schedule;
           
           

            ViewBag.PostBack = true;


            return View();
        }
        public ActionResult Index()
        {
            return View();
        }
	}
}