using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using DevEduInterviewSystem.DAL.DTO;

namespace DevEduInterviewSystem.DAL.StoredProcedures.CRUD
{
   public class StageChangedCRUD : AbstractCRUD<StageChangedDTO>
    {
        public override int Add(StageChangedDTO dto)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("AddStageChanged");

            SqlParameter StageIDParam = new SqlParameter("@StageID", dto.StageID);
            command.Parameters.Add(StageIDParam);

            SqlParameter CandidateParam = new SqlParameter("@CandidateID", dto.CandidateID);
            command.Parameters.Add(CandidateParam);

            SqlParameter ChangedDateParam = new SqlParameter("@ChangedDate", dto.ChangedDate);
            command.Parameters.Add(ChangedDateParam);

            int a = (int)(decimal)command.ExecuteScalar();
            Connection.Close();
            return a;
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

            List<StageChangedDTO> stages = new List<StageChangedDTO>();

            if (reader.HasRows) // если есть данные
            {
                while (reader.Read()) // построчно считываем данные
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

            if (reader.HasRows) // если есть данные
            {
                while (reader.Read()) // построчно считываем данные
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
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("UpdateStageChangedByID");

            SqlParameter IDParam = new SqlParameter("@ID", dto.ID);
            command.Parameters.Add(IDParam);

            SqlParameter StatusParam = new SqlParameter("@StageID", dto.StageID);
            command.Parameters.Add(StatusParam);

            SqlParameter CandidateParam = new SqlParameter("@CandidateID", dto.CandidateID);
            command.Parameters.Add(CandidateParam);

            SqlParameter ChangedDateParam = new SqlParameter("@ChangedDate", dto.ChangedDate);
            command.Parameters.Add(ChangedDateParam);

            int a = command.ExecuteNonQuery();
            Connection.Close();
            return a;
        }

        

      
    }
}
