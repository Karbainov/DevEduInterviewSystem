using DevEduInterviewSystem.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DevEduInterviewSystem.DAL.StoredProcedures.CRUD
{
    public class FeedbackCRUD
    {
        public int Add(SqlConnection connection, FeedbackDTO feedback)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("AddFeedback", connection);

            SqlParameter StageChangedIDParam = new SqlParameter("@StageChangedID", feedback.StageChangedID);
            command.Parameters.Add(StageChangedIDParam);


            SqlParameter UserParam = new SqlParameter("@UserID", feedback.UserID);
            command.Parameters.Add(UserParam);

            SqlParameter MessageParam = new SqlParameter("@Message", feedback.Message);
            command.Parameters.Add(MessageParam);

            SqlParameter TimeFeedbackParam = new SqlParameter("@TimeFeedback", feedback.TimeFeedback);
            command.Parameters.Add(TimeFeedbackParam);

            return command.ExecuteNonQuery();

        }

        public int DeleteByID(SqlConnection connection, int ID)
        {
            connection.Open();
            string sqlExpression = "DeleteFeedbackByID";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter IDParam = new SqlParameter("@ID", ID);
            command.Parameters.Add(IDParam);

            return command.ExecuteNonQuery();
        }

        public int SelectAll(SqlConnection connection)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectAllFeedback", connection);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                Console.WriteLine("{0} \t{1} \t{2} \t{3} \t{4}", reader.GetName(0), reader.GetName(1),
                                     reader.GetName(2), reader.GetName(3), reader.GetName(3));
                while (reader.Read())
                {
                    var id = reader["id"];
                    int StageChangedID = (int)reader["StageChangedID"];
                    int UserID = (int)reader["UserID"];
                    string Message = (string)reader["Message"];
                    var TimeFeedback = reader["TimeFeedback"];

                    Console.WriteLine("{0} \t{1} \t{2} \t{3} \t{4}", id, StageChangedID, UserID, Message, TimeFeedback);

                }
            }
            reader.Close();

            command.CommandText = "SELECT COUNT(*) FROM Feedback";
            int count = (int)command.ExecuteScalar();

            return count;
        }

        public int SelectAllByID(SqlConnection connection, int ID)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectAllFeedbackByID", connection);

            SqlParameter IDParam = new SqlParameter("@ID", ID);
            command.Parameters.Add(IDParam);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                Console.WriteLine("{0} \t{1} \t{2} \t{3} \t{4}", reader.GetName(0), reader.GetName(1),
                                     reader.GetName(2), reader.GetName(3), reader.GetName(3));
                while (reader.Read())
                {
                    var id = reader["id"];
                    int StageChangedID = (int)reader["StageChangedID"];
                    int UserID = (int)reader["UserID"];
                    string Message = (string)reader["Message"];
                    var TimeFeedback = reader["TimeFeedback"];

                    Console.WriteLine("{0} \t{1} \t{2} \t{3} \t{4}", id, StageChangedID, UserID, Message, TimeFeedback);

                }
            }
            reader.Close();
            return (int)command.ExecuteScalar();
        }

        public int UpdateByID(SqlConnection connection, FeedbackDTO feedback, int ID)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectFeedbackByID", connection);

            SqlParameter IDParam = new SqlParameter("@ID", ID);
            command.Parameters.Add(IDParam);

            SqlParameter StageChangedParam = new SqlParameter("@StageChangedID", feedback.StageChangedID);
            command.Parameters.Add(StageChangedParam);


            SqlParameter UserParam = new SqlParameter("@UserID", feedback.UserID);
            command.Parameters.Add(UserParam);

            SqlParameter MessageParam = new SqlParameter("@Message", feedback.Message);
            command.Parameters.Add(MessageParam);

            SqlParameter TimeFeedbackParam = new SqlParameter("@TimeFeedback", feedback.Message);
            command.Parameters.Add(TimeFeedbackParam);

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





