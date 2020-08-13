using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using DevEduInterviewSystem.DAL.DTO;
using DevEduInterviewSystem.DAL.Shared;

namespace DevEduInterviewSystem.DAL.StoredProcedures.CRUD
{
    public class StageChangedCRUD : AbstractCRUD<StageChangedDTO>
    {
        public override int Add(StageChangedDTO dto)
        {
            SqlConnection Connection = ConnectionSingleTone.GetInstance().Connection;
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("@AddStageChanged");

            SqlParameter StageParam = new SqlParameter("@StageID", dto.StageID);
            command.Parameters.Add(StageParam);

            SqlParameter CandidateParam = new SqlParameter("@CandidateID", dto.CandidateID);
            command.Parameters.Add(CandidateParam);

            SqlParameter ChangedDateParam = new SqlParameter("@ChangedDate", dto.ChangedDate);
            command.Parameters.Add(ChangedDateParam);

            return command.ExecuteNonQuery();
        }
        public override int DeleteByID(int id)
        {
            SqlConnection Connection = ConnectionSingleTone.GetInstance().Connection;
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("@DeleteStageChangedByID");

            SqlParameter IDParam = new SqlParameter("@ID", id);
            command.Parameters.Add(IDParam);

            return command.ExecuteNonQuery();
        }

        public override List<StageChangedDTO> SelectAll()
        {
            SqlConnection Connection = ConnectionSingleTone.GetInstance().Connection;
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("@SelectAllStageChanged");

            SqlDataReader reader = command.ExecuteReader();
            List<StageChangedDTO> stageChangeds = new List<StageChangedDTO>();

            // Если есть данные
            if (reader.HasRows)
            {
                // Построчно считываем данные
                while (reader.Read())
                {
                    StageChangedDTO stageChanged = new StageChangedDTO()
                    {
                        ID = (int)reader["ID"],
                        StageID = (int)reader["StageID"],
                        CandidateID = (int)reader["CandidateID"],
                        ChangedDate = (DateTime)reader["ChangedDate"]
                    };
                    stageChangeds.Add(stageChanged);
                }
            }
            reader.Close();

            return stageChangeds;
        }

        public override StageChangedDTO SelectByID(int id)
        {
            SqlConnection Connection = ConnectionSingleTone.GetInstance().Connection;
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectStageChangedByID");

            SqlParameter IDParam = new SqlParameter("@ID", id);
            command.Parameters.Add(IDParam);

            SqlDataReader reader = command.ExecuteReader();
            StageChangedDTO stageChanged = new StageChangedDTO();
            // Если есть данные
            if (reader.HasRows)
            {
                // Построчно считываем данные
                while (reader.Read())
                {
                    stageChanged.ID = (int)reader["ID"];
                    stageChanged.StageID = (int)reader["StageID"];
                    stageChanged.CandidateID = (int)reader["CandidateID"];
                    stageChanged.ChangedDate = (DateTime)reader["ChangedDate"];

                }
            }
            reader.Close();

            return stageChanged;
        }

        public override int UpdateByID(StageChangedDTO dto)
        {
            SqlConnection Connection = ConnectionSingleTone.GetInstance().Connection;
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

            return command.ExecuteNonQuery();

        }

    }
}