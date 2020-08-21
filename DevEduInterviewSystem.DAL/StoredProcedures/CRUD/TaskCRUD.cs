using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using DevEduInterviewSystem.DAL.DTO;
using DevEduInterviewSystem.DAL.StoredProcedures.CRUD;
using DevEduInterviewSystem.DAL.Shared;
using System.Data;
using Dapper;

namespace DevEduInterviewSystem.DAL.StoredProcedures
{
    public class TaskCRUD : AbstractCRUD<TaskDTO>
    {
        public override int Add(TaskDTO dto)
        {
            var procedure = "[AddTask]";
            var values = new
            {
                dto.CandidateID,
                dto.UserID,
                dto.Message,
                IsComleted = dto.IsCompleted
            };
            IDbConnection.Query(procedure, values, commandType: CommandType.StoredProcedure);
            Connection.Open();
            SqlCommand returnCurrentID = new SqlCommand("SELECT MAX([ID]) FROM dbo.[Task]", Connection);
            int count = (int)returnCurrentID.ExecuteScalar();

            Connection.Close();

            return count;          
        }
        public override int DeleteByID(int id)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("DeleteTaskByID");

            SqlParameter IDParam = new SqlParameter("@ID", id);
            command.Parameters.Add(IDParam);

            int rows = command.ExecuteNonQuery();
            Connection.Close();

            return rows;
        }

        public override List<TaskDTO> SelectAll()
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectAllTask");

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
            Connection.Close();
            return tasks;
        }

        public override TaskDTO SelectByID(int id)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectTaskByID");

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
            Connection.Close();
            return task;
        }

        public override int UpdateByID(TaskDTO dto)
        {
            var procedure = "[UpdateTaskByID]";
            var values = new
            {
                dto.ID,
                dto.CandidateID,
                dto.UserID,
                dto.Message,
                IsComleted = dto.IsCompleted
            };
            IDbConnection.Query(procedure, values, commandType: CommandType.StoredProcedure);
            return (int)dto.ID;           
        }
    }
}