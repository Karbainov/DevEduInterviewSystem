using DevEduInterviewSystem.DAL.DTO;
using System;
using System.Data.SqlClient;


namespace DevEduInterviewSystem.DAL.StoredProcedures.CRUD
{
    public class InterviewCRUD
    {
        public int AddInterview(SqlConnection connection, InterviewDTO interview)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("AddInterview", connection);

            SqlParameter CandidateParam = new SqlParameter("@CandidateID", interview.CandidateID);
            command.Parameters.Add(CandidateParam);

            SqlParameter InterviewStatusParam = new SqlParameter("@InterviewStatusID", interview.InterviewStatusID);
            command.Parameters.Add(InterviewStatusParam);

            SqlParameter AttemptParam = new SqlParameter("@AttemptID", interview.Attempt);
            command.Parameters.Add(AttemptParam);

            SqlParameter DateTimeInterviewParam = new SqlParameter("@DateTimeInterview", interview.DateTimeInterview);
            command.Parameters.Add(DateTimeInterviewParam);

            return command.ExecuteNonQuery();
        }

        public int DeleteInterviewByID(SqlConnection connection, int ID)
        {
            connection.Open();
            string sqlExpression = "DeleteInterviewByID";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter IDParam = new SqlParameter("@ID", ID);
            command.Parameters.Add(IDParam);

            return command.ExecuteNonQuery();
        }

        public int SelectAllCandidate(SqlConnection connection)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectAllInterview", connection);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows) // если есть данные
            {
                // выводим названия столбцов
                Console.WriteLine($"id \t CandidateID \t InterviewStatusID \t Attempt \t DateTimeInterview ");

                while (reader.Read()) // построчно считываем данные
                {
                    int id = (int)reader["id"];
                    int CandidateID = (int)reader["CandidateID"];
                    int InterviewStatusID = (int)reader["InterviewStatusID"];
                    int Attempt = (int)reader["Attempt"];
                    var DateTimeInterview = (DateTime)reader["DateTimeInterview"];

                    Console.WriteLine($"{id} \t{CandidateID} \t{InterviewStatusID} \t{Attempt} \t{DateTimeInterview}");
                }
            }
            reader.Close();


            command.CommandText = "SELECT COUNT(*) FROM Interview";
            int count = (int)command.ExecuteScalar();

            return count;
        }

        public int SelectInterviewByID(SqlConnection connection, int ID)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectInterviewByID", connection);

            SqlParameter IDParam = new SqlParameter("@ID", ID);
            command.Parameters.Add(IDParam);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows) // если есть данные
            {
                // выводим названия столбцов
                Console.WriteLine($"id \t CandidateID \t InterviewStatusID \t Attempt \t DateTimeInterview ");

                while (reader.Read()) // построчно считываем данные
                {
                    int id = (int)reader["id"];
                    int CandidateID = (int)reader["CandidateID"];
                    int InterviewStatusID = (int)reader["InterviewStatusID"];
                    int Attempt = (int)reader["Attempt"];
                    var DateTimeInterview = (DateTime)reader["DateTimeInterview"];

                    Console.WriteLine($"{id} \t{CandidateID} \t{InterviewStatusID} \t{Attempt} \t{DateTimeInterview}");
                }
            }
            reader.Close();

            return (int)command.ExecuteScalar();
        }

        public int UpdateInterviewByID(SqlConnection connection, InterviewDTO interview, int ID)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("UpdateInterviewByID", connection);

            SqlParameter IDParam = new SqlParameter("@ID", ID);
            command.Parameters.Add(IDParam);

            SqlParameter CandidateParam = new SqlParameter("@CandidateID", interview.CandidateID);
            command.Parameters.Add(CandidateParam);

            SqlParameter InterviewStatusParam = new SqlParameter("@InterviewStatusID", interview.InterviewStatusID);
            command.Parameters.Add(InterviewStatusParam);

            SqlParameter AttemptParam = new SqlParameter("@AttemptID", interview.Attempt);
            command.Parameters.Add(AttemptParam);

            SqlParameter DateTimeInterviewParam = new SqlParameter("@DateTimeInterview", interview.DateTimeInterview);
            command.Parameters.Add(DateTimeInterviewParam); 

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

