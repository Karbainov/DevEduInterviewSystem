using DevEduInterviewSystem.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DevEduInterviewSystem.DAL.StoredProcedures.CRUD
{
    public class CandidateCRUD
    {
        public int AddCandidate(SqlConnection connection, CandidateDTO candidate)
        {
            connection.Open();
            string sqlExpression = "AddCandidate";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter StageParam = new SqlParameter("@StageID", candidate.StageID);
            command.Parameters.Add(StageParam);

            SqlParameter StatusParam = new SqlParameter("@StatusID", candidate.StatusID);
            command.Parameters.Add(StatusParam);

            SqlParameter CityParam = new SqlParameter("@CityID", candidate.CityID);
            command.Parameters.Add(CityParam);

            SqlParameter PhoneParam = new SqlParameter("@Phone", candidate.Phone);
            command.Parameters.Add(PhoneParam);

            SqlParameter EmailParam = new SqlParameter("@Email", candidate.Email);
            command.Parameters.Add(EmailParam);

            SqlParameter FirstNameParam = new SqlParameter("@FirstName", candidate.FirstName);
            command.Parameters.Add(FirstNameParam);

            SqlParameter LastNameParam = new SqlParameter("@LastName", candidate.LastName);
            command.Parameters.Add(LastNameParam);

            SqlParameter BDParam = new SqlParameter("@BirthDay", candidate.BirthDay);
            command.Parameters.Add(BDParam);

            return command.ExecuteNonQuery();
        }

        public int DeleteCandidateByID(SqlConnection connection, int ID)
        {
            connection.Open();
            string sqlExpression = "DeleteCandidateByID";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter IDParam = new SqlParameter("@ID", ID);
            command.Parameters.Add(IDParam);

            return command.ExecuteNonQuery();
        }
    }
}
