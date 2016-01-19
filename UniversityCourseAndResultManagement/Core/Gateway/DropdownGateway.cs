﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityCourseAndResultManagement.Models;

namespace UniversityCourseAndResultManagement.Core.Gateway
{
    public class DropdownGateway
    {
        private string connectionString =
            WebConfigurationManager.ConnectionStrings["UniversityCRManagementConnectionDB"].ConnectionString;
        SqlConnection connection = new SqlConnection();
        public List<Semester> GetAllSemester()
        {
            connection.ConnectionString = connectionString;

            string query = "SELECT * FROM Semester";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Semester> semesterlist = new List<Semester>();
            while (reader.Read())
            {
                
                Semester semester=new Semester();
                semester.Id = Convert.ToInt32(reader["Id"].ToString());
                
               semester.Name = reader["Name"].ToString();
               semesterlist.Add(semester);
            }

            reader.Close();
            connection.Close();
            return semesterlist;
        }

        public List<Designation> GetAllDesignations()
        {
            connection.ConnectionString = connectionString;

            string query = "SELECT * FROM Designation";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Designation> designationlist = new List<Designation>();
            while (reader.Read())
            {

                Designation designation = new Designation();
                designation.Id = Convert.ToInt32(reader["Id"].ToString());

                designation.Name = reader["Name"].ToString();
                designationlist.Add(designation);
            }

            reader.Close();
            connection.Close();
            return designationlist;
        }
    }
}