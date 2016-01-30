using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Rotativa;
using UniversityCourseAndResultManagement.Core.BLL;
using UniversityCourseAndResultManagement.Models;
using ViewResult = System.Web.Mvc.ViewResult;

namespace UniversityCourseAndResultManagement.Controllers
{
    public class ViewResultController : Controller
    {
        public string regno1;
        StudentManager studentManager=new StudentManager();
        CourseManager courseManager=new CourseManager();
        //
        // GET: /ViewResult/
        public ActionResult ShowResult()
        {
            ViewBag.PostBack = false;
            List<Student> students = studentManager.GetAllStudent();
            ViewBag.StudentList = students;
            return View();
        }
        [HttpPost]

        public ActionResult ShowResult(ViewResults viewResults,  string RegNo)
        {
            regno1 = RegNo;
            ViewBag.PostBack = false;
            List<Student> students = studentManager.GetAllStudent();
            ViewBag.StudentList = students;
            if (RegNo != String.Empty)
            {
                ViewBag.PostBack = true;
            }
            Student Students = studentManager.GetAllStudentbyRegNo(RegNo);

            ViewBag.studentLists = Students;

            StudentView studentView=studentManager.GetAllDepartmentNameByRegNo(RegNo);
            ViewBag.DepartmentName = studentView;
            List<ViewResults> results = courseManager.GetAllResult(RegNo);
            ViewBag.Results = results;
            return new ActionAsPdf(
              "ShowResult2",
              new { viewResults = viewResults, RegNo = RegNo }

              ) { FileName = "ResultView.pdf" };
        }
        
        public ActionResult ShowResult2(ViewResults viewResults, string RegNo)
        {
            
           
            Student Students = studentManager.GetAllStudentbyRegNo(RegNo);

            ViewBag.studentLists = Students;

            StudentView studentView = studentManager.GetAllDepartmentNameByRegNo(RegNo);
            ViewBag.DepartmentName = studentView;
            List<ViewResults> results = courseManager.GetAllResult(RegNo);
            ViewBag.Results = results;
            DateTime dt = DateTime.Now;
            ViewBag.Date = dt;
            return View();

        }
        public ActionResult GeneratePDF(ViewResults viewResults, string RegNo)
        {
            ViewBag.PostBack = false;
            List<Student> students = studentManager.GetAllStudent();
            ViewBag.StudentList = students;
            if (RegNo != String.Empty)
            {
                ViewBag.PostBack = true;
            }
            Student Students = studentManager.GetAllStudentbyRegNo(RegNo);

            ViewBag.studentLists = Students;

            StudentView studentView = studentManager.GetAllDepartmentNameByRegNo(RegNo);
            ViewBag.DepartmentName = studentView;
            List<ViewResults> results = courseManager.GetAllResult(RegNo);
            ViewBag.Results = results;
            //List<Student> students = studentManager.GetAllStudent();
            //ViewBag.StudentList = students;
            //  List<ViewResults> results=  ViewBag.Results;
            return new ActionAsPdf(
                "ShowResult2",
                new {viewResults = viewResults, RegNo=RegNo}
                
                )
            {FileName = "ResultView.pdf"};


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
        public JsonResult GetAllResultByRegNo(string RegNo)
        {

            var resultList = courseManager.GetAllResult(RegNo);
            return Json(resultList, JsonRequestBehavior.AllowGet);


        }
        public ActionResult Index()
        {
            return View();
        }
	}
}