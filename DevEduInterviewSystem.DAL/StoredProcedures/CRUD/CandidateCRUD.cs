using Dapper;
using DevEduInterviewSystem.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace DevEduInterviewSystem.DAL.StoredProcedures.CRUD
{
    public class CandidateCRUD:AbstractCRUD<CandidateDTO>
    {
        public override int Add(CandidateDTO dto)
        {
            var procedure = "[AddCandidate]";
            var values = new { StageID = dto.StageID, 
                StatusID = dto.StatusID, 
                CityID = dto.CityID,
                Phone = dto.Phone,
                Email = dto.Email,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                BirthDay = dto.BirthDay};

            IDbConnection.Query(procedure, values, commandType: CommandType.StoredProcedure);

            Connection.Open();
            SqlCommand returnCurrentID = new SqlCommand("SELECT MAX([ID]) FROM dbo.[Candidate]", Connection);
            int count = (int)returnCurrentID.ExecuteScalar();

            Connection.Close();

            return count;
        }

        public override int DeleteByID(int id)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("DeleteCandidateByID");

            SqlParameter IDParam = new SqlParameter("@ID", id);
            command.Parameters.Add(IDParam);

            int rows = command.ExecuteNonQuery();
            Connection.Close();
            return rows;
        }

        public override List<CandidateDTO> SelectAll()
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectAllCandidate");

            List<CandidateDTO> candidates = new List<CandidateDTO>();

            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    CandidateDTO candidate = new CandidateDTO()
                    {
                        ID = (int)reader["id"],
                        StageID = (int)reader["StageID"],
                        StatusID = (int)reader["StatusID"],
                        CityID = (int)reader["CityID"],
                        Phone = (string)reader["Phone"],
                        Email = (string)reader["Email"],
                        FirstName = (string)reader["FirstName"],
                        LastName = (string)reader["LastName"],
                        BirthDay = (DateTime)reader["Birthday"]
                    };

                    candidates.Add(candidate);
                }
            }
            reader.Close();
            Connection.Close();

            return candidates;
        }

        public override CandidateDTO SelectByID(int id)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectCandidateByID");

            SqlParameter IDParam = new SqlParameter("@ID", id);
            command.Parameters.Add(IDParam);

            SqlDataReader reader = command.ExecuteReader();
            CandidateDTO candidate = new CandidateDTO();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    candidate.ID = (int)reader["id"];
                    candidate.StageID = (int)reader["StageID"];
                    candidate.StatusID = (int)reader["StatusID"];
                    candidate.CityID = (int)reader["CityID"];
                    candidate.Phone = (string)reader["Phone"];
                    candidate.Email = (string)reader["Email"];
                    candidate.FirstName = (string)reader["FirstName"];
                    candidate.LastName = (string)reader["LastName"];
                    candidate.BirthDay = (DateTime)reader["Birthday"];

                }
            }
            reader.Close();
            Connection.Close();

            return candidate;
        }

        public override int UpdateByID(CandidateDTO dto)
        {
            var procedure = "[UpdateCandidateByID]";
            var values = new
            {
                ID = dto.ID,
                StageID = dto.StageID,
                StatusID = dto.StatusID,
                CityID = dto.CityID,
                Phone = dto.Phone,
                Email = dto.Email,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                BirthDay = dto.BirthDay
            };

            IDbConnection.Query(procedure, values, commandType: CommandType.StoredProcedure);           

            return (int)dto.ID;            
        }    
    }
}
