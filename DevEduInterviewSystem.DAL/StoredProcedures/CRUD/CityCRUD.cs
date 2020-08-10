using DevEduInterviewSystem.DAL.DTO;
using System;
using System.Data.SqlClient;

namespace DevEduInterviewSystem.DAL.StoredProcedures.CRUD
{
    public class CityCRUD
    {
        private SqlCommand ReferenceToProcedure(string sqlExpression, SqlConnection connection)
        {
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            return command;
        }
        public int AddCity(SqlConnection connection, string city)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("AddCity", connection);

            SqlParameter CityNameParam = new SqlParameter("@Name", city);
            command.Parameters.Add(CityNameParam);

            return command.ExecuteNonQuery();
        }
        public int AddCity(SqlConnection connection, CityDTO city)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("AddCity", connection);

            SqlParameter CityNameParam = new SqlParameter("@Name", city.Name);
            command.Parameters.Add(CityNameParam);

            return command.ExecuteNonQuery();
        }
        public int DeleteCityByID(SqlConnection connection, int ID)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("DeleteCityByID", connection);

            SqlParameter IDParam = new SqlParameter("@ID", ID);
            command.Parameters.Add(IDParam);

            return command.ExecuteNonQuery();
        }
        public int SelectAllCity(SqlConnection connection)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectAllCity", connection);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows) // если есть данные
            {
                // выводим названия столбцов
                Console.WriteLine($"ID \tNameCity");

                while (reader.Read()) // построчно считываем данные
                {
                    int id = (int)reader["id"];
                    string name = (string)reader["Name"];

                    Console.WriteLine($"{id} \t{name}");
                }
            }
            reader.Close();

            return (int)command.ExecuteScalar();
        }

        public int SelectCityByID(SqlConnection connection, int ID)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectCityByID", connection);

            SqlParameter IDParam = new SqlParameter("@ID", ID);
            command.Parameters.Add(IDParam);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows) // если есть данные
            {
                // выводим названия столбцов
                Console.WriteLine($"ID \tNameCity");

                while (reader.Read()) // построчно считываем данные
                {
                    int id = (int)reader["id"];
                    string name = (string)reader["Name"];

                    Console.WriteLine($"{id} \t{name}");
                }
            }
            reader.Close();

            return (int)command.ExecuteScalar();
        }
        public int UpdateCityByID(SqlConnection connection, string city, int ID)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("UpdateCityByID", connection);

            SqlParameter IDParam = new SqlParameter("@ID", ID);
            command.Parameters.Add(IDParam);

            SqlParameter CityNameParam = new SqlParameter("@Name", city);
            command.Parameters.Add(CityNameParam);

            return command.ExecuteNonQuery();
        }
        public int UpdateCityByID(SqlConnection connection, CityDTO city, int ID)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("UpdateCityByID", connection);

            SqlParameter IDParam = new SqlParameter("@ID", ID);
            command.Parameters.Add(IDParam);

            SqlParameter CityNameParam = new SqlParameter("@Name", city.Name);
            command.Parameters.Add(CityNameParam);

            return command.ExecuteNonQuery();
        }
    }
}
