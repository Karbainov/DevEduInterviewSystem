using DevEduInterviewSystem.DAL.DTO;
using DevEduInterviewSystem.DAL.DTO.CalendarInterviews;
using DevEduInterviewSystem.DAL.DTO.QueryDTO;
using DevEduInterviewSystem.DAL.Shared;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DevEduInterviewSystem.DAL.StoredProcedures.Query
{
    public class OneUserRoleQuery
    {

        public List<OneUserRoleDTO> SelectOneUserRole(int id)
        {
            SqlConnection connection = new SqlConnection(ConnectionSingleTone.GetInstance().ConnectionString);
            connection.Open();
            SqlCommand command = ReferenceToProcedure("OneUserRole", connection);
            SqlParameter userParam = new SqlParameter("@UserID", id);
            command.Parameters.Add(userParam);
            SqlDataReader reader = command.ExecuteReader();
            List<OneUserRoleDTO> roles = new List<OneUserRoleDTO>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    OneUserRoleDTO role = new OneUserRoleDTO()
                    {
                        Login = (string)reader["Login"],
                        FirstName = (string)reader["FirstName"],
                        LastName = (string)reader["LastName"],
                        Password = (string)reader["Password"],
                        Role = (string)reader["Role"],
                    };
                    roles.Add(role);
                }
            }
            reader.Close();
            return roles;
        }
        private SqlCommand ReferenceToProcedure(string sqlExpression, SqlConnection connection)
        {
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            return command;
        }
    }
}
