using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityCourseAndResultManagement.Models;

namespace UniversityCourseAndResultManagement.Core.Gateway
{
    public class UnallocateClassRoomGateway
    {
        private string connectionString =
            WebConfigurationManager.ConnectionStrings["UniversityCRManagementConnectionDB"].ConnectionString;

        private SqlConnection connection = new SqlConnection();

        public int UnallocateClassRoom(AllocateClassRoom allocateClassRoom)
        {
            connection.ConnectionString = connectionString;



            string query = "Update AllocateClass Set RoomId=Null, Day=Null, TimeStart=Null, TimeEnd=Null";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();



            return rowAffected;
        }
    }
}