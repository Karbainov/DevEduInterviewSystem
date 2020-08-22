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
        public List<UsersWithRoleDTO> SelectAllDeletedUsers()
        {
            IDbConnection connection = new SqlConnection(ConnectionSingleTone.GetInstance().ConnectionString);
            var procedure = "[AllDeletedUsers]";

            List<UsersWithRoleDTO> result = new List<UsersWithRoleDTO>();

            connection.Query<UsersWithRoleDTO, RoleDTO, UsersWithRoleDTO>(procedure, (user, role) =>
            {
                UsersWithRoleDTO userDTO = null;
                foreach (UsersWithRoleDTO u in result)
                {
                    if (u.ID == user.ID)
                    {
                        userDTO = u;
                    }
                }
                if (userDTO == null)
                {
                    userDTO = user;
                    result.Add(userDTO);
                }

                if (userDTO.Roles == null)
                {
                    userDTO.Roles = new List<RoleDTO>();
                }
                if (!userDTO.Roles.Contains(role))
                {
                    userDTO.Roles.Add(role);
                }

                return userDTO;
            },
            splitOn: "TypeOfRole",
            commandType: CommandType.StoredProcedure
            );

            return result;
        }

        public UserDTO SelectDeletedUserByID(int id)
        {
            SqlConnection connection = new SqlConnection(ConnectionSingleTone.GetInstance().ConnectionString);
            connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectDeletedUserByID", connection);

            SqlParameter IDParam = new SqlParameter("@ID", id);
            command.Parameters.Add(IDParam);

            SqlDataReader reader = command.ExecuteReader();
            UserDTO user = new UserDTO();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    user.ID = (int)reader["id"];
                    user.Login = (string)reader["Login"];
                    user.Password = (string)reader["Password"];
                    user.FirstName = (string)reader["FirstName"];
                    user.LastName = (string)reader["LastName"];
                }
            }
            reader.Close();
            connection.Close();
            return user;
        }
        private SqlCommand ReferenceToProcedure(string sqlExpression, SqlConnection connection)
        {
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = CommandType.StoredProcedure;

            return command;
        }
    }
}
