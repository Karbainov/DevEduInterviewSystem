﻿using DevEduInterviewSystem.DAL.DTO.QuereDTO;
using DevEduInterviewSystem.DAL.Shared;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DevEduInterviewSystem.DAL.StoredProcedures.Query
{
    public class AllCandidateOfCourseQuery
    {
        public List<AllCandidateOfCourseDTO> SelectAllAllCandidateOfCourse(int id)
        {
            SqlConnection Connection = new SqlConnection(ConnectionSingleTone.GetInstance().ConnectionString); 
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("AllCandidateOfCourse", Connection);
            SqlParameter courseParam = new SqlParameter("@CourseID", id);
            command.Parameters.Add(courseParam);

            List<AllCandidateOfCourseDTO> allCandidateOfAllCourses = new List<AllCandidateOfCourseDTO>();

            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    AllCandidateOfCourseDTO allCandidateOfAllCourse = new AllCandidateOfCourseDTO()
                    {
                        Name = (string)reader["Name"]
                    };

                    allCandidateOfAllCourses.Add(allCandidateOfAllCourse);
                }
            }
            reader.Close();

            return allCandidateOfAllCourses;

        }
        private SqlCommand ReferenceToProcedure(string sqlExpression, SqlConnection connection)
        {
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            return command;
        }
    }
}


