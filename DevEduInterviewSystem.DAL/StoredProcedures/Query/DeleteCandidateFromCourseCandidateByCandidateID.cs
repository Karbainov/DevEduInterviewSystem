using DevEduInterviewSystem.DAL.DTO.QuereDTO;
using DevEduInterviewSystem.DAL.Shared;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DevEduInterviewSystem.DAL.StoredProcedures.Query
{
    public class DeleteCandidateFromCourseCandidateByCandidateID
    {
        public int DeleteCandidateFromCourseByCandidateID(int id)
        {
            SqlConnection connection = new SqlConnection(ConnectionSingleTone.GetInstance().ConnectionString);
            connection.Open();
            SqlCommand command = ReferenceToProcedure("DeleteCandidateFromCourseCandidateByCandidateID", connection);

            SqlParameter IDParam = new SqlParameter("@CandidateID", id);
            command.Parameters.Add(IDParam);

            int a = command.ExecuteNonQuery();
            connection.Close();
            return a;
        }
        private SqlCommand ReferenceToProcedure(string sqlExpression, SqlConnection connection)
        {
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            return command;
        }
    }
}
