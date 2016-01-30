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

            string query = "INSERT INTO Course (Code,Name,Credit,Description,DepartmentId,SemesterId) VALUES(@Code,@Name,@Credit,@Description,@DepartmentId,@SemesterId)";

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
        //change by sayed
        public List<Course> GetAllCoursesByDepartment(int deptId)
        {
            //connection.ConnectionString = connectionString;

            //string query = "SELECT * FROM CourseStatics WHERE (DepartmentId=@DepartmentId)";
            //SqlCommand command = new SqlCommand(query, connection);

            //command.Parameters.Add("DepartmentId", SqlDbType.Int);
            //command.Parameters["DepartmentId"].Value = deptId;
            //connection.Open();
            //SqlDataReader reader = command.ExecuteReader();
            //List<Course> courselist = new List<Course>();
            //while (reader.Read())
            //{
            //    Course course = new Course();
            //    course.Code = reader["Code"].ToString();
            //    course.Name = reader["CourseName"].ToString();
            //    course.SemesterName = reader["SemesterName"].ToString();
            //    if (!reader["TeacherName"].Equals(System.DBNull.Value))
            //    {
            //        course.TeacherName = reader["TeacherName"].ToString();
            //    }
            //    else
            //    {
            //        course.TeacherName = "Yet not assigned";
            //    }


            //    courselist.Add(course);
            //}

            //reader.Close();
            //connection.Close();
            return null;
        }
        //change by sayed
        public List<Course> GetAllCoursebyDeptId(int departmentId)
        {
            connection.ConnectionString = connectionString;

            string query = "SELECT * FROM Course WHERE (DepartmentId=@DepartmentId)";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add("DepartmentId", SqlDbType.Int);
            command.Parameters["DepartmentId"].Value = departmentId;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Course> courselist = new List<Course>();
            while (reader.Read())
            {
                Course course = new Course();
                course.Id =(int) reader["id"];
                course.Code = reader["Code"].ToString();
                course.Name = reader["Name"].ToString();
                course.Credit = (decimal) reader["Credit"];
          


                courselist.Add(course);
            }

            reader.Close();
            connection.Close();

            return courselist;
        }

        public Course GetCourseInfoById(int courseId)
        {
            connection.ConnectionString = connectionString;
            string query = "SELECT * FROM Course WHERE id=@courseId";



            SqlCommand command = new SqlCommand();
            command.CommandText = query;
            command.Connection = connection;
            command.Parameters.Add("courseId", SqlDbType.Int);
            command.Parameters["courseId"].Value = courseId;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            //List<Teacher> teacherList = new List<Teacher>();

            Course course = new Course();
            while (reader.Read())
            {

                course.Credit = (decimal)reader["Credit"];
                course.Name = reader["Name"].ToString();

            }
            reader.Close();
            connection.Close();
            return course;
        }

        public int AssignTeachertoCourse(int teacherId, string Name)
        {
            connection.ConnectionString = connectionString;
            //string query = "INSERT INTO Course (TeacherId) VALUES(@TeacherId) WHERE Code=@Code";
            string query = "UPDATE Course SET TeacherId=@TeacherId WHERE Name=@Name;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.Add("TeacherId", SqlDbType.Int);
            command.Parameters["TeacherId"].Value = teacherId;
            command.Parameters.Add("Name", SqlDbType.VarChar);
            command.Parameters["Name"].Value = Name;

            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public List<ViewResults> GetAllResult(string regNo)
        {
            connection.ConnectionString = connectionString;

            string query = "SELECT Course.Code AS CourseCode,Course.Name AS CourseName, Grade FROM Course INNER JOIN EnrollCourse ON Course.Id= EnrollCourse.CourseId LEFT JOIN  StudentResult ON EnrollCourse.RegNo= StudentResult.RegNo  WHERE EnrollCourse.RegNo= '" + regNo + "'";

            //string query = "SELECT Course.Code AS CourseCode,Course.Name AS CourseName FROM Course INNER JOIN EnrollCourse ON Course.Id= EnrollCourse.CourseId  WHERE EnrollCourse.RegNo= '" + regNo + "'";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<ViewResults> viewResults = new List<ViewResults>();
            while (reader.Read())
            {

                ViewResults viewresults = new ViewResults();
                //viewresults.Id = Convert.ToInt32(reader["Id"].ToString());
                viewresults.CourseCode = reader["CourseCode"].ToString();
                viewresults.CourseName = reader["CourseName"].ToString();
                if (!reader["Grade"].Equals(System.DBNull.Value))
                {
                    viewresults.Grade = reader.GetString(reader.GetOrdinal("Grade"));
                }
                else
                {
                    viewresults.Grade = "Not Graded Yet ";
                }
                //viewresults.Grade = reader["Grade"].ToString();
                viewResults.Add(viewresults);
            }

            reader.Close();
            connection.Close();
            return viewResults;
        }
    }
}