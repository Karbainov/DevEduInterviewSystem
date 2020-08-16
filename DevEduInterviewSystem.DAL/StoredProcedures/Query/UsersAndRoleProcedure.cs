using DevEduInterviewSystem.DAL.DTO.QuereDTO;
using DevEduInterviewSystem.DAL.Shared;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DevEduInterviewSystem.DAL.StoredProcedures
{
    public class UsersAndRoleProcedure
    {
        SqlConnection Connection = new SqlConnection(ConnectionSingleTone.GetInstance().ConnectionString);

        public List<UsersAndRoleDTO> SelectUsersAndRole()
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("UsersAndRole", Connection);

            List<UsersAndRoleDTO> usersAndRoles = new List<UsersAndRoleDTO>();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows) 
            {
                while (reader.Read()) 
                {
                    UsersAndRoleDTO usersAndRole = new UsersAndRoleDTO()
                    {
                        Login = (string)reader["Login"],
                        FirstName = (string)reader["FirstName"],
                        LastName = (string)reader["LastName"],
                        Password = (string)reader["Password"],
                        Role = (string)reader["Role"],
                       
                    };

                    usersAndRoles.Add(usersAndRole);
                }
            }
            reader.Close();

            return usersAndRoles;

        }
        private SqlCommand ReferenceToProcedure(string sqlExpression, SqlConnection connection)
        {
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            return command;
        }
    }
}
