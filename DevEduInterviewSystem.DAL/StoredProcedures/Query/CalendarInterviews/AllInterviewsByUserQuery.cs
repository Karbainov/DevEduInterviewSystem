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
                        IDCandidate = (int)reader["CandidateID"],
                        CandidateFirstName = (string)reader["CandidateFirstName"],
                        CandidateLastName = (string)reader["CandidateLastName"],
                        CandidatePhone = (string)reader["CandidatePhone"],
                        DateTimeInterview = (DateTime)reader["DateTimeInterview"],
                        Attempt = (int)reader["Attempt"],
                        InterviewStatus = (string)reader["Status"]
                    };
                    interviews.Add(interview);

                    Console.WriteLine($"{interview.UserFirstName} \t{interview.UserLastName} \t{interview.IDCandidate} \t{interview.CandidateFirstName}" +
                        $"\t{interview.CandidateLastName} \t{interview.CandidatePhone} \t{interview.DateTimeInterview} \t{interview.Attempt} \t{interview.InterviewStatus}");
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
