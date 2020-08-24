using DevEduInterviewSystem.DAL.DTO;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Data;

namespace DevEduInterviewSystem.DAL.StoredProcedures.CRUD
{
    public class HomeworkCRUD : AbstractCRUD<HomeworkDTO>
    {
        public override int Add(HomeworkDTO dto)
        {
            var procedure = "[AddHomework]";
            var values = new
            {
                CandidateID = dto.CandidateID,
                HomeworkStatusID = dto.HomeworkStatusID,
                TestStatusID = dto.TestStatusID,
                HomeworkDate = dto.HomeworkDate
            };
            IDbConnection.Query(procedure, values, commandType: CommandType.StoredProcedure);
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("AddHomework");

            SqlParameter CandidateParam = new SqlParameter("@CandidateID", dto.CandidateID);
            command.Parameters.Add(CandidateParam);

            SqlParameter HomeworkStatusParam = new SqlParameter("@HomeworkStatusID", dto.HomeworkStatusID);
            command.Parameters.Add(HomeworkStatusParam);

            SqlParameter TestStatusIDParam = new SqlParameter("@TestStatusID", dto.TestStatusID);
            command.Parameters.Add(TestStatusIDParam);

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

                    HomeworkDTO homework = new HomeworkDTO()
                    {
                        ID = (int)reader["id"],
                        CandidateID = (int)reader["CandidateID"],
                        HomeworkStatusID = (int)reader["HomeworkStatusID"],
                        TestStatusID = (int)reader["TestStatusID"],
                        HomeworkDate = (DateTime)reader["HomeworkDate"]
                    };

                    homeworks.Add(homework);
                }
            }
            reader.Close();
            Connection.Close();

            return homeworks;

        }

        public override HomeworkDTO SelectByID(int ID)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectHomeworkByID");

            SqlParameter IDParam = new SqlParameter("@ID", ID);
            command.Parameters.Add(IDParam);

            SqlDataReader reader = command.ExecuteReader();
            HomeworkDTO homework = new HomeworkDTO();

            if (reader.HasRows)
            {

                while (reader.Read())
                {
                    homework.ID = (int)reader["id"];
                    homework.CandidateID = (int)reader["CandidateID"];
                    homework.HomeworkStatusID = (int)reader["HomeworkStatusID"];
                    homework.TestStatusID = (int)reader["TestStatusID"];
                    homework.HomeworkDate = (DateTime)reader["HomeworkDate"];
                }
            }
            reader.Close();
            Connection.Close();
            return homework;
        }

        public override int UpdateByID(HomeworkDTO dto)
        {
            var procedure = "[UpdateHomeworkByID]";
            var values = new
            {
                ID = dto.ID,
                CandidateID = dto.CandidateID,
                HomeworkStatusID = dto.HomeworkStatusID,
                TestStatusID = dto.TestStatusID,
                HomeworkDate = dto.HomeworkDate
            };

            IDbConnection.Query(procedure, values, commandType: CommandType.StoredProcedure);

            return (int)dto.ID;

        }
    }
}