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
    public class DepartmentGateway
    {
        private string connectionString =
            WebConfigurationManager.ConnectionStrings["UniversityCRManagementConnectionDB"].ConnectionString;
        SqlConnection connection = new SqlConnection();

        public int SaveDepartment(Department department)
        {
            connection.ConnectionString = connectionString;
            string query = "INSERT INTO Department VALUES(@Code,@Name)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.Add("Code", SqlDbType.VarChar);
            command.Parameters["Code"].Value = department.Code;
            command.Parameters.Add("Name", SqlDbType.VarChar);
            command.Parameters["Name"].Value = department.Name;
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }
        public bool IsDepartmentExists(Department department)
        {
            connection.ConnectionString = connectionString;

            string query = "SELECT * FROM Department WHERE Code =@Code OR Name=@Name";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.Add("Code", SqlDbType.VarChar);
            command.Parameters["Code"].Value = department.Code;
            command.Parameters.Add("Name", SqlDbType.VarChar);
            command.Parameters["Name"].Value = department.Name;
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

        //  GetALLDeaprtments
        public List<Department> GetAllDepartments()
        {
            connection.ConnectionString = connectionString;

            string query = "SELECT * FROM Department Order By Code";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Department> departmentlist = new List<Department>();
            while (reader.Read())
            {
                Department department = new Department();
                department.Id = Convert.ToInt32(reader["Id"].ToString());
                department.Code = reader["Code"].ToString();
                department.Name = reader["Name"].ToString();
                departmentlist.Add(department);
            }

            reader.Close();
            connection.Close();
            return departmentlist;
        }

        /// Get alldepartmentssssss

        public Department GetAllCodebyDeptID(int departmentId)
        {
            connection.ConnectionString = connectionString;
            string query = "SELECT * FROM Department WHERE Id=@departmentId";



            SqlCommand command = new SqlCommand();
            command.CommandText = query;
            command.Connection = connection;
            command.Parameters.Add("departmentId", SqlDbType.Int);
            command.Parameters["departmentId"].Value = departmentId;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            //List<Teacher> teacherList = new List<Teacher>();

            Department department = new Department();
            while (reader.Read())
            {

                department.Id = (int)reader["Id"];
                department.Name = reader["Name"].ToString();
                department.Code = reader["Code"].ToString();

            }
            reader.Close();
            connection.Close();
            return department;
        }

        public List<Course> GetAllCourseNameByStudentRegNo(string regNo)
        {
            connection.ConnectionString = connectionString;

            string query = "SELECT Course.Id, Course.Name AS CourseName FROM Course INNER JOIN Student ON Course.DepartmentId= Student.DepartmentId WHERE Student.RegNo= '" + regNo + "'";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Course> courselist = new List<Course>();
            while (reader.Read())
            {

                Course course = new Course();
                course.Id = Convert.ToInt32(reader["Id"].ToString());
                course.Name = reader["CourseName"].ToString();
                courselist.Add(course);
            }

            reader.Close();
            connection.Close();
            return courselist;
        }

        public List<Course> GetAllCourseNameByRegNo(string regNo)
        {
            connection.ConnectionString = connectionString;

            string query = "SELECT Course.Id, Course.Name AS CourseName FROM Course INNER JOIN EnrollCourse ON Course.Id=EnrollCourse.CourseId INNER JOIN  Student ON EnrollCourse.RegNo= Student.RegNo WHERE Student.RegNo= '" + regNo + "'";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Course> courselist = new List<Course>();
            while (reader.Read())
            {

                Course course = new Course();
                course.Id = Convert.ToInt32(reader["Id"].ToString());
                course.Name = reader["CourseName"].ToString();
                courselist.Add(course);
            }

            reader.Close();
            connection.Close();
            return courselist;
        }
        }
    }
