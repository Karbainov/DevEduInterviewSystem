using System;
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
        public List<AllInterviewsDTO> SelectAllInterviewsByDate(DateTime DateTimeInterview)
        {
            SqlConnection connection = new SqlConnection(ConnectionSingleTone.GetInstance().ConnectionString);
            connection.Open();
            SqlCommand command = ReferenceToProcedure("AllInterviewsByDate", connection);
            SqlParameter dataParam = new SqlParameter("@DateTimeInterview", DateTimeInterview);
            command.Parameters.Add(dataParam);
            SqlDataReader reader = command.ExecuteReader();

            List<AllInterviewsDTO> interviews = new List<AllInterviewsDTO>();

            if (reader.HasRows) 
            {
                while (reader.Read()) 
                {
                    AllInterviewsDTO interview = new AllInterviewsDTO()
                    {
                        UserFirstName = (string)reader["UserFirstName"],
                        UserLastName = (string)reader["UserLastName"],
                        UserLogin = (string)reader["UserLogin"],
                        CandidateID = (int)reader["CandidateID"],
                        CandidateFirstName = (string)reader["CandidateFirstName"],
                        CandidateLastName = (string)reader["CandidateLastName"],
                        CandidatePhone = (string)reader["CandidatePhone"],
                        DateTimeInterview = (DateTime)reader["DateTimeInterview"],
                        Attempt = (int)reader["Attempt"],
                        InterviewStatus = (string)reader["Status"]
                    };
                    interviews.Add(interview);
                }
            }
            reader.Close();

            return interviews;
        }
        private SqlCommand ReferenceToProcedure(string sqlExpression, SqlConnection connection)
        {
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            return command;
        }
    }
}

