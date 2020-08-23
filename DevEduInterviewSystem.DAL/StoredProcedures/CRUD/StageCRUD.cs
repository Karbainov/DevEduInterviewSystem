using Dapper;
using DevEduInterviewSystem.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DevEduInterviewSystem.DAL.StoredProcedures.CRUD
{
    public class StageCRUD : AbstractCRUD<StageDTO>
    {
        public override int Add(StageDTO dto)
        {
            var procedure = "AddStage";
            var values = new
            {
                Name = dto.Name,
            };
            
            IDbConnection.Query(procedure, values, commandType: CommandType.StoredProcedure);

            Connection.Open();
            SqlCommand returnCurrentID = new SqlCommand("SELECT MAX([ID]) FROM dbo.[Stage]", Connection);
            int count = (int)returnCurrentID.ExecuteScalar();

            Connection.Close();

            return count;
        }

        public override int DeleteByID(int id)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("DeleteStageByID");

            SqlParameter IDParam = new SqlParameter("@ID", id);
            command.Parameters.Add(IDParam);

            int a = command.ExecuteNonQuery();
            Connection.Close();
            return a;
        }


        public override List<StageDTO> SelectAll()
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectAllStage");

            SqlDataReader reader = command.ExecuteReader();

            List<StageDTO> stages = new List<StageDTO>();

            if (reader.HasRows) // если есть данные
            {
                while (reader.Read()) // построчно считываем данные
                {
                    StageDTO stage = new StageDTO()
                    {
                        ID = (int)reader["id"],
                        Name = (string)reader["Name"],                       
                    };
                    stages.Add(stage);
                }
            }
            reader.Close();
            Connection.Close();
            return stages;
        }



        public override StageDTO SelectByID(int id)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectStageByID");

            SqlParameter IDParam = new SqlParameter("@ID", id);
            command.Parameters.Add(IDParam);

            SqlDataReader reader = command.ExecuteReader();
            StageDTO stage = new StageDTO();

            if (reader.HasRows) // если есть данные
            {
                while (reader.Read()) // построчно считываем данные
                {
                    stage.ID = (int)reader["id"];
                    stage.Name = (string)reader["Name"];                 
                }
            }
            reader.Close();
            Connection.Close();
            return stage;
        }
   

        public override int UpdateByID(StageDTO dto)
        {
            var procedure = "[UpdateStageByID]";
            var values = new
            {
                ID = dto.ID,
                Name = dto.Name
            };

            IDbConnection.Query(procedure, values, commandType: CommandType.StoredProcedure);

            return (int)dto.ID;
        }    
    }
}
