using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityCourseAndResultManagement.Models;

namespace UniversityCourseAndResultManagement.Core.Gateway
{
    public class DesignationGateway
    {
        private string connectionString =
            WebConfigurationManager.ConnectionStrings["UniversityCRManagementConnectionDB"].ConnectionString;
        SqlConnection connection = new SqlConnection();
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