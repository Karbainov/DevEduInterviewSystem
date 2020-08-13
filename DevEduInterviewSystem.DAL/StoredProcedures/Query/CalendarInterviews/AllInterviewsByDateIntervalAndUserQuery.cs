using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DevEduInterviewSystem.DAL.Shared;
using DevEduInterviewSystem.DAL.DTO.CalendarInterviews;
using DevEduInterviewSystem.DAL.DTO.QueryDTO.CalendarInterviews;

namespace DevEduInterviewSystem.DAL.StoredProcedures.Query.CalendarInterviews
{
    public class AllInterviewsByDateIntervalAndUserQuery
    {
        public List<AllInterviewsByDateIntervalAndUserDTO> SelectAllInterviewsByDateInterval(DateTime startDateTimeInterview, DateTime finishDateTimeInterview, int id)
        {
            SqlConnection Connection = ConnectionSingleTone.GetInstance().Connection;

            Connection.Open();
            SqlCommand command = ReferenceToProcedure("AllInterviewsDateInterval", Connection);

            SqlParameter startDateTimeInterviewParam = new SqlParameter("@StartDateTimeInterview", startDateTimeInterview);
            command.Parameters.Add(startDateTimeInterviewParam);

            SqlParameter finishDateTimeInterviewParam = new SqlParameter("@FinishDateTimeInterview", finishDateTimeInterview);
            command.Parameters.Add(finishDateTimeInterviewParam);

            SqlParameter userParam = new SqlParameter("@UserID", id);
            command.Parameters.Add(userParam);

            List<AllInterviewsByDateIntervalAndUserDTO> allInterviewsIntervalUsers = new List<AllInterviewsByDateIntervalAndUserDTO>();

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows) 
            {
                while (reader.Read()) 
                {
                    AllInterviewsByDateIntervalAndUserDTO allInterviewsIntervalUser = new AllInterviewsByDateIntervalAndUserDTO()
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
                    allInterviewsIntervalUsers.Add(allInterviewsIntervalUser);
                }
            }
            reader.Close();

            return allInterviewsIntervalUsers;
        }
        private SqlCommand ReferenceToProcedure(string sqlExpression, SqlConnection connection)
        {
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            return command;
        }
    }
}

