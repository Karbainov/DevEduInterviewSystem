using DevEduInterviewSystem.DAL.DTO;
using System;
using System.Data.SqlClient;

namespace DevEduInterviewSystem.DAL.StoredProcedures.CRUD
{
    public class Course_CandidateCRUD
    {
        private SqlCommand ReferenceToProcedure(string sqlExpression, SqlConnection connection)
        {
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            return command;
        }

        public int AddCourse_Candidate(SqlConnection connection, Course_CandidateDTO course_candidate)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("AddCourse_Candidate", connection);

            SqlParameter CourseIDParam = new SqlParameter("@CourseID", course_candidate.CourseID);
            command.Parameters.Add(CourseIDParam);

            SqlParameter CandidateIDParam = new SqlParameter("@CandidateID", course_candidate.CandidateID);
            command.Parameters.Add(CandidateIDParam);

            return command.ExecuteNonQuery();
        }
        public int DeleteCourse_CandidateByID(SqlConnection connection, int ID)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("DeleteCourse_CandidateByID", connection);

            SqlParameter IDParam = new SqlParameter("@ID", ID);
            command.Parameters.Add(IDParam);

            return command.ExecuteNonQuery();
        }
        public int SelectAllCourse_Candidate(SqlConnection connection)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectAllCourse_Candidate", connection);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows) // если есть данные
            {
                // выводим названия столбцов
                Console.WriteLine($"ID \t CourseID \t CandidateID");

                while (reader.Read()) // построчно считываем данные
                {
                    int id = (int)reader["id"];
                    int courseID = (int)reader["CourseID"];
                    int candidateID = (int)reader["CandidateID"];


                    Console.WriteLine($"{id} \t{courseID} \t{candidateID}");
                }
            }
            reader.Close();

            return (int)command.ExecuteScalar();
        }

        public int SelectCourse_CandidateByID(SqlConnection connection, int ID)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectCourse_CandidateByID", connection);

            SqlParameter IDParam = new SqlParameter("@ID", ID);
            command.Parameters.Add(IDParam);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows) // если есть данные
            {
                // выводим названия столбцов
                Console.WriteLine($"ID \t CourseID \t CandidateID");

                while (reader.Read()) // построчно считываем данные
                {
                    int id = (int)reader["id"];
                    int courseID = (int)reader["CourseID"];
                    int candidateID = (int)reader["CandidateID"];
                    Console.WriteLine($"{id} \t{courseID} \t{candidateID}");
                }
            }
            reader.Close();

            return (int)command.ExecuteScalar();
        }
        public int UpdateCourse_CandidateByID(SqlConnection connection, Course_CandidateDTO course_candidate, int ID)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("UpdateCourse_CandidateByID", connection);

            SqlParameter IDParam = new SqlParameter("@ID", ID);
            command.Parameters.Add(IDParam);

            SqlParameter CandidateIDParam = new SqlParameter("@CandidateID", course_candidate.CandidateID);
            command.Parameters.Add(CandidateIDParam);

            SqlParameter CourseIDParam = new SqlParameter("@CourseID", course_candidate.CourseID);
            command.Parameters.Add(CandidateIDParam);

            return command.ExecuteNonQuery();
        }
    }
}
