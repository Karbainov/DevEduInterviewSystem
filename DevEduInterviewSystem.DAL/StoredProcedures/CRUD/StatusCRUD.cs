using System;
using System.Data.SqlClient;
using DevEduInterviewSystem.DAL.DTO;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.StoredProcedures.CRUD
{
    public class StatusCRUD
    {
        public int AddStatus(SqlConnection connection, StatusDTO status)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("AddStatus", connection);

            SqlParameter CandidateIDParam = new SqlParameter("@Name", status.Name);
            command.Parameters.Add(CandidateIDParam);

            return command.ExecuteNonQuery();
        }

        public int DeleteStatusByID(SqlConnection connection, int ID)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("DeleteStatusByID", connection);

            SqlParameter IDParam = new SqlParameter("@ID", ID);
            command.Parameters.Add(IDParam);

            return command.ExecuteNonQuery();
        }

        public int SelectAllStatus(SqlConnection connection)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectAllStatus", connection);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows) 
            {
                while (reader.Read()) 
                {
                    int ID = (int)reader["id"];                    
                    var Name = (string)reader["Name"];

                    Console.WriteLine($"{ID} \t{Name}");
                }
            }
            reader.Close();


            SqlCommand countRows = new SqlCommand("SELECT COUNT(*) FROM Status", connection);
            int count = (int)countRows.ExecuteScalar();

            return count;
        }

        public int SelectStatusByID(SqlConnection connection, int ID)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectStatusByID", connection);

            SqlParameter IDParam = new SqlParameter("@ID", ID);
            command.Parameters.Add(IDParam);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows) 
            {
                while (reader.Read()) 
                {
                    int id = (int)reader["id"];
                    var Name = (string)reader["Name"];

                    Console.WriteLine($"{id} \t{Name}");
                }
            }
            reader.Close();

            return (int)command.ExecuteScalar();
        }

        public int UpdateStatusByID(SqlConnection connection, StatusDTO status, int ID)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("UpdateStatusByID", connection);

            SqlParameter IDParam = new SqlParameter("@ID", ID);
            command.Parameters.Add(IDParam);

            SqlParameter CandidateIDParam = new SqlParameter("@Name", status.Name);
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
