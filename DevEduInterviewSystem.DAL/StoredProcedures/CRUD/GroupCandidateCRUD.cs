using DevEduInterviewSystem.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DevEduInterviewSystem.DAL.StoredProcedures.CRUD
{
    public class GroupCandidateCRUD
    {
        public int AddGroupCandidate(SqlConnection connection, GroupCandidateDTO groupCandidate)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("AddGroup_Candidate", connection);

            SqlParameter GroupParam = new SqlParameter("@GroupID", groupCandidate.GroupID);
            command.Parameters.Add(GroupParam);

            SqlParameter CandidateParam = new SqlParameter("@CandidateID", groupCandidate.CandidateID);
            command.Parameters.Add(CandidateParam);

            return command.ExecuteNonQuery();
        }

        public int DeleteGroupCandidateByID(SqlConnection connection, int ID)
        {
            connection.Open();
            string sqlExpression = "DeleteGroup_CandidateByID";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter IDParam = new SqlParameter("@ID", ID);
            command.Parameters.Add(IDParam);

            return command.ExecuteNonQuery();
        }

        public int SelectAllGroupCandidate(SqlConnection connection)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectAllGroup_Candidate", connection);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows) // если есть данные
            {
                // выводим названия столбцов
                Console.WriteLine($"id \t GroupID \t CandidateID");

                while (reader.Read()) // построчно считываем данные
                {
                    var id = reader["id"];
                    int GroupID = (int)reader["GroupID"];
                    int CandidateID = (int)reader["CandidateID"];

                    Console.WriteLine($"{id} \t{GroupID} \t{CandidateID}");
                }
            }
            reader.Close();

            SqlCommand countRows = new SqlCommand("SELECT COUNT(*) FROM Group_Candidate", connection);
            int count = (int)countRows.ExecuteScalar();

            return count;
        }

        public int SelectGroupCandidateByID(SqlConnection connection, int ID)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectGroup_СandidateByID", connection);

            SqlParameter IDParam = new SqlParameter("@ID", ID);
            command.Parameters.Add(IDParam);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows) // если есть данные
            {
                // выводим названия столбцов
                Console.WriteLine($"id \t GroupID \t CandidateID");

                while (reader.Read()) // построчно считываем данные
                {
                    var id = reader["id"];
                    int GroupID = (int)reader["GroupID"];
                    int CandidateID = (int)reader["CandidateID"];

                    Console.WriteLine($"{id} \t{GroupID} \t{CandidateID} ");
                }
            }
            reader.Close();

            return (int)command.ExecuteScalar();
        }

        public int UpdateGroupCandidateByID(SqlConnection connection, GroupCandidateDTO groupCandidate, int ID)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("UpdateGroup_CandidateByID", connection);

            SqlParameter IDParam = new SqlParameter("@ID", ID);
            command.Parameters.Add(IDParam);

            SqlParameter GroupParam = new SqlParameter("@InterviewID", groupCandidate.GroupID);
            command.Parameters.Add(GroupParam);

            SqlParameter CandidateParam = new SqlParameter("@CandidateID", groupCandidate.CandidateID);
            command.Parameters.Add(CandidateParam);

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
