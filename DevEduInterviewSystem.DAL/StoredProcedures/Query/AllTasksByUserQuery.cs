using DevEduInterviewSystem.DAL.DTO.QueryDTO;
using DevEduInterviewSystem.DAL.Shared;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DevEduInterviewSystem.DAL.StoredProcedures.Query
{
    public class AllTasksByUserQuery
    {
        public List<AllTasksByUserDTO> SelectAllTasksByUser(int id)
        {
            SqlConnection connection = ConnectionSingleTone.GetInstance().Connection;
            connection.Open();
            SqlCommand command = ReferenceToProcedure("AllTasksByUser", connection);
            SqlParameter userParam = new SqlParameter("@UserID", id);
            command.Parameters.Add(userParam);
            SqlDataReader reader = command.ExecuteReader();

            List<AllTasksByUserDTO> tasks = new List<AllTasksByUserDTO>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    AllTasksByUserDTO task = new AllTasksByUserDTO()
                    {
                        UserFirstName = (string)reader["UserFirstName"],
                        UserLastName = (string)reader["UserLastName"],
                        CandidateID = (int)reader["CandidateID"],
                        CandidateFirstName = (string)reader["CandidateFirstName"],
                        CandidateLastName = (string)reader["CandidateLastName"],
                        Task = (string)reader["Task"],
                        IsCompleted = (bool)reader["IsCompleted"],
                        Stage = (string)reader["Stage"]
                    };
                    tasks.Add(task);
                }
            }
            reader.Close();

            return tasks;
        }
        private SqlCommand ReferenceToProcedure(string sqlExpression, SqlConnection connection)
        {
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            return command;
        }
    }
}
