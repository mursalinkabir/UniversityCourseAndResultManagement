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
    public class CourseGateway
    {
        private string connectionString =
            WebConfigurationManager.ConnectionStrings["UniversityCRManagementConnectionDB"].ConnectionString;
        SqlConnection connection = new SqlConnection();
        public bool IsCourseExists(Course course)
        {
            connection.ConnectionString = connectionString;
            string query = "SELECT * FROM Course WHERE (Code=@Code OR Name =  @Name )";




            SqlCommand command = new SqlCommand();
            command.CommandText = query;
            command.Connection = connection;
            command.Parameters.Add("Code", SqlDbType.VarChar);
            command.Parameters["Code"].Value = course.Code;
            command.Parameters.Add("Name", SqlDbType.VarChar);
            command.Parameters["Name"].Value = course.Name;


            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            bool isCourseExist = false;

            if (reader.HasRows)
            {
                isCourseExist = true;
            }
            connection.Close();

            return isCourseExist;
        }

        public int Save(Course course)
        {
            connection.ConnectionString = connectionString;

            string query = "INSERT INTO Course VALUES(@Code,@Name,@Credit,@Description,@DepartmentId,@SemesterId)";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.Add("Code", SqlDbType.VarChar);
            command.Parameters["Code"].Value = course.Code;
            command.Parameters.Add("Name", SqlDbType.VarChar);
            command.Parameters["Name"].Value = course.Name;
            command.Parameters.Add("Credit", SqlDbType.Decimal);
            command.Parameters["Credit"].Value =course.Credit;
            command.Parameters.Add("Description", SqlDbType.VarChar);
            command.Parameters["Description"].Value = course.Description;
            command.Parameters.Add("DepartmentId", SqlDbType.Int);
            command.Parameters["DepartmentId"].Value = course.DepartmentId;
            command.Parameters.Add("SemesterId", SqlDbType.Int);
            command.Parameters["SemesterId"].Value = course.SemesterId;


            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }
    }
}