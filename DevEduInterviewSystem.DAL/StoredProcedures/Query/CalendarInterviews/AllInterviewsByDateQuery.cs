﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DevEduInterviewSystem.DAL.DTO;
using DevEduInterviewSystem.DAL.Shared;
using DevEduInterviewSystem.DAL.DTO.CalendarInterviews;




namespace DevEduInterviewSystem.DAL.StoredProcedures.Query.CalendarInterviews
{
    public class AllInterviewsByDateQuery
    {       
        //public List<AllInterviewsDTO> SelectAllInterviewsByDate(DateTime DateTimeInterview)
        //{
        //    //SqlConnection connection = new SqlConnection(PrimerConnection.ConnectionString);

        //    //connection.Open();
        //    //SqlCommand command = ReferenceToProcedure("AllInterviewsDate", connection);
        //    //SqlParameter dataParam = new SqlParameter("@DateTimeInterview", DateTimeInterview);
        //    //command.Parameters.Add(dataParam);
        //    //SqlDataReader reader = command.ExecuteReader();

        //    //List<AllInterviewsDTO> interviews = new List<AllInterviewsDTO>();

        //    //if (reader.HasRows) // если есть данные
        //    //{
        //    //    while (reader.Read()) // построчно считываем данные
        //    //    {
        //    //        AllInterviewsDTO interview = new AllInterviewsDTO()
        //    //        {
        //    //            UserFirstName = (string)reader["FirstName"],
        //    //            UserLastName = (string)reader["LastName"],
        //    //            IDCandidate = (int)reader["ID"],
        //    //            CandidateFirstName = (string)reader["FirstName"],
        //    //            CandidateLastName = (string)reader["LastName"],
        //    //            CandidatePhone = (string)reader["Phone"],
        //    //            DateTimeInterview = (DateTime)reader["DateTimeInterview"],
        //    //            Attempt = (int)reader["Attempt"],
        //    //            InterviewStatus = (string)reader["Name"]
        //    //        };
        //    //        interviews.Add(interview);
        //    //    }
        //    //}
        //    //reader.Close();

        //    //return interviews;
        //}
        private SqlCommand ReferenceToProcedure(string sqlExpression, SqlConnection connection)
        {
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            return command;
        }
    }
}

