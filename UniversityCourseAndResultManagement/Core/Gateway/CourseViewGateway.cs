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
    public class CourseViewGateway
    {
        private string connectionString =
            WebConfigurationManager.ConnectionStrings["UniversityCRManagementConnectionDB"].ConnectionString;
        SqlConnection connection = new SqlConnection();
        public List<CourseView> GetAllCoursesByDepartment(int deptId)
        {
            connection.ConnectionString = connectionString;

            string query = "SELECT * FROM CourseStatics WHERE (DepartmentId=@DepartmentId)";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add("DepartmentId", SqlDbType.Int);
            command.Parameters["DepartmentId"].Value = deptId;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<CourseView> courseViewList = new List<CourseView>();
            while (reader.Read())
            {
                CourseView courseView = new CourseView();
                courseView.Code = reader["Code"].ToString();
                courseView.Name = reader["CourseName"].ToString();
                courseView.SemesterName = reader["SemesterName"].ToString();
                if (!reader["TeacherName"].Equals(System.DBNull.Value))
                {
                    courseView.TeacherName = reader["TeacherName"].ToString();
                }
                else
                {
                    courseView.TeacherName = "Yet not assigned";
                }


                courseViewList.Add(courseView);
            }

            reader.Close();
            connection.Close();
            return courseViewList;
        }

    }
}