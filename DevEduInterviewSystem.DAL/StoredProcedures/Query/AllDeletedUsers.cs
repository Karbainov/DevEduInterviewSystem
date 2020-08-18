using DevEduInterviewSystem.DAL.DTO.QuereDTO;
using DevEduInterviewSystem.DAL.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Dapper;
using DevEduInterviewSystem.DAL.DTO;

namespace DevEduInterviewSystem.DAL.StoredProcedures.Query
{
    public class AllDeletedUsers
    {
        public List<UserDTO> SelectAllDeletedUsers()
        {
            SqlConnection connection = new SqlConnection(ConnectionSingleTone.GetInstance().ConnectionString);
            connection.Open();
            SqlCommand command = ReferenceToProcedure("[AllDeletedUsers]", connection);
            SqlDataReader reader = command.ExecuteReader();
            List<UserDTO> users = new List<UserDTO>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    UserDTO user = new UserDTO()
                    {
                        Login = (string)reader["Login"],
                        Password = (string)reader["Password"],
                        FirstName = (string)reader["FirstName"],
                        LastName = (string)reader["LastName"]
                    };
                    users.Add(user);
                }
            }
            reader.Close();
            return users;

        }
        private SqlCommand ReferenceToProcedure(string sqlExpression, SqlConnection connection)
        {
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            return command;
        }
    }
}
