using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseAndResultManagement.Core.BLL;
using UniversityCourseAndResultManagement.Models;

namespace UniversityCourseAndResultManagement.Controllers
{
    public class StudentResultController : Controller
    {
        StudentManager studentManager=new StudentManager();
        StudentResultManager studentResultManager=new StudentResultManager();
        DepartmentManager departmentManager=new DepartmentManager();
        //
        // GET: /StudentResult/

        public List<SelectListItem> GetGrade()
        {
            List<SelectListItem> items = new List<SelectListItem>()
            {
                new SelectListItem() {Value = "", Text = "Select...", Selected = true},
                new SelectListItem() {Value = "A+", Text = "A+", Selected = false},
                new SelectListItem() {Value = "A", Text = "A", Selected = false},
                new SelectListItem() {Value = "A-", Text = "A-", Selected = false},
                new SelectListItem() {Value = "B+", Text = "B+", Selected = false},
                new SelectListItem() {Value = "B", Text = "B", Selected = false},
                new SelectListItem() {Value = "B-", Text = "B-", Selected = false},
                new SelectListItem() {Value = "C+", Text = "C+", Selected = false},
                new SelectListItem() {Value = "C", Text = "C", Selected = false},
                new SelectListItem() {Value = "C-", Text = "C-", Selected = false},
                new SelectListItem() {Value = "D+", Text = "D+", Selected = false},
                new SelectListItem() {Value = "D", Text = "D", Selected = false},
                new SelectListItem() {Value = "D-", Text = "D-", Selected = false},
                new SelectListItem() {Value = "F", Text = "F", Selected = false},
            };
            return items;
        }

        public ActionResult SaveStudentResult()
        {
            List<Student> students = studentManager.GetAllStudent();
            ViewBag.StudentList = students;
            ViewBag.Grade = GetGrade();
            return View();
        }

       

        [HttpPost]
        public ActionResult SaveStudentResult(StudentResult studentResult)
        {
            ViewBag.Message = studentResultManager.Save(studentResult);
            List<Student> students = studentManager.GetAllStudent();
            ViewBag.StudentList = students;
            ViewBag.Grade = GetGrade();
            return View();
        }


        public JsonResult GetStudentByRegNo(string RegNo)
        {

            var studentList = studentManager.GetAllStudentbyRegNo(RegNo);
            return Json(studentList, JsonRequestBehavior.AllowGet);


        }
        public JsonResult GetDepartmentNameByRegNo(string RegNo)
        {

            var studentList = studentManager.GetAllDepartmentNameByRegNo(RegNo);
            return Json(studentList, JsonRequestBehavior.AllowGet);


        }
        public JsonResult GetCourseNameByRegNo(string RegNo)
        {

            var courseList = departmentManager.GetAllCourseNameByRegNo(RegNo);
            return Json(courseList, JsonRequestBehavior.AllowGet);


        }
        
	}
}