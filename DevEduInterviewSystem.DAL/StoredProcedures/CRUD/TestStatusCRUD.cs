using System;
using System.Data.SqlClient;
using DevEduInterviewSystem.DAL.DTO;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.StoredProcedures.CRUD
{
    public class TestStatusCRUD
    {
        public int AddTestStatus(SqlConnection connection, TestStatusDTO testStatus)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("AddTestStatus", connection);

            SqlParameter CandidateIDParam = new SqlParameter("@Name", testStatus.Name);
            command.Parameters.Add(CandidateIDParam);

            return command.ExecuteNonQuery();
        }

        public int DeleteTestStatusByID(SqlConnection connection, int ID)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("DeleteTestStatusByID", connection);

            SqlParameter IDParam = new SqlParameter("@ID", ID);
            command.Parameters.Add(IDParam);

            return command.ExecuteNonQuery();
        }

        public int SelectAllTestStatus(SqlConnection connection)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectAllTestStatus", connection);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows) // если есть данные
            {
                while (reader.Read()) // построчно считываем данные
                {
                    int ID = (int)reader["id"];                    
                    var Name = (string)reader["Name"];

                    Console.WriteLine($"{ID} \t{Name}");
                }
            }
            reader.Close();


            SqlCommand countRows = new SqlCommand("SELECT COUNT(*) FROM TestStatus", connection);
            int count = (int)countRows.ExecuteScalar();

            return count;
        }

        public int SelectTestStatusByID(SqlConnection connection, int ID)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectTestStatusByID", connection);

            SqlParameter IDParam = new SqlParameter("@ID", ID);
            command.Parameters.Add(IDParam);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows) // если есть данные
            {
                while (reader.Read()) // построчно считываем данные
                {
                    int id = (int)reader["id"];
                    var Name = (string)reader["Name"];

                    Console.WriteLine($"{id} \t{Name}");
                }
            }
            reader.Close();

            return (int)command.ExecuteScalar();
        }

        public int UpdateTestStatusByID(SqlConnection connection, TestStatusDTO testStatus, int ID)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("UpdateTestStatusByID", connection);

            SqlParameter IDParam = new SqlParameter("@ID", ID);
            command.Parameters.Add(IDParam);

            SqlParameter CandidateIDParam = new SqlParameter("@Name", testStatus.Name);
            command.Parameters.Add(CandidateIDParam);

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
