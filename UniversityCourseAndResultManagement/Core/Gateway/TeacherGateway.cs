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

            string query = "INSERT INTO Teacher (Name,Address,Email,ContactNo,DesignationId,DepartmentId,Credit,RemainCredit) VALUES(@Name,@Address,@Email,@ContactNo,@DesignationId,@DepartmentId,@Credit,@RemainCredit)";

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
            command.Parameters.Add("RemainCredit", SqlDbType.Int);
            command.Parameters["RemainCredit"].Value = teacher.Credit;


            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public List<Teacher> GetAllTeacherbyDeptID(int Id)
        {
            connection.ConnectionString = connectionString;
            string query = "SELECT * FROM Teacher WHERE DepartmentId=@Id";


         
            SqlCommand command = new SqlCommand();
            command.CommandText = query;
            command.Connection = connection;
            command.Parameters.Add("Id", SqlDbType.Int);
            command.Parameters["Id"].Value = Id;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Teacher> teacherList= new List<Teacher>();
           

            while (reader.Read())
            {
              Teacher  teacher = new Teacher();
                teacher.Id = (int)reader["Id"];
                teacher.Name = reader["Name"].ToString();
                teacher.Credit =(int) reader["Credit"];
                teacher.RemainCredit = (int)reader["RemainCredit"];
                teacherList.Add(teacher);
            }
            reader.Close();
            connection.Close();
            return teacherList;
        }

        public Teacher GetTeacherInfoById(int teacherId)
        {
            connection.ConnectionString = connectionString;
            string query = "SELECT * FROM Teacher WHERE Id=@teacherId";



            SqlCommand command = new SqlCommand();
            command.CommandText = query;
            command.Connection = connection;
            command.Parameters.Add("teacherId", SqlDbType.Int);
            command.Parameters["teacherId"].Value = teacherId;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            //List<Teacher> teacherList = new List<Teacher>();

            Teacher teacher = new Teacher();
            while (reader.Read())
            {
                
                teacher.Id = (int)reader["Id"];
                teacher.Credit = (int)reader["Credit"];
                teacher.RemainCredit = (int)reader["RemainCredit"];
                
            }
            reader.Close();
            connection.Close();
            return teacher;
        }
    }
}