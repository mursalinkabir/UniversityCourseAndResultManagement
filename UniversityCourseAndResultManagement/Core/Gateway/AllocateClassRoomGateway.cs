using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityCourseAndResultManagement.Models;

namespace UniversityCourseAndResultManagement.Core.Gateway
{
    public class AllocateClassRoomGateway
    {
       
        private string connectionString =
            WebConfigurationManager.ConnectionStrings["UniversityCRManagementConnectionDB"].ConnectionString;
        SqlConnection connection = new SqlConnection();
        public bool CheckTimeCollission(AllocateClassRoom allocateClassRoom)
        {
            connection.ConnectionString = connectionString;
            string query = "SELECT TimeStart,TimeEnd FROM AllocateClass WHERE Day=@Day AND RoomId=@RoomId";
            SqlCommand command = new SqlCommand();
            command.CommandText = query;
            command.Connection = connection;
            command.Parameters.Add("Day", SqlDbType.VarChar);
            command.Parameters["Day"].Value = allocateClassRoom.Day;
            command.Parameters.Add("RoomId", SqlDbType.Int);
            command.Parameters["RoomId"].Value = allocateClassRoom.RoomId;

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            bool IstimeValid1 = false;
            // check if the query return value 
            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    DateTime start = (DateTime)reader["TimeStart"];
                    DateTime end = (DateTime)reader["TimeEnd"];
                    TimeSpan ts = new TimeSpan(0, 0, 5);
                    //offsetting 5 seconds
                    DateTime start2 = DateTime.Now;
                    DateTime end2 = DateTime.Now;
                    start2 = start + ts;
                    end2 = end - ts;
                    IstimeValid1 = TimeChecker(allocateClassRoom.TimeStart, allocateClassRoom.TimeEnd, start2, end2);
                    //IstimeValid2 = TimeChecker(, start, end);
                }

                reader.Close();
                connection.Close();
                if (IstimeValid1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                reader.Close();
                connection.Close();
                return true;
            }
            
        }

        public int SaveAllocatedRoom(AllocateClassRoom allocateClassRoom)
        {

            connection.ConnectionString = connectionString;

            string query = "INSERT INTO AllocateClass(DepartmentId,CourseId,RoomId,Day,TimeStart,TimeEnd) VALUES(@DepartmentId,@CourseId,@RoomId,@Day,@TimeStart,@TimeEnd)";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.Add("DepartmentId", SqlDbType.Int);
            command.Parameters["DepartmentId"].Value = allocateClassRoom.DepartmentId;

            command.Parameters.Add("CourseId", SqlDbType.Int);
            command.Parameters["CourseId"].Value = allocateClassRoom.CourseId;
            command.Parameters.Add("RoomId", SqlDbType.Int);
            command.Parameters["RoomId"].Value = allocateClassRoom.RoomId;
            command.Parameters.Add("Day", SqlDbType.VarChar);
            command.Parameters["Day"].Value = allocateClassRoom.Day;
            command.Parameters.Add("TimeStart", SqlDbType.DateTime);
            command.Parameters["TimeStart"].Value = allocateClassRoom.TimeStart;
            command.Parameters.Add("TimeEnd", SqlDbType.DateTime);
            command.Parameters["TimeEnd"].Value = allocateClassRoom.TimeEnd;
            


            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }
        private bool TimeChecker(DateTime allocateStart, DateTime allocateEnd, DateTime dbstart, DateTime dbend)
        {
            // start part 
            int result1 = DateTime.Compare(allocateStart, dbstart);
            bool flag1 = false;
            if (result1 < 0)
            {
                flag1 = true;
            }
            else if (result1 == 0)
            {
                flag1 = false;
            }
            else
            {
                flag1 = false;
            }
            //for end part
            int result2 = DateTime.Compare(allocateStart, dbend);
            bool flag2 = false;
            if (result2 < 0)
            {
                flag2 = true;
            }
            else if (result2 == 0)
            {
                flag2 = false;
            }
            else
            {
                flag2 = false;
            }
            //FOR ALLOCATE END PART (REPEAT)

            // start part 
            int result3 = DateTime.Compare(allocateEnd, dbstart);
            bool flag3 = false;
            if (result3 < 0)
            {
                flag3 = true;
            }
            else if (result3 == 0)
            {
                flag3 = false;
            }
            else
            {
                flag3 = false;
            }
            //for end part
            int result4 = DateTime.Compare(allocateEnd, dbend);
            bool flag4 = false;
            if (result4 < 0)
            {
                flag4 = true;
            }
            else if (result4 == 0)
            {
                flag4 = false;
            }
            else
            {
                flag4 = false;
            }


            //testing 4 flags
            if (flag1 == true & flag2 == true & flag3 == true & flag4 == true)
            {
                return true;
            }
            else if (flag1 == false & flag2 == false & flag3 == false & flag4 == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}