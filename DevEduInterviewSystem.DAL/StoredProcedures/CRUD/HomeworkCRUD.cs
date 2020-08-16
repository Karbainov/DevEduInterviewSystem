using DevEduInterviewSystem.DAL.DTO;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;


namespace DevEduInterviewSystem.DAL.StoredProcedures.CRUD
{
    public class HomeworkCRUD : AbstractCRUD<HomeworkDTO>
    {
        public override int Add(HomeworkDTO dto)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("AddHomework");

            SqlParameter CandidateParam = new SqlParameter("@CandidateID", dto.CandidateID);
            command.Parameters.Add(CandidateParam);

            SqlParameter HomeworkStatusParam = new SqlParameter("@HomeworkStatusID", dto.HomeworkStatusID);
            command.Parameters.Add(HomeworkStatusParam);

            SqlParameter TestStatusParam = new SqlParameter("@TestStatusID", dto.TestStatusID);
            command.Parameters.Add(TestStatusParam);

            SqlParameter HomeworkDateParam = new SqlParameter("@HomeworkDate", dto.HomeworkDate);
            command.Parameters.Add(HomeworkDateParam);

            command.ExecuteNonQuery();
            SqlCommand returnCurrentID = new SqlCommand("SELECT MAX([ID]) FROM dbo.[Homework]", Connection);
            int count = (int)returnCurrentID.ExecuteScalar();

            Connection.Close();

            return count;
        }

        public override int DeleteByID(int id)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("DeleteHomeworkByID");

            SqlParameter IDParam = new SqlParameter("@ID", id);
            command.Parameters.Add(IDParam);
            
            int rows = command.ExecuteNonQuery();
            Connection.Close();

            return rows;
        }

        public override List<HomeworkDTO> SelectAll()
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectAllHomework");

            SqlDataReader reader = command.ExecuteReader();

            List<HomeworkDTO> homeworks = new List<HomeworkDTO>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    HomeworkDTO dto = new HomeworkDTO();

                    dto.ID = (int)reader["id"];
                    dto.CandidateID = (int)reader["CandidateID"];
                    dto.HomeworkStatusID = (int)reader["HomeworkStatusID"];
                    dto.TestStatusID = (int)reader["TestStatusID"];
                    dto.HomeworkDate = (DateTime)reader["HomeworkDate"];

                    homeworks.Add(dto);
                }
            }
            reader.Close();
            Connection.Close();

            return homeworks;
        }

        public override HomeworkDTO SelectByID(int id)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectHomeworkByID");

            SqlParameter IDParam = new SqlParameter("@ID", id);
            command.Parameters.Add(IDParam);

            SqlDataReader reader = command.ExecuteReader();
            HomeworkDTO dto = new HomeworkDTO();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    dto.ID = (int)reader["id"];
                    dto.CandidateID = (int)reader["CandidateID"];
                    dto.HomeworkStatusID = (int)reader["HomeworkStatusID"];
                    dto.TestStatusID = (int)reader["TestStatusID"];
                    dto.HomeworkDate = (DateTime)reader["HomeworkDate"];
                }
            }
            reader.Close();
            Connection.Close();
            return dto;
        }

        public override int UpdateByID(HomeworkDTO dto)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("UpdateHomeworkByID");

            SqlParameter IDParam = new SqlParameter("@ID", dto.ID);
            command.Parameters.Add(IDParam);

            SqlParameter CandidateParam = new SqlParameter("@CandidateID", dto.CandidateID);
            command.Parameters.Add(CandidateParam);

            SqlParameter HomeworkStatusParam = new SqlParameter("@HomeworkStatusID", dto.HomeworkStatusID);
            command.Parameters.Add(HomeworkStatusParam);

            SqlParameter TestStatusParam = new SqlParameter("@TestStatusID", dto.TestStatusID);
            command.Parameters.Add(TestStatusParam);

            SqlParameter HomeworkDateParam = new SqlParameter("@HomeworkDate", dto.HomeworkDate);
            command.Parameters.Add(HomeworkDateParam);

            int rows = command.ExecuteNonQuery();
            Connection.Close();

            return rows;
        }
    }
}

