﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DevEduInterviewSystem.DAL.Shared;
using DevEduInterviewSystem.DAL.DTO.CalendarInterviews;


namespace DevEduInterviewSystem.DAL.StoredProcedures.Query.CalendarInterviews
{
    public class AllInterviewsQuery
    {
        public List<AllInterviewsDTO> SelectAllInterviews()
        {
            SqlConnection Connection = ConnectionSingleTone.GetInstance().Connection;

            Connection.Open();
            SqlCommand command = ReferenceToProcedure("AllInterviews", Connection);

            List<AllInterviewsDTO> allInterviews = new List<AllInterviewsDTO>();

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows) // если есть данные
            {
                while (reader.Read()) // построчно считываем данные
                {
                    AllInterviewsDTO allInterview = new AllInterviewsDTO()
                    {
                        UserFirstName = (string)reader["FirstName"],
                        UserLastName = (string)reader["LastName"],
                        IDCandidate = (int)reader["ID"],
                        CandidateFirstName = (string)reader["FirstName"],
                        CandidateLastName = (string)reader["LastName"],
                        CandidatePhone = (string)reader["Phone"],
                        DateTimeInterview = (DateTime)reader["DateTimeInterview"],
                        Attempt = (int)reader["Attempt"],
                        InterviewStatus = (string)reader["Name"]
                    };
                    allInterviews.Add(allInterview);
                }
            }
            reader.Close();

            return allInterviews;
        }
        private SqlCommand ReferenceToProcedure(string sqlExpression, SqlConnection connection)
        {
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            return command;
        }
    }
}
