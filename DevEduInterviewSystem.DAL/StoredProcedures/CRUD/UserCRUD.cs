using Dapper;
using DevEduInterviewSystem.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DevEduInterviewSystem.DAL.StoredProcedures.CRUD
{
    public class UserCRUD : AbstractCRUD<UserDTO>
    {
        public override int Add(UserDTO dto)
        {
            var procedure = "[AddUser]";
            var values = new
            {
                dto.Login,
                dto.Password,
                dto.FirstName,
                dto.LastName,
                dto.IsDeleted
            };
            IDbConnection.Query(procedure, values, commandType: CommandType.StoredProcedure);

            Connection.Open();
            SqlCommand returnCurrentID = new SqlCommand("SELECT MAX([ID]) FROM dbo.[User]", Connection);
            int count = (int)returnCurrentID.ExecuteScalar();

            Connection.Close();

            return count;         
        }

        public override int DeleteByID(int id)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("DeleteUserByID");

            SqlParameter IDParam = new SqlParameter("@ID", id);
            command.Parameters.Add(IDParam);

            int a = command.ExecuteNonQuery();
            Connection.Close();
            return a;
        }

        public override List<UserDTO> SelectAll()
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectAllUser");
            SqlDataReader reader = command.ExecuteReader();
            List<UserDTO> users = new List<UserDTO>();
            if (reader.HasRows)
            {
                while (reader.Read()) 
                {
                    UserDTO user = new UserDTO()
                    {
                        ID = (int)reader["id"],
                        Login = (string)reader["Login"],
                        Password = (string)reader["Password"],
                        FirstName = (string)reader["FirstName"],
                        LastName = (string)reader["LastName"]
                    };
                    users.Add(user);
                }
            }
            reader.Close();
            Connection.Close();
            return users;
        }
        public override UserDTO SelectByID(int id)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectUserByID");

            SqlParameter IDParam = new SqlParameter("@ID", id);
            command.Parameters.Add(IDParam);

            SqlDataReader reader = command.ExecuteReader();

            UserDTO user = new UserDTO();
            while (reader.Read())
            {
                user.ID = (int)reader["id"];
                user.Login = (string)reader["Login"];
                user.Password = (string)reader["Password"];
                user.FirstName = (string)reader["FirstName"];
                user.LastName = (string)reader["LastName"];
            }

            reader.Close();
            Connection.Close();

            return user;
        }
        public override int UpdateByID(UserDTO dto)
        {
            var procedure = "[UpdateUserByID]";
            var values = new
            {
              dto.ID,
              dto.Login,
              dto.Password,
              dto.FirstName,
              dto.LastName,
              dto.IsDeleted
            };
            IDbConnection.Query(procedure, values, commandType: CommandType.StoredProcedure);
            return (int)dto.ID;
        }
    }
}
