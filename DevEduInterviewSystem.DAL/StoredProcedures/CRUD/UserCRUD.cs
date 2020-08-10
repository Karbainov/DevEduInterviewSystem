using DevEduInterviewSystem.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DevEduInterviewSystem.DAL.StoredProcedures.CRUD
{
    public class UserCRUD
    {
        public int AddUser(SqlConnection connection, UserDTO user)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("AddUser", connection);

            SqlParameter LoginParam = new SqlParameter("@StageID", user.Login);
            command.Parameters.Add(LoginParam);

            SqlParameter PasswordParam = new SqlParameter("@StatusID", user.Password);
            command.Parameters.Add(PasswordParam);

            SqlParameter FirstNameParam = new SqlParameter("@FirstName", user.FirstName);
            command.Parameters.Add(FirstNameParam);

            SqlParameter LastNameParam = new SqlParameter("@LastName", user.LastName);
            command.Parameters.Add(LastNameParam);

            return command.ExecuteNonQuery();
        }

        public int DeleteCandidateByID(SqlConnection connection, int ID)
        {
            connection.Open();
            string sqlExpression = "DeleteUserByID";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter IDParam = new SqlParameter("@ID", ID);
            command.Parameters.Add(IDParam);

            return command.ExecuteNonQuery();
        }

        public int SelectAllCandidate(SqlConnection connection)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectAllUser", connection);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows) // если есть данные
            {
                // выводим названия столбцов
                Console.WriteLine($"id \t Login \t Password \t FirstName \t LastName");

                while (reader.Read()) // построчно считываем данные
                {
                    int id = (int)reader["id"];
                    string Login = (string)reader["Login"];
                    string Password = (string)reader["Password"];
                    string FirstName = (string)reader["FirstName"];
                    string LastName = (string)reader["LastName"];
                    Console.WriteLine($"{id} \t{Login} \t{Password} \t{FirstName} \t{LastName}");
                }
            }
            reader.Close();

            SqlCommand countRows = new SqlCommand("SELECT COUNT(*) FROM USER", connection);
            int count = (int)countRows.ExecuteScalar();

            return count;
        }

        public int SelectCandidateByID(SqlConnection connection, int ID)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectUserByID", connection);

            SqlParameter IDParam = new SqlParameter("@ID", ID);
            command.Parameters.Add(IDParam);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows) // если есть данные
            {
                // выводим названия столбцов
                Console.WriteLine($"id \t Login \t Password \t FirstName \t LastName");

                while (reader.Read()) // построчно считываем данные
                {
                    int id = (int)reader["id"];
                    string Login = (string)reader["Login"];
                    string Password = (string)reader["Password"];
                    string FirstName = (string)reader["FirstName"];
                    string LastName = (string)reader["LastName"];
                    Console.WriteLine($"{id} \t{Login} \t{Password} \t{FirstName} \t{LastName}");
                }
            }
            reader.Close();

            return (int)command.ExecuteScalar();
        }

        public int UpdateCandidateByID(SqlConnection connection, UserDTO user, int ID)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("UpdateCandidateByID", connection);

            SqlParameter IDParam = new SqlParameter("@ID", ID);
            command.Parameters.Add(IDParam);

            SqlParameter LoginParam = new SqlParameter("@StageID", user.Login);
            command.Parameters.Add(LoginParam);

            SqlParameter PasswordParam = new SqlParameter("@StatusID", user.Password);
            command.Parameters.Add(PasswordParam);

            SqlParameter FirstNameParam = new SqlParameter("@FirstName", user.FirstName);
            command.Parameters.Add(FirstNameParam);

            SqlParameter LastNameParam = new SqlParameter("@LastName", user.LastName);
            command.Parameters.Add(LastNameParam);

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
