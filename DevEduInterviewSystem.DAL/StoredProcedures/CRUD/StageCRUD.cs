using DevEduInterviewSystem.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DevEduInterviewSystem.DAL.StoredProcedures.CRUD
{
    public class StageCRUD
    {
        public int AddStage(SqlConnection connection, StageDTO stage)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("AddStage", connection);

            SqlParameter NameParam = new SqlParameter("@Name", stage.Name);
            command.Parameters.Add(NameParam);                    

            return command.ExecuteNonQuery();
        }

        public int DeleteStageByID(SqlConnection connection, int ID)
        {
            connection.Open();
            string sqlExpression = "DeleteStageByID";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter IDParam = new SqlParameter("@ID", ID);
            command.Parameters.Add(IDParam);

            return command.ExecuteNonQuery();
        }

        public int SelectAllStage(SqlConnection connection)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectAllStage", connection);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows) // если есть данные
            {
                // выводим названия столбцов
                Console.WriteLine($"id \t Name");

                while (reader.Read()) // построчно считываем данные
                {
                    var id = reader["id"];
                    string Name = (string)reader["Name"];
                    

                    Console.WriteLine($"{id} \t{Name} ");
                }
            }
            reader.Close();

            return (int)command.ExecuteScalar();
        }

        public int SelectStageByID(SqlConnection connection, int ID)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectStageByID", connection);

            SqlParameter IDParam = new SqlParameter("@ID", ID);
            command.Parameters.Add(IDParam);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows) // если есть данные
            {
                // выводим названия столбцов
                Console.WriteLine($"id \t Name");

                while (reader.Read()) // построчно считываем данные
                {
                    var id = reader["id"];
                    int Name = (int)reader["Name"];


                    Console.WriteLine($"{id} \t{Name} ");
                }
            }
            reader.Close();

            return (int)command.ExecuteScalar();
        }

        public int UpdateStageByID(SqlConnection connection, StageDTO stage, int ID)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("UpdateStageByID", connection);

            SqlParameter IDParam = new SqlParameter("@ID", ID);
            command.Parameters.Add(IDParam);

            SqlParameter NameParam = new SqlParameter("@Name", stage.Name);
            command.Parameters.Add(NameParam);

           

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
