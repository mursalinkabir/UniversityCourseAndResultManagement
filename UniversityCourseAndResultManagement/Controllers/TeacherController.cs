using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseAndResultManagement.Core.BLL;
using UniversityCourseAndResultManagement.Models;

namespace UniversityCourseAndResultManagement.Controllers
{
    public class TeacherController : Controller
    {
        DepartmentManager departmentManager = new DepartmentManager();
        DesignationManager designationManager = new DesignationManager();
        TeacherManager teacherManager = new TeacherManager();
        //
        // GET: /Teacher/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SaveTeacher()
        {
            List<Designation> designations = designationManager.GetAllDesignations();
            List<Department> departments = departmentManager.GetAllDepartments();
            List<SelectListItem> designationSelectlist = new List<SelectListItem>();
            SelectListItem itemempty = new SelectListItem();
            itemempty.Text = "......Select.......";
            itemempty.Value = "";
            designationSelectlist.Add(itemempty);

            //designation dropdown
            foreach (Designation designation in designations)
            {
                SelectListItem item = new SelectListItem
                {
                    Text = designation.Name,
                    Value = designation.Id.ToString()
                };
                designationSelectlist.Add(item);
            }
            ViewBag.Designations = designationSelectlist;
            //department dropdown
            List<SelectListItem> departmentSelectListItems = new List<SelectListItem>();
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
            ViewBag.Departments = departmentSelectListItems;


            return View();
        }

        [HttpPost]
        public ActionResult SaveTeacher(Teacher teacher)
        {
            List<Designation> designations = designationManager.GetAllDesignations();
            List<Department> departments = departmentManager.GetAllDepartments();
            List<SelectListItem> designationSelectlist = new List<SelectListItem>();
            SelectListItem itemempty = new SelectListItem();
            itemempty.Text = "Select";
            itemempty.Value = "";
            designationSelectlist.Add(itemempty);
            foreach (Designation designation in designations)
            {
                SelectListItem item = new SelectListItem
                {
                    Text = designation.Name,
                    Value = designation.Id.ToString()
                };
                designationSelectlist.Add(item);
            }
            ViewBag.Designations = designationSelectlist;

            List<SelectListItem> departmentSelectListItems = new List<SelectListItem>();
          
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
            ViewBag.Departments = departmentSelectListItems;
            ViewBag.Message = teacherManager.SaveTeacher(teacher);
            ModelState.Clear();
            return View();
        }
    }
}