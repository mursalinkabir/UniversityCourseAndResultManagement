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
    public class StudentGateway
    {
        private string connectionString =
           WebConfigurationManager.ConnectionStrings["UniversityCRManagementConnectionDB"].ConnectionString;
        SqlConnection connection = new SqlConnection();
        public int Save(Student student)
        {

            Department department = new Department();
            connection.ConnectionString = connectionString;

            string query = "INSERT INTO Student(Name,Email,ContactNo,Date,Address,DepartmentId,DepartmentCode) VALUES(@Name,@Email,@ContactNo,@Date,@Address,@DepartmentId,@DepartmentCode)";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.Add("Name", SqlDbType.VarChar);
            command.Parameters["Name"].Value = student.Name;
            //command.Parameters.Add("RegNo", SqlDbType.VarChar);
            //command.Parameters["RegNo"].Value = student.Date.ToString("yyyy") + "-" + student.ContactNo + "-" + student.Id;
            command.Parameters.Add("Email", SqlDbType.VarChar);
            command.Parameters["Email"].Value = student.Email;
            command.Parameters.Add("ContactNo", SqlDbType.VarChar);
            command.Parameters["ContactNo"].Value = student.ContactNo;
            command.Parameters.Add("Date", SqlDbType.DateTime);
            command.Parameters["Date"].Value = student.Date;
            command.Parameters.Add("Address", SqlDbType.VarChar);
            command.Parameters["Address"].Value = student.Address;
            command.Parameters.Add("DepartmentId", SqlDbType.Int);
            command.Parameters["DepartmentId"].Value = student.DepartmentId;
            command.Parameters.Add("DepartmentCode", SqlDbType.VarChar);
            command.Parameters["DepartmentCode"].Value = student.DepartmentCode;


            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public bool IsEmailExists(Student student)
        {
            connection.ConnectionString = connectionString;
            string query = "SELECT * FROM Student WHERE (Email=@Email)";

            SqlCommand command = new SqlCommand();
            command.CommandText = query;
            command.Connection = connection;
            command.Parameters.Add("Email", SqlDbType.VarChar);
            command.Parameters["Email"].Value = student.Email;



            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            bool isEmailExist = false;

            if (reader.HasRows)
            {
                isEmailExist = true;
            }
            connection.Close();

            return isEmailExist;
        }

        public StudentView GetAllStudent(string Email)
        {
            connection.ConnectionString = connectionString;

            string query = "SELECT Student.Name,Student.Email,Student.ContactNo,Student.Date,Student.Address,Student.RegNo,Department.Name AS DepartmentName FROM Student INNER JOIN Department ON Student.DepartmentId= Department.Id WHERE Student.Email= '" + Email + "'";

            SqlCommand command = new SqlCommand(query, connection);


            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            StudentView student = new StudentView();
            while (reader.Read())
            {

                //student.Id = (int)reader["Id"];
                student.Name = reader["Name"].ToString();
                student.Email = reader["Email"].ToString();
                student.ContactNo = reader["ContactNo"].ToString();
                student.Date = Convert.ToDateTime(reader["Date"].ToString());
                student.Address = reader["Address"].ToString();
                student.RegNo = reader["RegNo"].ToString();
                student.DepartmentName = reader["DepartmentName"].ToString();




            }

            reader.Close();
            connection.Close();
            return student;
        }
    }
}