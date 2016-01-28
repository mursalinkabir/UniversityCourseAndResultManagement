using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityCourseAndResultManagement.Models;

namespace UniversityCourseAndResultManagement.Core.Gateway
{
    public class RoomGateway
    {
        private string connectionString =
            WebConfigurationManager.ConnectionStrings["UniversityCRManagementConnectionDB"].ConnectionString;
        SqlConnection connection = new SqlConnection();
        public List<Room> GetAllRooms()
        {
            connection.ConnectionString = connectionString;

            string query = "SELECT * FROM Room ";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Room> roomList = new List<Room>();
            while (reader.Read())
            {
                Room room = new Room();
                room.Id = Convert.ToInt32(reader["Id"].ToString());
                room.RoomNo = reader["RoomNo"].ToString();
                
                roomList.Add(room);
            }

            reader.Close();
            connection.Close();
            return roomList;
        }
    }
}