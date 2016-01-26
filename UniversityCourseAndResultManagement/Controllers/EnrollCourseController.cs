using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseAndResultManagement.Core.BLL;
using UniversityCourseAndResultManagement.Models;

namespace UniversityCourseAndResultManagement.Controllers
{
    public class EnrollCourseController : Controller
    {
        EnrollCourseManager enrollCourseManager = new EnrollCourseManager();
        StudentManager studentManager = new StudentManager();
        DepartmentManager departmentManager = new DepartmentManager();
        CourseManager courseManager = new CourseManager();
        //
        // GET: /EnrollCourse/
        public ActionResult EnrollInACourse()
        {
            List<Student> students = studentManager.GetAllStudent();
            ViewBag.StudentList = students;
            return View();
        }
        [HttpPost]
        public ActionResult EnrollInACourse(EnrollCourse enrollCourse)
        {
            ViewBag.Message = enrollCourseManager.Save(enrollCourse);
            List<Student> students = studentManager.GetAllStudent();
            ViewBag.StudentList = students;
            ModelState.Clear();
            return View();
        }
        public JsonResult GetStudentByRegNo(int id)
        {

            var studentList = studentManager.GetAllStudentbyId(id);
            return Json(studentList, JsonRequestBehavior.AllowGet);


        }
        public JsonResult GetDepartmentNameById(int id)
        {

            var studentList = studentManager.GetAllDepartmentNameById(id);
            return Json(studentList, JsonRequestBehavior.AllowGet);


        }
        public JsonResult GetCourseNameById(int id)
        {

            var courseList = departmentManager.GetAllCourseNameById(id);
            return Json(courseList, JsonRequestBehavior.AllowGet);


        }

        public ActionResult Index()
        {
            return View();
        }
    }
}