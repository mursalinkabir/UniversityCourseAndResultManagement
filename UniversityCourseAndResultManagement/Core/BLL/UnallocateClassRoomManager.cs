using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagement.Core.Gateway;
using UniversityCourseAndResultManagement.Models;

namespace UniversityCourseAndResultManagement.Core.BLL
{
    public class UnallocateClassRoomManager
    {

        UnallocateClassRoomGateway unallocateClassRoomGateway = new UnallocateClassRoomGateway();

        public string UnallocateClassRoom(AllocateClassRoom allocateClassRoom)
        {
            if (unallocateClassRoomGateway.UnallocateClassRoom(allocateClassRoom) > 0)
            {
                return " Unallocation successfully";

            }
            else
            {
                return "Unallocation fail!!!";
            }
        }
    }
}