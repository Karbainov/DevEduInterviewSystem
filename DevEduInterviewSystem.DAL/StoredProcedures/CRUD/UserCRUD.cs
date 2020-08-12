using DevEduInterviewSystem.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DevEduInterviewSystem.DAL.StoredProcedures.CRUD
{
    public class UserCRUD : AbstractCRUD<UserDTO>
    {
        public override int Add(UserDTO dto)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("AddUser");

            SqlParameter LoginParam = new SqlParameter("@Login", dto.Login);
            command.Parameters.Add(LoginParam);

            SqlParameter PasswordParam = new SqlParameter("@Password", dto.Password);
            command.Parameters.Add(PasswordParam);

            SqlParameter FirstNameParam = new SqlParameter("@FirstName", dto.FirstName);
            command.Parameters.Add(FirstNameParam);

            SqlParameter LastNameParam = new SqlParameter("@LastName", dto.LastName);
            command.Parameters.Add(LastNameParam);

            return command.ExecuteNonQuery();
        }

        public override int DeleteByID(int id)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("DeleteUserByID");

            SqlParameter IDParam = new SqlParameter("@ID", id);
            command.Parameters.Add(IDParam);

            return command.ExecuteNonQuery();
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

            return user;
        }
        public override int UpdateByID(UserDTO dto)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("UpdateUserByID");

            SqlParameter IDParam = new SqlParameter("@ID", dto.ID);
            command.Parameters.Add(IDParam);

            SqlParameter LoginParam = new SqlParameter("@StageID", dto.Login);
            command.Parameters.Add(LoginParam);

            SqlParameter PasswordParam = new SqlParameter("@StatusID", dto.Password);
            command.Parameters.Add(PasswordParam);

            SqlParameter FirstNameParam = new SqlParameter("@FirstName", dto.FirstName);
            command.Parameters.Add(FirstNameParam);

            SqlParameter LastNameParam = new SqlParameter("@LastName", dto.LastName);
            command.Parameters.Add(LastNameParam);

            return command.ExecuteNonQuery();
        }
    }
}
