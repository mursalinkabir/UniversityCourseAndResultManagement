using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseAndResultManagement.Core.BLL;
using UniversityCourseAndResultManagement.Models;

namespace UniversityCourseAndResultManagement.Controllers
{

    public class CourseController : Controller
    {
        DepartmentManager departmentManager = new DepartmentManager();
        SemestersManager semesterManager = new SemestersManager();
        CourseManager courseManager = new CourseManager();
        public ActionResult SaveCourse()
        {


            List<Department> departments = departmentManager.GetAllDepartments();
            ViewBag.Departments = departments;
            List<Semester> semesters = semesterManager.GetAllSemester();
            ViewBag.Semesters = semesters;
            return View();

        }
        [HttpPost]
        public ActionResult SaveCourse(Course course)
        {


            List<Department> departments = departmentManager.GetAllDepartments();
            ViewBag.Departments = departments;
            List<Semester> semesters = semesterManager.GetAllSemester();
            ViewBag.Semesters = semesters;
            ViewBag.Message = courseManager.Save(course);
            return View();
        }
        //Change by sayed
        [HttpGet]
        public ActionResult ShowCourse()
        {


            var departments = departmentManager.GetAllDepartments();


            ViewBag.Departments = departments;

            ViewBag.PostBack = false;
            return View();

        }
        [HttpPost]
        public ActionResult ShowCourse(int DepartmentId)
        {
            var courses = courseManager.GetAllCoursesByDepartment(DepartmentId);
            ViewBag.Courses = courses;


            var departments = departmentManager.GetAllDepartments();
            ViewBag.Departments = departments;

            ViewBag.PostBack = true;


            return View();

        }

        //Change by sayed



        public ActionResult Index()
        {
            return View();
        }
    }
}