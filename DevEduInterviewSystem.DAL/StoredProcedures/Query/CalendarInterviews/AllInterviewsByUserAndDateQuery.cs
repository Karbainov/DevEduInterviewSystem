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
        public List<AllInterviewsByUserAndDateDTO> SelectAllInterviewsByUserAndDate(int userid, DateTime date)
        {
            SqlConnection connection = ConnectionSingleTone.GetInstance().Connection;
            connection.Open();
            SqlCommand command = ReferenceToProcedure("AllInterviewsByUserAndDate", connection);
            
            SqlParameter userParam = new SqlParameter("@UserID", userid);
            command.Parameters.Add(userParam);
            SqlParameter dateParam = new SqlParameter("@DateTimeInterview", date);
            command.Parameters.Add(dateParam);
            SqlDataReader reader = command.ExecuteReader();

            List<AllInterviewsByUserAndDateDTO> interviews = new List<AllInterviewsByUserAndDateDTO>();

            if (reader.HasRows) // если есть данные
            {
                while (reader.Read()) // построчно считываем данные
                {
                    AllInterviewsByUserAndDateDTO interview = new AllInterviewsByUserAndDateDTO()
                    {
                        UserFirstName = (string)reader["FirstName"],
                        UserLastName = (string)reader["LastName"],
                        DateTimeInterview = (DateTime)reader["DateTimeInterview"],
                        IDCandidate = (int)reader["ID"],
                        CandidateFirstName = (string)reader["FirstName"],
                        CandidateLastName = (string)reader["LastName"],
                        CandidatePhone = (string)reader["Phone"],
                        Attempt = (int)reader["Attempt"],
                        InterviewStatus = (string)reader["Name"]
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
