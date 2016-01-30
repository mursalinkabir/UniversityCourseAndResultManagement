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
    public class StudentResultGateway
    {
        private string connectionString =
            WebConfigurationManager.ConnectionStrings["UniversityCRManagementConnectionDB"].ConnectionString;
        SqlConnection connection = new SqlConnection();

        public bool IsStudentResultExists(StudentResult studentResult)
        {
            connection.ConnectionString = connectionString;

            string query = "SELECT * FROM StudentResult WHERE RegNo =@RegNo AND CourseId=@CourseId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.Add("RegNo", SqlDbType.VarChar);
            command.Parameters["RegNo"].Value = studentResult.RegNo;
            command.Parameters.Add("CourseId", SqlDbType.Int);
            command.Parameters["CourseId"].Value = studentResult.CourseId;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                connection.Close();
                return true;
            }
            else
            {
                connection.Close();
                return false;
            }
        }

        public int Save(StudentResult studentResult)
        {
            connection.ConnectionString = connectionString;
            string query = "INSERT INTO StudentResult(RegNo,CourseId,Grade) VALUES(@RegNo,@CourseId,@Grade)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.Add("RegNo", SqlDbType.VarChar);
            command.Parameters["RegNo"].Value = studentResult.RegNo;
            command.Parameters.Add("CourseId", SqlDbType.Int);
            command.Parameters["CourseId"].Value = studentResult.CourseId;
            command.Parameters.Add("Grade", SqlDbType.VarChar);
            command.Parameters["Grade"].Value = studentResult.Grade;
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }
    }
}