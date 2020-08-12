using DevEduInterviewSystem.DAL.DTO;
using System;
using System.Data.SqlClient;

namespace DevEduInterviewSystem.DAL.StoredProcedures.CRUD
{
    public class InterviewStatusCRUD
    {
        public int AddInterviewStatus(SqlConnection connection, InterviewStatusDTO interviewStatus)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("AddInterviewStatus", connection);

            SqlParameter NameParam = new SqlParameter("@Name", interviewStatus.Name);
            command.Parameters.Add(NameParam);

            return command.ExecuteNonQuery();
        }

        public int DeleteInterviewStatusByID(SqlConnection connection, int ID)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("DeleteInterviewStatusByID", connection);

            SqlParameter IDParam = new SqlParameter("@ID", ID);
            command.Parameters.Add(IDParam);

            return command.ExecuteNonQuery();
        }

        public int SelectAllInterviewStatus(SqlConnection connection)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectAllInterviewStatus", connection);

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

        public int SelectInterviewStatusByID(SqlConnection connection, int ID)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectInterviewStatusByID", connection);

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
                    int Name = (int)reader["Name"];


                    Console.WriteLine($"{id} \t{Name} ");
                }
            }
            reader.Close();

            return (int)command.ExecuteScalar();
        }

        public int UpdateInterviewStatusByID(SqlConnection connection, InterviewStatusDTO interviewStatus, int ID)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("UpdateInterviewStatusByID", connection);

            SqlParameter IDParam = new SqlParameter("@ID", ID);
            command.Parameters.Add(IDParam);

            SqlParameter NameParam = new SqlParameter("@Name", interviewStatus.Name);
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
