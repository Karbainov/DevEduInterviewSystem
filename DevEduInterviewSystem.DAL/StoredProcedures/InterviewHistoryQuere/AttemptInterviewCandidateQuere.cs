using DevEduInterviewSystem.DAL.DTO.InterviewHistoryDTO;
using DevEduInterviewSystem.DAL.Shared;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DevEduInterviewSystem.DAL.StoredProcedures.InterviewHistoryQuere
{
    public class AttemptInterviewCandidateQuere
    {
        SqlConnection Connection = new SqlConnection(PrimerConnection.ConnectionString);
        public AtteptsInterviewCandidateDTO AtteptsInterviewCandidate(int CandidateID)
        {

            Connection.Open();
            SqlCommand command = ReferenceToProcedure("AtteptsInterviewCandidate", Connection);

            SqlParameter IDParam = new SqlParameter("@ID", CandidateID);
            command.Parameters.Add(IDParam);

            SqlDataReader reader = command.ExecuteReader();
            AtteptsInterviewCandidateDTO candidate = new AtteptsInterviewCandidateDTO();

            if (reader.HasRows) 
            {
                while (reader.Read()) 
                {
                    candidate.CandidateFirstName = (string)reader["FirstName"];
                    candidate.CandidateLastName = (string)reader["LastName"];
                    candidate.AttemptInterview = (int)reader["Attempt"];
                    

                }
            }
            reader.Close();

            return candidate;
        }
        protected SqlCommand ReferenceToProcedure(string sqlExpression, SqlConnection connection)
        {
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            return command;
        }
    }
}
