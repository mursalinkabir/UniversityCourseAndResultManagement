using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagement.Core.Gateway;
using UniversityCourseAndResultManagement.Models;

namespace UniversityCourseAndResultManagement.Core.BLL
{
  
    public class RoomManager
    {
        RoomGateway roomGateway = new RoomGateway();
        public List<Room> GetAllRooms()
        {
            return roomGateway.GetAllRooms();
        }
    }
}