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
    public class TeacherGateway
    {
        private string connectionString =
            WebConfigurationManager.ConnectionStrings["UniversityCRManagementConnectionDB"].ConnectionString;
        SqlConnection connection = new SqlConnection();
        public bool IsTeacherExists(Teacher teacher)
        {
            connection.ConnectionString = connectionString;
            string query = "SELECT * FROM Course WHERE (Code=@Code And Name =  @Name )";


            Course course=new Course();
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

        public bool IsEmailUnique(Teacher teacher)
        {
            throw new NotImplementedException();
        }

        public int SaveTeacher(Teacher teacher)
        {
            throw new NotImplementedException();
        }
    }
}