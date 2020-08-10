using System;
using System.Data.SqlClient;
using DevEduInterviewSystem.DAL.DTO;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.StoredProcedures.CRUD
{
    public class RoleCRUD
    {
        public int AddRole(SqlConnection connection, RoleDTO role)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("AddRole", connection);

            SqlParameter TypeOfRoleParam = new SqlParameter("@TypeOfRole", role.TypeOfRole);
            command.Parameters.Add(TypeOfRoleParam);

            return command.ExecuteNonQuery();
        }

        public int DeleteRoleByID(SqlConnection connection, int ID)
        {
            connection.Open();
            string sqlExpression = "DeleteRoleByID";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter IDParam = new SqlParameter("@ID", ID);
            command.Parameters.Add(IDParam);

            return command.ExecuteNonQuery();
        }

        public int SelectAllRole(SqlConnection connection)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectAllRole", connection);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows) // если есть данные
            {
                // выводим названия столбцов
                Console.WriteLine($"id \t TypeOfRole");

                while (reader.Read()) // построчно считываем данные
                {
                    int id = (int)reader["id"];
                    string TypeOfRole = (string)reader["TypeOfRole"];

                    Console.WriteLine($"{id} \t{TypeOfRole} ");
                }
            }
            reader.Close();

            SqlCommand countRows = new SqlCommand("SELECT COUNT(*) FROM Role", connection);
            int count = (int)countRows.ExecuteScalar();

            return count;
        }

        public int SelectRoleByID(SqlConnection connection, int ID)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectRoleByID", connection);

            SqlParameter IDParam = new SqlParameter("@ID", ID);
            command.Parameters.Add(IDParam);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows) // если есть данные
            {
                // выводим названия столбцов
                Console.WriteLine($"id \tTypeOfRole");

                while (reader.Read()) // построчно считываем данные
                {
                    int id = (int)reader["id"];
                    string TypeOfRole = (string)reader["TypeOfRole"];

                    Console.WriteLine($"{id} \t{TypeOfRole}");
                }
            }
            reader.Close();
            return (int)command.ExecuteScalar();
        }

        public int UpdateRoleByID(SqlConnection connection, RoleDTO role, int ID)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("UpdateRoleByID", connection);

            SqlParameter IDParam = new SqlParameter("@ID", ID);
            command.Parameters.Add(IDParam);

            SqlParameter TypeOfRoleParam = new SqlParameter("@TypeOfRole", role.TypeOfRole);
            command.Parameters.Add(TypeOfRoleParam);

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
