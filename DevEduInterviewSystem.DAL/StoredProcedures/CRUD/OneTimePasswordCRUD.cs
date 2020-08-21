using Dapper;
using DevEduInterviewSystem.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DevEduInterviewSystem.DAL.StoredProcedures.CRUD
{
    public class OneTimePasswordCRUD : AbstractCRUD<OneTimePasswordDTO>
    {
        public override int Add(OneTimePasswordDTO dto)
        {
            var procedure = "[AddOneTimePassword]";
            var values = new
            {
                CandidateID = dto.CandidateID,
                DateOfPasswordIssue = dto.DateOfPasswordIssue,
                OneTimePassword = dto.OneTimePassword
            };

            IDbConnection.Query(procedure, values, commandType: CommandType.StoredProcedure);

            Connection.Open();
            SqlCommand returnCurrentID = new SqlCommand("SELECT MAX([ID]) FROM dbo.[OneTimePassword]", Connection);
            int count = (int)returnCurrentID.ExecuteScalar();

            Connection.Close();

            return count;
        }

        public override int DeleteByID(int id)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("DeleteOneTimePasswordByID");

            SqlParameter IDParam = new SqlParameter("@ID", id);
            command.Parameters.Add(IDParam);

            int a = command.ExecuteNonQuery();
            Connection.Close();
            return a;
        }

        public override List<OneTimePasswordDTO> SelectAll()
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectAllOneTimePassword");
            SqlDataReader reader = command.ExecuteReader();
            List<OneTimePasswordDTO> passwords = new List<OneTimePasswordDTO>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    OneTimePasswordDTO password = new OneTimePasswordDTO()
                    {
                        ID = (int)reader["id"],
                        CandidateID = (int)reader["CandidateID"],
                        DateOfPasswordIssue = (DateTime)reader["DateOfPasswordIssue"],
                        OneTimePassword = (string)reader["OneTimePassword"]
                    };
                    passwords.Add(password);
                }
            }
            reader.Close();
            Connection.Close();
            return passwords;
        }

        public override OneTimePasswordDTO SelectByID(int id)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectOneTimePasswordByID");

            SqlParameter IDParam = new SqlParameter("@ID", id);
            command.Parameters.Add(IDParam);

            SqlDataReader reader = command.ExecuteReader();

            OneTimePasswordDTO password = new OneTimePasswordDTO();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    password.ID = (int)reader["id"];
                    password.CandidateID = (int)reader["CandidateID"];
                    password.DateOfPasswordIssue = (DateTime)reader["DateOfPasswordIssue"];
                    password.OneTimePassword = (string)reader["OneTimePassword"];
                }
            }
            reader.Close();
            Connection.Close();
            return password;
        }

        public override int UpdateByID(OneTimePasswordDTO dto)
        {
            var procedure = "[UpdateOneTimePasswordByID]";
            var values = new
            {
                ID = dto.ID,
                CandidateID = dto.CandidateID,
                DateOfPasswordIssue = dto.DateOfPasswordIssue,
                OneTimePassword = dto.OneTimePassword
            };

            IDbConnection.Query(procedure, values, commandType: CommandType.StoredProcedure);

            return (int)dto.ID;
        }
    }
}
