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
    public class EnrollCourseGateway
    {
        private string connectionString =
          WebConfigurationManager.ConnectionStrings["UniversityCRManagementConnectionDB"].ConnectionString;
        SqlConnection connection = new SqlConnection();
        public decimal Save(EnrollCourse enrollCourse)
        {

            connection.ConnectionString = connectionString;

            string query = "INSERT INTO EnrollCourse (RegNo,CourseId,Date) VALUES(@RegNo,@CourseId,@Date)";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.Add("RegNo", SqlDbType.VarChar);
            command.Parameters["RegNo"].Value = enrollCourse.RegNo;
            //command.Parameters.Add("RegNo", SqlDbType.VarChar);
            //command.Parameters["RegNo"].Value = student.Date.ToString("yyyy") + "-" + student.ContactNo + "-" + student.Id;

            command.Parameters.Add("Date", SqlDbType.DateTime);
            command.Parameters["Date"].Value = enrollCourse.Date;
            command.Parameters.Add("CourseId", SqlDbType.Int);
            command.Parameters["CourseId"].Value = enrollCourse.CourseId;



            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public bool IsStudentCurseExists(EnrollCourse enrollCourse)
        {
            connection.ConnectionString = connectionString;
            string query = "SELECT * FROM EnrollCourse WHERE (RegNo=@RegNo AND CourseId=@CourseId)";

            SqlCommand command = new SqlCommand();
            command.CommandText = query;
            command.Connection = connection;
            command.Parameters.Add("RegNo", SqlDbType.VarChar);
            command.Parameters["RegNo"].Value = enrollCourse.RegNo;
            command.Parameters.Add("CourseId", SqlDbType.VarChar);
            command.Parameters["CourseId"].Value = enrollCourse.CourseId;



            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            bool StudentCurse = false;

            if (reader.HasRows)
            {
                StudentCurse = true;
            }
            connection.Close();

            return StudentCurse;
        }
    }
}