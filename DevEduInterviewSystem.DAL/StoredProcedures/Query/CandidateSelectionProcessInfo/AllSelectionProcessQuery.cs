
using DevEduInterviewSystem.DAL.DTO.QueryDTO.CandidateSelectionProcessInfoDTO;
using DevEduInterviewSystem.DAL.Shared;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DevEduInterviewSystem.DAL.StoredProcedures.Query.CandidateSelectionProcessInfo
{
    public class AllSelectionProcessQuery
    {
        public List<AllSelectionProcessDTO> SelectAllByCandidates()
        {
            SqlConnection Connection = new SqlConnection(ConnectionSingleTone.GetInstance().ConnectionString);
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("AllSelectionProcess", Connection);
            SqlDataReader reader = command.ExecuteReader();

            List<AllSelectionProcessDTO> candidates = new List<AllSelectionProcessDTO>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    AllSelectionProcessDTO candidate = new AllSelectionProcessDTO()
                    {                
                        FirstName = (string)reader["CandidateFirstName"],
                        LastName = (string)reader["CandidateLastName"],
                        Status = (string)reader["Status"],
                        Stage = (string)reader["Stage"],
                        Course = (string)reader["Course"]

                    };
                    candidates.Add(candidate);
                }
            }
            reader.Close();
            return candidates;
        }

        private SqlCommand ReferenceToProcedure(string sqlExpression, SqlConnection connection)
        {
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            return command;
        }
    }
}
