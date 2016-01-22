﻿using System;
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
        TeacherManager teacherManager= new TeacherManager();

        private List<SelectListItem> GetDepartmentForSelectList()
        {
            List<Department> departments = departmentManager.GetAllDepartments();
            List<SelectListItem> departmentSelectListItems = new List<SelectListItem>();
            SelectListItem itemempty = new SelectListItem();
            itemempty.Text = "Select";
            itemempty.Value = "";
            departmentSelectListItems.Add(itemempty);
            foreach (Department department in departments)
            {
                SelectListItem item = new SelectListItem
                {
                    Text = department.Name,
                    Value = department.Id.ToString()
                };
                departmentSelectListItems.Add(item);
            }
            return departmentSelectListItems;

        }
       
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

        public ActionResult CourseAssign()
        {

            ViewBag.Departments = GetDepartmentForSelectList();

            return View();
        }
        public JsonResult GetAllTeacherbyDeptId(int departmentId)
        {
            var teacherList = teacherManager.GetAllTeacherbyDeptID(departmentId);
            return Json(teacherList, JsonRequestBehavior.AllowGet);
            
        }
        public JsonResult GetTeacherInfoById(int teacherId)
        {
            Teacher teacher = teacherManager.GetTeacherInfoById(teacherId);
            return Json(teacher, JsonRequestBehavior.AllowGet);

        }
    }
   
}