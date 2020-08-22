using DevEduInterviewSystem.DAL.DTO;
using DevEduInterviewSystem.DAL.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DevEduInterviewSystem.DAL.StoredProcedures.Query.User
{
    public class SelectUserRoleByUserID
    {
        public List<UserRoleDTO> SelectUserRoleByUser(int id)
        {
            SqlConnection connection = new SqlConnection(ConnectionSingleTone.GetInstance().ConnectionString);
            connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectUser_RoleByUserID", connection);

            SqlParameter IDParam = new SqlParameter("@ID", id);
            command.Parameters.Add(IDParam);

            List<UserRoleDTO> userRoles = new List<UserRoleDTO>();

            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    UserRoleDTO userRole = new UserRoleDTO()
                    {
                        ID = (int)reader["ID"],
                        UserID = (int)reader["UserID"],
                        RoleID = (int)reader["RoleID"]
                    };
                    userRoles.Add(userRole);
                }
            }
            reader.Close();
            connection.Close();
            return userRoles;
        }
        private SqlCommand ReferenceToProcedure(string sqlExpression, SqlConnection connection)
        {
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = CommandType.StoredProcedure;

            return command;
        }
    }
}
