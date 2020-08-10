using DevEduInterviewSystem.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DevEduInterviewSystem.DAL.StoredProcedures.CRUD
{
    public class UserRoleCRUD
    {
        public int AddUserRole(SqlConnection connection, UserRoleDTO userRole)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("AddRole", connection);

            SqlParameter UserID = new SqlParameter("@UserID", userRole.UserID);
            command.Parameters.Add(UserID);

            SqlParameter RoleID = new SqlParameter("@RoleID", userRole.RoleID);
            command.Parameters.Add(RoleID);

            return command.ExecuteNonQuery();
        }

        public int DeleteUserRoleByID(SqlConnection connection, int ID)
        {
            connection.Open();
            string sqlExpression = "DeleteUserRoleByID";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter IDParam = new SqlParameter("@ID", ID);
            command.Parameters.Add(IDParam);

            return command.ExecuteNonQuery();
        }

        public int SelectAllUserRole(SqlConnection connection)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectAllUserRole", connection);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows) // если есть данные
            {
                // выводим названия столбцов
                Console.WriteLine($"id \t UserID \t RoleID");

                while (reader.Read()) // построчно считываем данные
                {
                    int id = (int)reader["ID"];
                    int UserID = (int)reader["UserID"];
                    int RoleID = (int)reader["RoleID"];
                    Console.WriteLine($"{id} \t{UserID} \t{RoleID} ");
                }
            }
            reader.Close();

            SqlCommand countRows = new SqlCommand("SELECT COUNT(*) FROM USERROLE", connection);
            int count = (int)countRows.ExecuteScalar();

            return count;
        }

        public int SelectUserRoleByID(SqlConnection connection, int ID)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectUserRoleByID", connection);

            SqlParameter IDParam = new SqlParameter("@ID", ID);
            command.Parameters.Add(IDParam);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows) // если есть данные
            {
                // выводим названия столбцов
                Console.WriteLine($"id \t UserID \t RoleID");

                while (reader.Read()) // построчно считываем данные
                {
                    int id = (int)reader["id"];
                    int UserID = (int)reader["UserID"];
                    int RoleID = (int)reader["RoleID"];

                    Console.WriteLine($"{id} \t{UserID} \t{RoleID}");
                }
            }
            reader.Close();
            return (int)command.ExecuteScalar();
        }

        public int UpdateUserRoleByID(SqlConnection connection, UserRoleDTO userRole, int ID)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("UpdateUserRoleByID", connection);

            SqlParameter IDParam = new SqlParameter("@ID", ID);
            command.Parameters.Add(IDParam);

            SqlParameter UserID = new SqlParameter("@UserID", userRole.UserID);
            command.Parameters.Add(UserID);

            SqlParameter RoleID = new SqlParameter("@RoleID", userRole.RoleID);
            command.Parameters.Add(RoleID);

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
