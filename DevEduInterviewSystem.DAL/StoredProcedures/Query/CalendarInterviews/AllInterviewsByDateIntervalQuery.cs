using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DevEduInterviewSystem.DAL.Shared;
using DevEduInterviewSystem.DAL.DTO.CalendarInterviews;
using DevEduInterviewSystem.DAL.DTO.QueryDTO.CalendarInterviews;

namespace DevEduInterviewSystem.DAL.StoredProcedures.Query.CalendarInterviews
{
    public class AllInterviewsByDateIntervalQuery
    {
        public List<AllInterviewsByDateIntervalDTO> SelectAllInterviewsByDateInterval(DateTime startDateTimeInterview, DateTime finishDateTimeInterview)
        {
            SqlConnection Connection = ConnectionSingleTone.GetInstance().Connection;

            Connection.Open();
            SqlCommand command = ReferenceToProcedure("AllInterviewsByDateInterval", Connection);

            SqlParameter startDateTimeInterviewParam = new SqlParameter("@StartDateTimeInterview", startDateTimeInterview);
            command.Parameters.Add(startDateTimeInterviewParam);

            SqlParameter finishDateTimeInterviewParam = new SqlParameter("@FinishDateTimeInterview", finishDateTimeInterview);
            command.Parameters.Add(finishDateTimeInterviewParam);

            List<AllInterviewsByDateIntervalDTO> allInterviewsIntervals = new List<AllInterviewsByDateIntervalDTO>();

            SqlDataReader reader = command.ExecuteReader();
            
            if (reader.HasRows) 
            {
                while (reader.Read()) 
                {
                    AllInterviewsByDateIntervalDTO allInterviewsInterval = new AllInterviewsByDateIntervalDTO()
                    {
                        UserFirstName = (string)reader["FirstName"],
                        UserLastName = (string)reader["LastName"],
                        CandidateID = (int)reader["ID"],
                        CandidateFirstName = (string)reader["FirstName"],
                        CandidateLastName = (string)reader["LastName"],
                        CandidatePhone = (string)reader["Phone"],
                        DateTimeInterview = (DateTime)reader["DateTimeInterview"],
                        Attempt = (int)reader["Attempt"],
                        Status = (string)reader["Name"]
                    };
                    allInterviewsIntervals.Add(allInterviewsInterval);
                }
            }
            reader.Close();

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
