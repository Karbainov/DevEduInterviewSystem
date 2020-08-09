using DevEduInterviewSystem.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DevEduInterviewSystem.DAL.StoredProcedures.CRUD
{
    public class CourseCRUD
    {
        private SqlCommand ReferenceToProcedure(string sqlExpression, SqlConnection connection)
        {
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            return command;
        }

        public int AddCourse(SqlConnection connection, string course)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("AddCourse", connection);

            SqlParameter nameCourseParam = new SqlParameter("@Name", course);
            command.Parameters.Add(nameCourseParam);

            return command.ExecuteNonQuery();
        }
        public int DeleteCourseByID(SqlConnection connection, int ID)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("DeleteCourseByID", connection);

            SqlParameter IDParam = new SqlParameter("@ID", ID);
            command.Parameters.Add(IDParam);

            return command.ExecuteNonQuery();
        }
        public int SelectAllCourse(SqlConnection connection)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectAllCourse", connection);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows) // если есть данные
            {
                // выводим названия столбцов
                Console.WriteLine($"ID \tCourseName");

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

        public int SelectCourseByID(SqlConnection connection, int ID)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectCourseByID", connection);

            SqlParameter IDParam = new SqlParameter("@ID", ID);
            command.Parameters.Add(IDParam);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows) // если есть данные
            {
                // выводим названия столбцов
                Console.WriteLine($"ID \tCourseName");

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
        public int UpdateCourseByID(SqlConnection connection, string course, int ID)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("UpdateCourseByID", connection);

            SqlParameter IDParam = new SqlParameter("@ID", ID);
            command.Parameters.Add(IDParam);

            SqlParameter nameCourseParam = new SqlParameter("@Name", course);
            command.Parameters.Add(nameCourseParam);



            return command.ExecuteNonQuery();
        }
    }
}
