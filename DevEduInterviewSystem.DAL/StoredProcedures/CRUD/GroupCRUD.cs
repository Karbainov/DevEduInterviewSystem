using DevEduInterviewSystem.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DevEduInterviewSystem.DAL.StoredProcedures.CRUD
{
    public class GroupCRUD
    {
        public int AddGroup(SqlConnection connection, GroupDTO group)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("AddGroup", connection);

            SqlParameter CourseParam = new SqlParameter("@CourseID", group.CourseID);
            command.Parameters.Add(CourseParam);

            SqlParameter NameParam = new SqlParameter("@NameID", group.Name);
            command.Parameters.Add(NameParam);

            SqlParameter StartDateParam = new SqlParameter("@StartDate", group.StartDate);
            command.Parameters.Add(StartDateParam);

            SqlParameter EndDateParam = new SqlParameter("@EndDateID", group.EndDate);
            command.Parameters.Add(EndDateParam);

            return command.ExecuteNonQuery();
        }

        public int DeleteGroupByID(SqlConnection connection, int ID)
        {
            connection.Open();
            string sqlExpression = "DeleteGroupByID";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter IDParam = new SqlParameter("@ID", ID);
            command.Parameters.Add(IDParam);

            return command.ExecuteNonQuery();
        }

        public int SelectAllGroup(SqlConnection connection)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectAllGroup", connection);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                Console.WriteLine($"id \t CourseID \t Name \t StartDate \t EndDate \t ");

                while (reader.Read())
                {
                    var id = reader["id"];
                    int CourseID = (int)reader["CourseID"];
                    var Name = (string)reader["Name"];
                    var StartDate = (DateTime)reader["StartName"];
                    var EndDate = (DateTime)reader["EndName"];

                    Console.WriteLine($"{id} \t {CourseID} \t {Name} \t {StartDate} \t {EndDate}");
                }
            }
            reader.Close();

            SqlCommand countRows = new SqlCommand("SELECT COUNT(*) FROM Group", connection);
            int count = (int)countRows.ExecuteScalar();

            return count;
        }

        public int SelectGroupByID(SqlConnection connection, int ID)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectGroupByID", connection);

            SqlParameter IDParam = new SqlParameter("@ID", ID);
            command.Parameters.Add(IDParam);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows) // если есть данные
            {
                // выводим названия столбцов
                Console.WriteLine($"id \t CourseID \t Name \t StartDate \t EndDate");

                while (reader.Read()) // построчно считываем данные
                {
                    var id = reader["id"];
                    int CourseID = (int)reader["CourseID"];
                    string Name = (string)reader["Name"];
                    var StartDate = (DateTime)reader["StartDate"];
                    var EndDate = (DateTime)reader["EndDate"];

                    Console.WriteLine($"{id} \t {CourseID} \t{Name} \t{StartDate} \t{EndDate}");
                }
            }
            reader.Close();

            return (int)command.ExecuteScalar();
        }

        public int UpdateGroupByID(SqlConnection connection, GroupDTO group, int ID)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("UpdateGroupByID", connection);

            SqlParameter IDParam = new SqlParameter("@ID", ID);
            command.Parameters.Add(IDParam);

            SqlParameter CourseParam = new SqlParameter("@CourseID", group.CourseID);
            command.Parameters.Add(CourseParam);

            SqlParameter NameParam = new SqlParameter("@Name", group.Name);
            command.Parameters.Add(NameParam);

            SqlParameter StartDateParam = new SqlParameter("@StartDate", group.StartDate);
            command.Parameters.Add(StartDateParam);

            SqlParameter EndDateParam = new SqlParameter("@EndDate", group.EndDate);
            command.Parameters.Add(EndDateParam);

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
