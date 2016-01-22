using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseAndResultManagement.Core.BLL;

namespace UniversityCourseAndResultManagement.Controllers
{
    public class CourseViewController : Controller
    {
        //
        // GET: /CourseView/
        CourseViewManager courseViewManager=new CourseViewManager();
        DepartmentManager departmentManager=new DepartmentManager();
         public ActionResult ViewCourse()
        {
            
            
           var departments = departmentManager.GetAllDepartments();

       
            ViewBag.Departments = departments;

            ViewBag.PostBack = false;
            return View();
           
        }

        [HttpPost]
        public ActionResult ViewCourse(int DepartmentId)
        {
            var courses = courseViewManager.GetAllCoursesByDepartment(DepartmentId);
            ViewBag.Courses = courses;


            var departments = departmentManager.GetAllDepartments();
            ViewBag.Departments = departments;

            ViewBag.PostBack = true;


            return View();
        }

        public ActionResult Index()
        {
            return View();
        }
	}
}