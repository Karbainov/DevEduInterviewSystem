using DevEduInterviewSystem.DAL.DTO;
using DevEduInterviewSystem.DAL.DTO.CalendarInterviews;
using DevEduInterviewSystem.DAL.Shared;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DevEduInterviewSystem.DAL.StoredProcedures.Query.CalendarInterviews
{
    public class AllInterviewsByUserQuery
    {
        SqlConnection connection = new SqlConnection(PrimerConnection.ConnectionString);
        public List<AllInterviewsByUserDTO> SelectAll()
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("AllInterviewsByUser", connection);

            SqlDataReader reader = command.ExecuteReader();

            List<AllInterviewsByUserDTO> interviews = new List<AllInterviewsByUserDTO>();

            if (reader.HasRows) // если есть данные
            {
                while (reader.Read()) // построчно считываем данные
                {
                    AllInterviewsByUserDTO interview = new AllInterviewsByUserDTO()
                    {
                        UserFirstName = (string)reader["U.[FirstName]"],
                        UserLastName = (string)reader["U.[LastName]"],
                        IDCandidate = (int)reader["C.[ID]"],
                        CandidateFirstName = (string)reader["C.[FirstName]"],
                        CandidateLastName = (string)reader["C.[LastName]"],
                        CandidatePhone = (string)reader["C.[Phone]"],
                        DateTimeInterview = (DateTime)reader["I.[DateTimeInterview]"],
                        Attempt = (int)reader["I.[Attempt]"],
                        InterviewStatus = (string)reader["ISt.[Name]"]
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
