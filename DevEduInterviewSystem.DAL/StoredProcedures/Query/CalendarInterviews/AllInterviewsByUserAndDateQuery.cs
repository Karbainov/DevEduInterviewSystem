using DevEduInterviewSystem.DAL.DTO.CalendarInterviews;
using DevEduInterviewSystem.DAL.Shared;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DevEduInterviewSystem.DAL.StoredProcedures.Query.CalendarInterviews
{
    public class AllInterviewsByUserAndDateQuery
    {
        public List<AllInterviewsDTO> SelectAllInterviewsByUserAndDate(DateTime DateTimeInterview, int id)
        {
            SqlConnection connection = new SqlConnection(ConnectionSingleTone.GetInstance().ConnectionString);
            connection.Open();
            SqlCommand command = ReferenceToProcedure("AllInterviewsByUserAndDate", connection);

            SqlParameter finishDateTimeInterviewParam = new SqlParameter("@DateTimeInterview", DateTimeInterview);
            command.Parameters.Add(finishDateTimeInterviewParam);

            SqlParameter userParam = new SqlParameter("@UserID", id);
            command.Parameters.Add(userParam);
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
