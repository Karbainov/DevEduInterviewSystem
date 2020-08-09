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
        public int DeleteCourse_CandidateByID(SqlConnection connection, Course_CandidateDTO course_candidate)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("DeleteCourse_CandidateByID", connection);

            SqlParameter IDParam = new SqlParameter("@ID", course_candidate.ID);
            command.Parameters.Add(IDParam);

            return command.ExecuteNonQuery();
        }
        public int SelectAllCourse_Candidate(SqlConnection connection, Course_CandidateDTO course_candidate)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectAllCourse_Candidate", connection);

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
        public int UpdateCourse_CandidateByID(SqlConnection connection, StageDTO stage, int ID)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("UpdateCourse_CandidateByID", connection);

            SqlParameter IDParam = new SqlParameter("@ID", ID);
            command.Parameters.Add(IDParam);

            SqlParameter NameParam = new SqlParameter("@Name", stage.Name);
            command.Parameters.Add(NameParam);



            return command.ExecuteNonQuery();
        }
    }
}
