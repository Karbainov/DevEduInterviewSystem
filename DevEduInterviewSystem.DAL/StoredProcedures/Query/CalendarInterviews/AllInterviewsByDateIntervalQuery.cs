using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DevEduInterviewSystem.DAL.Shared;
using DevEduInterviewSystem.DAL.DTO.CalendarInterviews;

namespace DevEduInterviewSystem.DAL.StoredProcedures.Query.CalendarInterviews
{
    public class AllInterviewsByDateIntervalQuery
    {
        public List<AllInterviewsDTO> SelectAllInterviewsByDateInterval(DateTime startDateTimeInterview, DateTime finishDateTimeInterview)
        {
            SqlConnection Connection = new SqlConnection(ConnectionSingleTone.GetInstance().ConnectionString);

            Connection.Open();
            SqlCommand command = ReferenceToProcedure("AllInterviewsByDateInterval", Connection);

            SqlParameter startDateTimeInterviewParam = new SqlParameter("@StartDateTimeInterview", startDateTimeInterview);
            command.Parameters.Add(startDateTimeInterviewParam);

            SqlParameter finishDateTimeInterviewParam = new SqlParameter("@FinishDateTimeInterview", finishDateTimeInterview);
            command.Parameters.Add(finishDateTimeInterviewParam);

            List<AllInterviewsDTO> allInterviewsIntervals = new List<AllInterviewsDTO>();

            SqlDataReader reader = command.ExecuteReader();
            
            if (reader.HasRows) 
            {
                while (reader.Read()) 
                {
                    AllInterviewsDTO allInterviewsInterval = new AllInterviewsDTO()
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
                        InterviewStatus = (string)reader["Name"]
                    };
                    allInterviewsIntervals.Add(allInterviewsInterval);
                }
            }
            reader.Close();
            Connection.Close();
            return allInterviewsIntervals;
        }
        private SqlCommand ReferenceToProcedure(string sqlExpression, SqlConnection connection)
        {
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            return command;
        }
    }
}
