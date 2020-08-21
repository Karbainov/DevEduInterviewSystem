using Dapper;
using DevEduInterviewSystem.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DevEduInterviewSystem.DAL.StoredProcedures.CRUD
{
   public class StageChangedCRUD : AbstractCRUD<StageChangedDTO>
    {
        public override int Add(StageChangedDTO dto)
        {
            var procedure = "[AddStageChanged]";
            var values = new
            {
                StageID = dto.StageID,
                CandidateID = dto.CandidateID,
                ChangedDate = dto.ChangedDate
            };

            IDbConnection.Query(procedure, values, commandType: CommandType.StoredProcedure);

            Connection.Open();
            SqlCommand returnCurrentID = new SqlCommand("SELECT MAX([ID]) FROM dbo.[StageChanged]", Connection);
            int count = (int)returnCurrentID.ExecuteScalar();

            Connection.Close();

            return count;
        }

        
        public override int DeleteByID(int id)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("DeleteStageChangedByID");

            SqlParameter IDParam = new SqlParameter("@ID", id);
            command.Parameters.Add(IDParam);

            int a = command.ExecuteNonQuery();
            Connection.Close();
            return a;
        }

     
        public override List<StageChangedDTO> SelectAll()
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectAllStageChanged");

            SqlDataReader reader = command.ExecuteReader();
            List<StageChangedDTO> stageChangeds = new List<StageChangedDTO>();

            List<StageChangedDTO> stages = new List<StageChangedDTO>();

            if (reader.HasRows) 
            {

                while (reader.Read())
                {
                    StageChangedDTO stage = new StageChangedDTO()
                    {
                        ID = (int)reader["ID"],
                        StageID = (int)reader["StageID"],
                        CandidateID = (int)reader["CandidateID"],
                        ChangedDate = (DateTime)reader["ChangedDate"]
                    
                    };
                    stages.Add(stage);
                }
            }
            reader.Close();
            Connection.Close();
            return stages;
        }

       
        public override StageChangedDTO SelectByID(int id)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectStageChangedByID");

            SqlParameter IDParam = new SqlParameter("@ID", id);
            command.Parameters.Add(IDParam);

            SqlDataReader reader = command.ExecuteReader();
            StageChangedDTO stage = new StageChangedDTO();

            if (reader.HasRows) 
            {
                while (reader.Read()) 
                {
                    stage.ID = (int)reader["ID"];
                    stage.StageID = (int)reader["StageID"];
                    stage.CandidateID = (int)reader["CandidateID"];
                    stage.ChangedDate = (DateTime)reader["ChangedDate"];
                }
            }
            reader.Close();
            Connection.Close();
            return stage;
        }

        
        public override int UpdateByID(StageChangedDTO dto)
        {
            var procedure = "[UpdateStageChangedByID]";
            var values = new
            {
                ID = dto.ID,
                StageID = dto.StageID,
                CandidateID = dto.CandidateID,
                ChangedDate = dto.ChangedDate
            };

            IDbConnection.Query(procedure, values, commandType: CommandType.StoredProcedure);

            return (int)dto.ID;
        }
    }
}