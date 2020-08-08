using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using DevEduInterviewSystem.DAL.DTO;

namespace DevEduInterviewSystem.DAL.StoredProcedures.CRUD
{
   public class StageChangedCRUD
    {
        public int AddStageChanged(SqlConnection connection, StageChangedDTO stageChanged)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("AddStageChanged", connection);

            SqlParameter IDParam = new SqlParameter("@ID", stageChanged.ID);
            command.Parameters.Add(IDParam);

            SqlParameter StageParam = new SqlParameter("@StageID", stageChanged.StageID);
            command.Parameters.Add(StageParam);

            SqlParameter CandidateParam = new SqlParameter("@Candidate", stageChanged.CandidateID);
            command.Parameters.Add(CandidateParam);

            SqlParameter ChangedDateParam = new SqlParameter("@ChangedDate", stageChanged.ChangedDate);
            command.Parameters.Add(ChangedDateParam);

            return command.ExecuteNonQuery();
        }
        public int DeleteStageChangedByID(SqlConnection connection, int ID)
        {
            connection.Open();
            string sqlExpression = "DeleteStageChangedByID";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter IDParam = new SqlParameter("@ID", ID);
            command.Parameters.Add(IDParam);

            return command.ExecuteNonQuery();
        }

        public int SelectAllStageChanged(SqlConnection connection)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectAllStageChanged", connection);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int id = (int)reader["ID"];
                    int StageID = (int)reader["StageID"];
                    int Candidate = (int)reader["Candidate"];
                    string ChangedDate = (string)reader["ChangedDate"];

                    Console.WriteLine($"{id} \t{StageID} \t{Candidate} \t{ChangedDate}");
                }
            }
            reader.Close();

            return command.ExecuteNonQuery();
        }

        public int SelectStageChangedByID(SqlConnection connection, int ID)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectStageChangedByID", connection);

            SqlParameter IDParam = new SqlParameter("@ID", ID);
            command.Parameters.Add(IDParam);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {

                while (reader.Read())
                {
                    int Id = (int)reader["ID"];
                    int StageID = (int)reader["StageID"];
                    int Candidate = (int)reader["Candidate"];
                    var ChangedDate = (DateTime)reader["ChangedDate"];

                    Console.WriteLine($"\t{Id} \t{StageID} \t{Candidate} \t{ChangedDate}");
                }
            }
            reader.Close();

            return command.ExecuteNonQuery();
        }

        public int UpdateStageChangedByID(SqlConnection connection, StageChangedDTO stageChanged, int ID)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("UpdateStageChangedByID", connection);

            SqlParameter IDParam = new SqlParameter("@ID", ID);
            command.Parameters.Add(IDParam);

            SqlParameter StageParam = new SqlParameter("@ID", stageChanged.ID);
            command.Parameters.Add(StageParam);

            SqlParameter StatusParam = new SqlParameter("@StageID", stageChanged.StageID);
            command.Parameters.Add(StatusParam);

            SqlParameter CandidateParam = new SqlParameter("@Candidate", stageChanged.CandidateID);
            command.Parameters.Add(CandidateParam);

            SqlParameter ChangedDateParam = new SqlParameter("@ChangedDate", stageChanged.ChangedDate);
            command.Parameters.Add(ChangedDateParam);

            return command.ExecuteNonQuery();

        }

        private SqlCommand ReferenceToProcedure(string sqlExpression, SqlConnection connection)
        {
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            return command;
        }
    }
}
