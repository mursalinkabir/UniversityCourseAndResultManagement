using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseAndResultManagement.Core.BLL;
using UniversityCourseAndResultManagement.Models;

namespace UniversityCourseAndResultManagement.Controllers
{
    public class AllocateClassController : Controller
    {
        DepartmentManager departmentManager = new DepartmentManager();
        CourseManager courseManager = new CourseManager();
        RoomManager roomManager = new RoomManager();
        AllocateClassRoomManager allocateClassRoomManager = new AllocateClassRoomManager();
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

        private List<SelectListItem> GetRoomsForSelectList()
        {

            List<Room> Rooms = roomManager.GetAllRooms();
            List<SelectListItem> roomSelectListItems = new List<SelectListItem>();
            SelectListItem itemempty = new SelectListItem();
            itemempty.Text = "Select";
            itemempty.Value = "";
            roomSelectListItems.Add(itemempty);
            foreach (Room room in Rooms)
            {
                SelectListItem item = new SelectListItem
                {
                    Text = room.RoomNo,
                    Value = room.Id.ToString()
                };
                roomSelectListItems.Add(item);
            }
            return roomSelectListItems;

        }
        // days
        private List<SelectListItem> GetDaysForSelectList()
        {

           
            List<SelectListItem> daySelectListItems = new List<SelectListItem>();
            SelectListItem itemempty = new SelectListItem();
            itemempty.Text = "Select";
            itemempty.Value = "";
            daySelectListItems.Add(itemempty);
            Dictionary<string, int> days = new Dictionary<string, int>()
            {
                {"SAT",1},
                {"SUN",2},
                {"MON",3},
                {"TUE",4},
                {"WED",5},
                {"THU",6},
                {"FRI",7}
            };
            foreach (var day in days)
            {
                SelectListItem item = new SelectListItem
                {
                    Text = day.Key,
                    Value = day.Value.ToString()
                };
                daySelectListItems.Add(item);
            }
            return daySelectListItems;

        }

        //
        // GET: /AllocateClass/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AllocateClassRoom()
        {
            ViewBag.Departments = GetDepartmentForSelectList();
            ViewBag.Rooms = GetRoomsForSelectList();
            ViewBag.Days = GetDaysForSelectList();
            return View();
        }

        [HttpPost]
        public ActionResult AllocateClassRoom(AllocateClassRoom allocateClassRoom)
        {
            ViewBag.Departments = GetDepartmentForSelectList();
            ViewBag.Rooms = GetRoomsForSelectList();
            ViewBag.Days = GetDaysForSelectList();
            //data manipulation
            DateTime start = new DateTime(2016, 1, 1, allocateClassRoom.TimeStart.Hour, allocateClassRoom.TimeStart.Minute, allocateClassRoom.TimeStart.Second);
            DateTime end = new DateTime(2016, 1, 1, allocateClassRoom.TimeEnd.Hour, allocateClassRoom.TimeEnd.Minute, allocateClassRoom.TimeEnd.Second);
            allocateClassRoom.TimeStart = start;
            allocateClassRoom.TimeEnd = end;
            ViewBag.TimeClash=allocateClassRoomManager.SaveClassAllocation(allocateClassRoom);

            return View();
        }
	}
}