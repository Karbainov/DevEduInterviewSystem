using DevEduInterviewSystem.DAL.DTO;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;


namespace DevEduInterviewSystem.DAL.StoredProcedures.CRUD
{
    public class HomeworkCRUD
    {
        public int AddHomework(SqlConnection connection, HomeworkDTO homework)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("AddHomework", connection);

            SqlParameter CandidateParam = new SqlParameter("@CandidateID", homework.CandidateID);
            command.Parameters.Add(CandidateParam);

            SqlParameter HomeworkStatusParam = new SqlParameter("@HomeworkStatusID", homework.HomeworkStatusID);
            command.Parameters.Add(HomeworkStatusParam);

            SqlParameter TestStatusParam = new SqlParameter("@TestStatusID", homework.TestStatusID);
            command.Parameters.Add(TestStatusParam);

            SqlParameter HomeworkDateParam = new SqlParameter("@HomeworkDate", homework.HomeworkDate);
            command.Parameters.Add(HomeworkDateParam);

            return command.ExecuteNonQuery();
        }

        public int DeleteHomeworkByID(SqlConnection connection, int ID)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("DeleteHomeworkByID", connection);

            SqlParameter IDParam = new SqlParameter("@ID", ID);
            command.Parameters.Add(IDParam);

            return command.ExecuteNonQuery();
        }

        public int SelectAllHomework(SqlConnection connection)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectAllHomework", connection);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows) 
            {
               
                Console.WriteLine($"id \t CandidateID \t HomeworkStatusID \t TestStatusID \t HomeworkDate ");

                while (reader.Read()) 
                {
                    int id = (int)reader["id"];
                    int CandidateID = (int)reader["CandidateID"];
                    int HomeworkStatusID = (int)reader["HomeworkStatusID"];
                    int TestStatusID = (int)reader["TestStatusID"];
                    var HomeworkDate = (DateTime)reader["HomeworkDate"];

                    Console.WriteLine($"{id} \t{CandidateID} \t{HomeworkStatusID} \t{TestStatusID} \t{HomeworkDate}");
                }
            }
            reader.Close();


            command.CommandText = "SELECT COUNT(*) FROM Homework";
            int count = (int)command.ExecuteScalar();

            return count;
        }

        public int SelectHomeworkByID(SqlConnection connection, int ID)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectHomeworkByID", connection);

            SqlParameter IDParam = new SqlParameter("@ID", ID);
            command.Parameters.Add(IDParam);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows) 
            {
                
                Console.WriteLine($"id \t CandidateID \t HomeworkStatusID \t TestStatusID \t HomeworkDate ");

                while (reader.Read()) 
                {
                    int id = (int)reader["id"];
                    int CandidateID = (int)reader["CandidateID"];
                    int HomeworkStatusID = (int)reader["HomeworkStatusID"];
                    int TestStatusID = (int)reader["Homework"];
                    var HomeworkDate = (DateTime)reader["HomeworkDate"];

                    Console.WriteLine($"{id} \t{CandidateID} \t{HomeworkStatusID} \t{TestStatusID} \t{HomeworkDate}");
                }
            }
            reader.Close();

            return (int)command.ExecuteScalar();
        }

        public int UpdateHomeworkByID(SqlConnection connection, HomeworkDTO homework, int ID)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("UpdateHomeworkByID", connection);

            SqlParameter IDParam = new SqlParameter("@ID", ID);
            command.Parameters.Add(IDParam);

            SqlParameter CandidateParam = new SqlParameter("@CandidateID", homework.CandidateID);
            command.Parameters.Add(CandidateParam);

            SqlParameter HomeworkStatusParam = new SqlParameter("@HomeworkStatusID", homework.HomeworkStatusID);
            command.Parameters.Add(HomeworkStatusParam);

            SqlParameter TestStatusParam = new SqlParameter("@TestStatusID", homework.TestStatusID);
            command.Parameters.Add(TestStatusParam);

            SqlParameter HomeworkDateParam = new SqlParameter("@HomeworkDate", homework.HomeworkDate);
            command.Parameters.Add(HomeworkDateParam); 

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

