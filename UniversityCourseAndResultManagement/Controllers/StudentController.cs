using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseAndResultManagement.Core.BLL;
using UniversityCourseAndResultManagement.Models;

namespace UniversityCourseAndResultManagement.Controllers
{
    public class StudentController : Controller
    {

        DepartmentManager departmentManager = new DepartmentManager();
        StudentManager studentManager = new StudentManager();
        public ActionResult SaveStudent()
        {
            ViewBag.PostBack = false;
            List<Department> departments = departmentManager.GetAllDepartments();
            ViewBag.Departments = departments;
            return View();
        }

        [HttpPost]
        public ActionResult SaveStudent(Student student, string Email)
        {
            ViewBag.PostBack = false;
            List<Department> departments = departmentManager.GetAllDepartments();
            ViewBag.Departments = departments;
            ViewBag.Message = studentManager.Save(student);
            if (Email != String.Empty)
            {
                ViewBag.PostBack = true;
            }
            StudentView students = studentManager.GetAllStudentByEmail(Email);
            ViewBag.Students = students;

            ModelState.Clear();
            return View();
        }

        public JsonResult GetCodeByDepartmentId(int departmentId)
        {

            var teacherList = departmentManager.GetAllCodebyDeptID(departmentId);
            return Json(teacherList, JsonRequestBehavior.AllowGet);


        }



        //public ActionResult Index()
        //{
        //    return View();
        //}
    }
}