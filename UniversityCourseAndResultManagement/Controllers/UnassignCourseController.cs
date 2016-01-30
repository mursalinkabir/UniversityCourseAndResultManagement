using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseAndResultManagement.Core.BLL;
using UniversityCourseAndResultManagement.Models;

namespace UniversityCourseAndResultManagement.Controllers
{
    public class UnassignCourseController : Controller
    {
        //
        // GET: /UnassignCourse/

        UnassignCourseManager unassignCourseManager=new UnassignCourseManager();
        public ActionResult UnassignCourse()
        {


            return View();
        }
        [HttpPost]
        public ActionResult UnassignCourse(Course course)
        {

            var courses = unassignCourseManager.UnassignCourse(course);
            ViewBag.Courses = courses;
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }
	}
}