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
    public class CourseScheduleGateway
    {

         private string connectionString =
         WebConfigurationManager.ConnectionStrings["UniversityCRManagementConnectionDB"].ConnectionString;
        SqlConnection connection = new SqlConnection();
        public List<CourseSchedule> GetAllCourseScheduleByDepartment(int deptId)
        {
            connection.ConnectionString = connectionString;

            string query = "SELECT  CourseCode,CourseName,ScheduleInfo FROM ClassSchedule12 WHERE (DepartmentId=@DepartmentId) order by CourseCode";
           
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Add("DepartmentId", SqlDbType.Int);
            command.Parameters["DepartmentId"].Value = deptId;
           
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<CourseSchedule> courseScheduleList = new List<CourseSchedule>();
            while (reader.Read())
            {
                CourseSchedule courseSchedule=new CourseSchedule();
                courseSchedule.CourseCode = reader["CourseCode"].ToString();
                courseSchedule.CourseName= reader["CourseName"].ToString();


                if (!reader["ScheduleInfo"].Equals(System.DBNull.Value))
                {
                    courseSchedule.ScheduleInfo= reader["ScheduleInfo"].ToString();
                    // courseSchedule.Day = reader["Day"].ToString();
                    //courseSchedule.TimeStart =Convert.ToDateTime(reader["TimeStart"]);
                    //courseSchedule.TimeEnd= Convert.ToDateTime(reader["TimeEnd"]);

                    //courseSchedule.ScheduleInfo = reader["ScheduleInfo"].ToString();
                    //courseSchedule.TimeEnd= reader["TimeEnd"].ToString();
                }
                else
                {
                    courseSchedule.ScheduleInfo ="Not Assigned Yet";
                }
                
               


                courseScheduleList.Add(courseSchedule);
            }

            reader.Close();
            connection.Close();
            return courseScheduleList;
        }
        

    }
     
    }
    
