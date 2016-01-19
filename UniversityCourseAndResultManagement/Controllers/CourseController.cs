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
        DepartmentManager departmentManager=new DepartmentManager();
        DropdownManager semesterManager=new DropdownManager();
        CourseManager courseManager=new CourseManager();
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

        public ActionResult Index()
        {
            return View();
        }
	}
}