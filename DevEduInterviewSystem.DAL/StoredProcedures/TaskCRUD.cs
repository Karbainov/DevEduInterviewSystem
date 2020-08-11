using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using DevEduInterviewSystem.DAL.DTO;
using DevEduInterviewSystem.DAL.StoredProcedures.CRUD;

namespace DevEduInterviewSystem.DAL.StoredProcedures
{
    public class TaskCRUD : AbstractCRUD<TaskDTO>
    {
        public override int Add(TaskDTO dto)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("AddTask", Connection);

            SqlParameter UserParam = new SqlParameter("@UserID", dto.UserID);
            command.Parameters.Add(UserParam);

            SqlParameter CandidateIDParam = new SqlParameter("@CandidateID", dto.CandidateID);
            command.Parameters.Add(CandidateIDParam);

            SqlParameter MessageParam = new SqlParameter("@Message", dto.Message);
            command.Parameters.Add(MessageParam);

            SqlParameter IsCompletedParam = new SqlParameter("@IsCompleted", dto.IsCompleted);
            command.Parameters.Add(IsCompletedParam);

            return command.ExecuteNonQuery();
        }
        public override int DeleteByID(int id)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("DeleteTaskByID", Connection);

            SqlParameter IDParam = new SqlParameter("@ID", id);
            command.Parameters.Add(IDParam);

            return command.ExecuteNonQuery();
        }

        public override List<TaskDTO> SelectAll()
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectAllTask", Connection);

            SqlDataReader reader = command.ExecuteReader();

            List<TaskDTO> tasks = new List<TaskDTO>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    TaskDTO task = new TaskDTO()
                    {
                        ID = (int)reader["id"],
                        UserID = (int)reader["UserID"],
                        CandidateID = (int)reader["CandidateID"],
                        Message = (string)reader["Message"],
                        IsCompleted = (string)reader["IsCompleted"]
                    };
                    tasks.Add(task);
                }

            }
            reader.Close();

            return tasks;
        }

        public override TaskDTO SelectByID(int id)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectTaskByID", Connection);

            SqlParameter IDParam = new SqlParameter("@ID", id);
            command.Parameters.Add(IDParam);

            SqlDataReader reader = command.ExecuteReader();
            TaskDTO task = new TaskDTO();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    task.ID = (int)reader["id"];
                    task.UserID = (int)reader["UserID"];
                    task.CandidateID = (int)reader["CandidateID"];
                    task.Message = (string)reader["Message"];
                    task.IsCompleted = (string)reader["IsCompleted"];

                }
            }
            reader.Close();

            return task;
        }

        public override int UpdateByID(TaskDTO dto)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("UpdateTaskByID", Connection);

            SqlParameter IDParam = new SqlParameter("@ID", dto.ID);
            command.Parameters.Add(IDParam);

            SqlParameter CandidateParam = new SqlParameter("@CandidateID", dto.CandidateID);
            command.Parameters.Add(CandidateParam);

            SqlParameter StatusParam = new SqlParameter("@UserID", dto.UserID);
            command.Parameters.Add(StatusParam);

            SqlParameter MessageParam = new SqlParameter("@Message", dto.Message);
            command.Parameters.Add(MessageParam);

            SqlParameter IsCompletedParam = new SqlParameter("@IsCompleted", dto.IsCompleted);
            command.Parameters.Add(IsCompletedParam);

            return command.ExecuteNonQuery();
        }
    }

}
