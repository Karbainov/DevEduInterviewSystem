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
        public List<AllInterviewsByUserDTO> SelectAllByUser(int id)
        {
            SqlConnection connection = ConnectionSingleTone.GetInstance().Connection;
            connection.Open();
            SqlCommand command = ReferenceToProcedure("AllInterviewsByUser", connection);
            SqlParameter userParam = new SqlParameter("@UserID", id);
            command.Parameters.Add(userParam);
            SqlDataReader reader = command.ExecuteReader();

            List<AllInterviewsByUserDTO> interviews = new List<AllInterviewsByUserDTO>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    AllInterviewsByUserDTO interview = new AllInterviewsByUserDTO()
                    {
                        UserFirstName = (string)reader["UserFirstName"],
                        UserLastName = (string)reader["UserLastName"],
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
