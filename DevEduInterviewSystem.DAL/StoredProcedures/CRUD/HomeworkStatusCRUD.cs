using DevEduInterviewSystem.DAL.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Text;

namespace DevEduInterviewSystem.DAL.StoredProcedures.CRUD
{
    public class HomeworkStatusCRUD
    {
        public int Add(SqlConnection connection, HomeworkStatusDTO homeworkStatus)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("AddHomeworkStatus", connection);

            SqlParameter NameParam = new SqlParameter("@Name", homeworkStatus.Name);
            command.Parameters.Add(NameParam);

            return command.ExecuteNonQuery();
        }

        public int DeleteByID(SqlConnection connection, int ID)
        {
            connection.Open();
            string sqlExpression = "DeleteHomeworkStatusByID";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter IDParam = new SqlParameter("@ID", ID);
            command.Parameters.Add(IDParam);

            return command.ExecuteNonQuery();
        }

        public int SelectAll(SqlConnection connection)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectAllHomeworkStatus", connection);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows) // если есть данные
            {
                // выводим названия столбцов
                Console.WriteLine($"id \t Name");

                while (reader.Read()) // построчно считываем данные
                {
                    int id = (int)reader["id"];
                    string Name = (string)reader["Name"];


                    Console.WriteLine($"{id} \t{Name} ");
                }
            }
            reader.Close();

            return (int)command.ExecuteScalar();
        }

        public int SelectByID(SqlConnection connection, int ID)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectHomeworkStatusByID", connection);

            SqlParameter IDParam = new SqlParameter("@ID", ID);
            command.Parameters.Add(IDParam);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows) // если есть данные
            {
                // выводим названия столбцов
                Console.WriteLine($"id \t Name");

                while (reader.Read()) // построчно считываем данные
                {
                    int id = (int)reader["id"];
                    string Name = (string)reader["Name"];


                    Console.WriteLine($"{id} \t{Name} ");
                }
            }
            reader.Close();

            return (int)command.ExecuteScalar();
        }
        public int UpdateByID(SqlConnection connection, HomeworkStatusDTO homeworkStatus, int ID)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("UpdateHomeworkStatusByID", connection);

            SqlParameter IDParam = new SqlParameter("@ID", ID);
            command.Parameters.Add(IDParam);

            SqlParameter NameParam = new SqlParameter("@Name", homeworkStatus.Name);
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
