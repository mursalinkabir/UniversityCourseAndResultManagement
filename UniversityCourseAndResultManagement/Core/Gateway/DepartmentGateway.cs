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
            SqlConnection connection=new SqlConnection();

        public int SaveDepartment(Department department)
        {
            connection.ConnectionString = connectionString;
            string query = "INSERT INTO Department VALUES(@Code,@Name)";
            SqlCommand command=new SqlCommand(query,connection);
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
                Department department=new Department();
                department.Code = reader["Code"].ToString();
                department.Name = reader["Name"].ToString();
                departmentlist.Add(department);
            }

            reader.Close();
            connection.Close();
            return departmentlist;
        }
    }
}