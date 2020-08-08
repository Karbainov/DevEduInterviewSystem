using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using DevEduInterviewSystem.DAL.DTO;

namespace DevEduInterviewSystem.DAL.StoredProcedures
{
    public class TaskCRUD
    {
        public int AddTask(SqlConnection connection, TaskDTO task)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("AddTask", connection);

            SqlParameter IDParam = new SqlParameter("@ID", task.ID);
            command.Parameters.Add(IDParam);

            SqlParameter UserParam = new SqlParameter("@UserID", task.UserID);
            command.Parameters.Add(UserParam);

            SqlParameter MessageParam = new SqlParameter("@Message", task.Message);
            command.Parameters.Add(MessageParam);

            SqlParameter IsCompletedParam = new SqlParameter("@IsCompleted", task.IsCompleted);
            command.Parameters.Add(IsCompletedParam);

            return command.ExecuteNonQuery();
        }
        public int DeleteTaskByID(SqlConnection connection, int ID)
        {
            connection.Open();
            string sqlExpression = "DeleteTaskByID";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter IDParam = new SqlParameter("@ID", ID);
            command.Parameters.Add(IDParam);

            return command.ExecuteNonQuery();
        }

        public int SelectAllTask(SqlConnection connection)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectAllTask", connection);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows) 
            {
                while (reader.Read())
                {
                    int id = (int)reader["ID"];
                    int UserID = (int)reader["UserID"];
                    int Message = (int)reader["Message"];
                    string IsCompleted = (string)reader["IsCompleted"];
                  
                    Console.WriteLine($"{id} \t{UserID} \t{Message} \t{IsCompleted}");
                }
            }
            reader.Close();

            return command.ExecuteNonQuery();
        }

        public int SelectTaskByID(SqlConnection connection, int ID)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectTaskByID", connection);

            SqlParameter IDParam = new SqlParameter("@ID", ID);
            command.Parameters.Add(IDParam);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows) 
            {
              
                while (reader.Read()) 
                {
                    int Id = (int)reader["ID"];
                    int UserID = (int)reader["UserID"];
                    int Message = (int)reader["Message"];
                    string IsCompleted = (string)reader["IsCompleted"];

                    Console.WriteLine($"\t{Id} \t{UserID} \t{Message} \t{IsCompleted}");
                }
            }
            reader.Close();

            return command.ExecuteNonQuery();
        }

        public int UpdateTaskByID(SqlConnection connection, TaskDTO task, int ID)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("UpdateTaskByID", connection);

            SqlParameter IDParam = new SqlParameter("@ID", ID);
            command.Parameters.Add(IDParam);

            SqlParameter StageParam = new SqlParameter("@ID", task.ID);
            command.Parameters.Add(StageParam);

            SqlParameter StatusParam = new SqlParameter("@UserID", task.UserID);
            command.Parameters.Add(StatusParam);

            SqlParameter MessageParam = new SqlParameter("@Message", task.Message);
            command.Parameters.Add(MessageParam);

            SqlParameter IsCompletedParam = new SqlParameter("@IsCompleted", task.IsCompleted);
            command.Parameters.Add(IsCompletedParam);

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
