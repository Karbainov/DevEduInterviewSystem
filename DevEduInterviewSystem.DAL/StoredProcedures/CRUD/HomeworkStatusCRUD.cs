using DevEduInterviewSystem.DAL.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Text;

namespace DevEduInterviewSystem.DAL.StoredProcedures.CRUD
{
    public class HomeworkStatusCRUD : AbstractCRUD<HomeworkStatusDTO>
    {
        public override int Add(HomeworkStatusDTO dto)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("AddHomeworkStatus");

            SqlParameter NameParam = new SqlParameter("@Name", dto.Name);
            command.Parameters.Add(NameParam);

            return command.ExecuteNonQuery();
        }

        public override int DeleteByID(int id)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("DeleteHomeworkStatusByID");

            SqlParameter IDParam = new SqlParameter("@ID", id);
            command.Parameters.Add(IDParam);

            return command.ExecuteNonQuery();
        }


        public override List<HomeworkStatusDTO> SelectAll()
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectAllHomeworkStatus");

            SqlDataReader reader = command.ExecuteReader();

            List<HomeworkStatusDTO> homeworktatuses = new List<HomeworkStatusDTO>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    HomeworkStatusDTO homeworkStatus = new HomeworkStatusDTO()
                    {
                        ID = (int)reader["id"],
                        Name = (string)reader["Name"]
                    };

                    homeworktatuses.Add(homeworkStatus);
                }
            }
            reader.Close();
            return homeworktatuses;
        }


        public override HomeworkStatusDTO SelectByID(int id)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectHomeworkStatusByID");

            SqlParameter IDParam = new SqlParameter("@ID", id);
            command.Parameters.Add(IDParam);

            SqlDataReader reader = command.ExecuteReader();
            HomeworkStatusDTO homeworkStatus = new HomeworkStatusDTO();

            if (reader.HasRows)
            {

                while (reader.Read())
                {
                    homeworkStatus.ID = (int)reader["id"];
                    homeworkStatus.Name = (string)reader["Name"];
                }
            }
            reader.Close();

            return homeworkStatus;
        }


        public override int UpdateByID(HomeworkStatusDTO dto)
        {

            Connection.Open();
            SqlCommand command = ReferenceToProcedure("UpdateHomeworkStatusByID");

            SqlParameter IDParam = new SqlParameter("@ID", dto.ID);
            command.Parameters.Add(IDParam);

            SqlParameter NameParam = new SqlParameter("@Name", dto.Name);
            command.Parameters.Add(NameParam);



            return command.ExecuteNonQuery();
        }
    }
}
