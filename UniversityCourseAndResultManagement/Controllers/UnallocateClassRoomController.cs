using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCourseAndResultManagement.Core.BLL;
using UniversityCourseAndResultManagement.Models;

namespace UniversityCourseAndResultManagement.Controllers
{
    public class UnallocateClassRoomController : Controller
    {
        //
        // GET: /UnallocateClassRoom/

        UnallocateClassRoomManager unallocateClassRoomManager=new UnallocateClassRoomManager();
        public ActionResult UnallocateClassRoom()
        {
            return View();

        }
        [HttpPost]
        public ActionResult UnallocateClassRoom(AllocateClassRoom allocateClassRoom)
        {
            var unallocateClassRoom = unallocateClassRoomManager.UnallocateClassRoom(allocateClassRoom);
            ViewBag.Message = unallocateClassRoom;
            return View();

        }

        public ActionResult Index()
        {
            return View();
        }
	}
}