using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DevEduInterviewSystem.DAL.DTO;
using DevEduInterviewSystem.DAL.Shared;
using DevEduInterviewSystem.DAL.DTO.CalendarInterviews;
using DevEduInterviewSystem.DAL.DTO.QueryDTO.CalendarInterviews;

namespace DevEduInterviewSystem.DAL.StoredProcedures.Query.CalendarInterviews
{
    public class AllInterviewsByDateQuery
    {       
        public List<AllInterviewsByDateDTO> SelectAllInterviewsByDate(DateTime DateTimeInterview)
        {
            SqlConnection connection = new SqlConnection(PrimerConnection.ConnectionString);

            connection.Open();
            SqlCommand command = ReferenceToProcedure("AllInterviewsByDate", connection);
            SqlParameter dataParam = new SqlParameter("@DateTimeInterview", DateTimeInterview);
            command.Parameters.Add(dataParam);
            SqlDataReader reader = command.ExecuteReader();

            List<AllInterviewsByDateDTO> interviews = new List<AllInterviewsByDateDTO>();

            if (reader.HasRows) 
            {
                while (reader.Read()) 
                {
                    AllInterviewsByDateDTO interview = new AllInterviewsByDateDTO()
                    {
                        UserFirstName = (string)reader["FirstName"],
                        UserLastName = (string)reader["LastName"],
                        UserLogin = (string)reader["Login"],
                        CandidateID = (int)reader["ID"],
                        CandidateFirstName = (string)reader["FirstName"],
                        CandidateLastName = (string)reader["LastName"],
                        CandidatePhone = (string)reader["Phone"],
                        DateTimeInterview = (DateTime)reader["DateTimeInterview"],
                        Attempt = (int)reader["Attempt"],
                        Status = (string)reader["Name"]
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

