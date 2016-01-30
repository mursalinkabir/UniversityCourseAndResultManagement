using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCourseAndResultManagement.Core.Gateway;
using UniversityCourseAndResultManagement.Models;

namespace UniversityCourseAndResultManagement.Core.BLL
{ 
    
    public class AllocateClassRoomManager
    {
        AllocateClassRoomGateway allocateClassRoomGateway = new AllocateClassRoomGateway();
        public string SaveClassAllocation(AllocateClassRoom allocateClassRoom)
        {
            if (allocateClassRoomGateway.CheckTimeCollission(allocateClassRoom))
            {
                if (allocateClassRoomGateway.SaveAllocatedRoom(allocateClassRoom) > 0)
                {
                    return "Class Room Allocated";
                }
                else
                {
                    return " Class room is not allocated";
                }
            }
        else{
                return "Time Collision";
            }
        }
    }
}