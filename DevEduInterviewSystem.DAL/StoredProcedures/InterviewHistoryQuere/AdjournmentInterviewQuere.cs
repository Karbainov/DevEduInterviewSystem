using DevEduInterviewSystem.DAL.DTO.InterviewHistoryDTO;
using DevEduInterviewSystem.DAL.Shared;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DevEduInterviewSystem.DAL.StoredProcedures.InterviewHistoryQuere
{
    public class AdjournmentInterviewQuere
    {
        

            SqlConnection Connection = new SqlConnection(PrimerConnection.ConnectionString);
            public int AdjournmentInterview(int id)
            {

                Connection.Open();
                SqlCommand command = ReferenceToProcedure("AdjournmentInterview", Connection);

                SqlParameter IDParam = new SqlParameter("@ID", id);
                command.Parameters.Add(IDParam);
                int count = 0;
                SqlDataReader reader = command.ExecuteReader();
                AdjournmentInterviewDTO adjournment = new AdjournmentInterviewDTO();

                if (reader.HasRows) 
                {
                    while (reader.Read())
                    {
                    
                        adjournment.CandidateID = (int)reader["CandidateID"];
                        adjournment.CandidateFirstName = (string)reader["FirstName"];
                        adjournment.CandidateLastName = (string)reader["LastName"];
                        adjournment.Adjournment = (int)reader["Adjournment"];
                        count++;
                    }
                }
                reader.Close();

                return count;

            }
        protected SqlCommand ReferenceToProcedure(string sqlExpression, SqlConnection connection)
        {
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            return command;
        }
    }
}
