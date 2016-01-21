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
   

        public bool IsEmailUnique(Teacher teacher)
        {
            connection.ConnectionString = connectionString;
            string query = "SELECT * FROM Teacher WHERE Email=@Email";


            Course course=new Course();
            SqlCommand command = new SqlCommand();
            command.CommandText = query;
            command.Connection = connection;
            command.Parameters.Add("Email", SqlDbType.VarChar);
            command.Parameters["Email"].Value = teacher.Email;

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            bool isEmailUnique = false;

            if (reader.HasRows)
            {
                isEmailUnique = true;
            }
            connection.Close();

            return isEmailUnique;
        }

        public int SaveTeacher(Teacher teacher)
        {
            connection.ConnectionString = connectionString;

            string query = "INSERT INTO Teacher (Name,Address,Email,ContactNo,DesignationId,DepartmentId,Credit) VALUES(@Name,@Address,@Email,@ContactNo,@DesignationId,@DepartmentId,@Credit)";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.Add("Name", SqlDbType.VarChar);
            command.Parameters["Name"].Value = teacher.Name;
            command.Parameters.Add("Address", SqlDbType.VarChar);
            command.Parameters["Address"].Value = teacher.Address;
            command.Parameters.Add("Email", SqlDbType.VarChar);
            command.Parameters["Email"].Value = teacher.Email;
            command.Parameters.Add("ContactNo", SqlDbType.VarChar);
            command.Parameters["ContactNo"].Value = teacher.ContactNo;
            command.Parameters.Add("DesignationId", SqlDbType.Int);
            command.Parameters["DesignationId"].Value = teacher.DesignationId;
            command.Parameters.Add("DepartmentId", SqlDbType.Int);
            command.Parameters["DepartmentId"].Value = teacher.DepartmentId;
            command.Parameters.Add("Credit", SqlDbType.Int);
            command.Parameters["Credit"].Value = teacher.Credit;
            //command.Parameters.Add("CourseId", SqlDbType.Int);
            //command.Parameters["CourseId"].Value = teacher.CourseId;


            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }
    }
}