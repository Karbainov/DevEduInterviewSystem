using DevEduInterviewSystem.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DevEduInterviewSystem.DAL.StoredProcedures.CRUD
{
    public class UserInterviewCRUD
    {
        public int AddUser_Interview(SqlConnection connection, UserInterviewDTO userInterview)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("AddUser_Interview", connection);

            SqlParameter InterviewIDParam = new SqlParameter("@InterviewID", userInterview.InterviewID);
            command.Parameters.Add(InterviewIDParam);

            SqlParameter userInterviewParam = new SqlParameter("@UserID", userInterview.UserID);
            command.Parameters.Add(userInterviewParam);

            return command.ExecuteNonQuery();
        }

        public int DeleteUser_InterviewByID(SqlConnection connection, int ID)
        {
            connection.Open();
            string sqlExpression = "DeleteUser_InterviewByID";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter IDParam = new SqlParameter("@ID", ID);
            command.Parameters.Add(IDParam);

            return command.ExecuteNonQuery();
        }

        public int SelectAllUser_Interview(SqlConnection connection)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectAllUser_Interview", connection);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows) // если есть данные
            {
                // выводим названия столбцов
                Console.WriteLine($"id \t InterviewID \t UserID");

                while (reader.Read()) // построчно считываем данные
                {
                    var id = reader["id"];
                    int InterviewID = (int)reader["InterviewID"];
                    int UserID = (int)reader["UserID"];

                    Console.WriteLine($"{id} \t{InterviewID} \t{UserID} ");
                }
            }
            reader.Close();

            return (int)command.ExecuteScalar();
        }

        public int SelectUser_InterviewByID(SqlConnection connection, int ID)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectUser_InterviewByID", connection);

            SqlParameter IDParam = new SqlParameter("@ID", ID);
            command.Parameters.Add(IDParam);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows) // если есть данные
            {
                // выводим названия столбцов
                Console.WriteLine($"id \t InterviewID \t UserID");

                while (reader.Read()) // построчно считываем данные
                {
                    var id = reader["id"];
                    int InterviewID = (int)reader["InterviewID"];
                    int UserID = (int)reader["UserID"];

                    Console.WriteLine($"{id} \t{InterviewID} \t{UserID} ");
                }
            }
            reader.Close();

            return (int)command.ExecuteScalar();
        }

        public int UpdateUser_InterviewByID(SqlConnection connection, UserInterviewDTO userInterview, int ID)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("UpdateUser_InterviewByID", connection);

            SqlParameter IDParam = new SqlParameter("@ID", ID);
            command.Parameters.Add(IDParam);

            SqlParameter InterviewIDParam = new SqlParameter("@InterviewID", userInterview.InterviewID);
            command.Parameters.Add(InterviewIDParam);

            SqlParameter UserIDParam = new SqlParameter("@UserID", userInterview.UserID);
            command.Parameters.Add(UserIDParam);



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
