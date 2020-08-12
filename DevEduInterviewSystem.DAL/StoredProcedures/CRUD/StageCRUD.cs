using DevEduInterviewSystem.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DevEduInterviewSystem.DAL.StoredProcedures.CRUD
{
    public class StageCRUD : AbstractCRUD<StageDTO>
    {
        public override int Add(StageDTO dto)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("AddStage");

            SqlParameter NameParam = new SqlParameter("@Name", dto.Name);
            command.Parameters.Add(NameParam);

            return command.ExecuteNonQuery();
        }

        public override int DeleteByID(int id)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("DeleteStageByID");

            SqlParameter IDParam = new SqlParameter("@ID", id);
            command.Parameters.Add(IDParam);

            return command.ExecuteNonQuery();
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

            return stage;
        }
   

        public override int UpdateByID(StageDTO dto)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("UpdateStageByID");

            SqlParameter IDParam = new SqlParameter("@ID", dto.ID);
            command.Parameters.Add(IDParam);

            SqlParameter NameParam = new SqlParameter("@Name", dto.Name);
            command.Parameters.Add(NameParam);

            return command.ExecuteNonQuery();
        }    
    }
}
