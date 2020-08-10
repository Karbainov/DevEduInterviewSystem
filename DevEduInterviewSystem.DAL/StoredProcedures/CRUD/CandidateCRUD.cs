using DevEduInterviewSystem.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DevEduInterviewSystem.DAL.StoredProcedures.CRUD
{
    public class CandidateCRUD
    {
        public int AddCandidate(SqlConnection connection, CandidateDTO candidate)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("AddCandidate", connection);

            SqlParameter StageParam = new SqlParameter("@StageID", candidate.StageID);
            command.Parameters.Add(StageParam);

            SqlParameter StatusParam = new SqlParameter("@StatusID", candidate.StatusID);
            command.Parameters.Add(StatusParam);

            SqlParameter CityParam = new SqlParameter("@CityID", candidate.CityID);
            command.Parameters.Add(CityParam);

            SqlParameter PhoneParam = new SqlParameter("@Phone", candidate.Phone);
            command.Parameters.Add(PhoneParam);

            SqlParameter EmailParam = new SqlParameter("@Email", candidate.Email);
            command.Parameters.Add(EmailParam);

            SqlParameter FirstNameParam = new SqlParameter("@FirstName", candidate.FirstName);
            command.Parameters.Add(FirstNameParam);

            SqlParameter LastNameParam = new SqlParameter("@LastName", candidate.LastName);
            command.Parameters.Add(LastNameParam);

            SqlParameter BDParam = new SqlParameter("@BirthDay", candidate.BirthDay);
            command.Parameters.Add(BDParam);

            return command.ExecuteNonQuery();
        }

        public int DeleteCandidateByID(SqlConnection connection, int ID)
        {
            connection.Open();
            string sqlExpression = "DeleteCandidateByID";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter IDParam = new SqlParameter("@ID", ID);
            command.Parameters.Add(IDParam);

            return command.ExecuteNonQuery();
        }

        public int SelectAllCandidate(SqlConnection connection)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectAllCandidate", connection);            

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows) // если есть данные
            {
                // выводим названия столбцов
                Console.WriteLine($"id \t StageID \t StatusID \t CityID \t Phone \t Email \t FirstName \t LastName \t Birthday");

                while (reader.Read()) // построчно считываем данные
                {
                    var id = reader["id"];
                    int StageID = (int)reader["StageID"];
                    int StatusID = (int)reader["StatusID"];
                    int CityID = (int)reader["CityID"];
                    int Phone = (int)reader["Phone"];
                    var Email = (string)reader["Email"];
                    var FirstName = (string)reader["FirstName"];
                    var LastName = (string)reader["LastName"];
                    var Birthday = (DateTime)reader["Birthday"];

                    Console.WriteLine($"{id} \t{StageID} \t{StatusID} \t{CityID} \t{Phone} \t{Email} \t{FirstName} \t{LastName} \t{Birthday}");
                }
            }
            reader.Close();

            SqlCommand countRows = new SqlCommand("SELECT COUNT(*) FROM Candidate", connection);
            int count = (int)countRows.ExecuteScalar();            

            return count;
        }

        public int SelectCandidateByID(SqlConnection connection, int ID)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectCandidateByID", connection);           

            SqlParameter IDParam = new SqlParameter("@ID", ID);
            command.Parameters.Add(IDParam);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows) // если есть данные
            {
                // выводим названия столбцов
                Console.WriteLine($"id \tStageID \tStatusID \tCityID \tPhone \tEmail \tFirstName \tLastName \tBirthday");

                while (reader.Read()) // построчно считываем данные
                {
                    var id = reader["id"];
                    int StageID = (int)reader["StageID"];
                    int StatusID = (int)reader["StatusID"];
                    int CityID = (int)reader["CityID"];
                    int Phone = (int)reader["Phone"];
                    var Email = (string)reader["Email"];
                    var FirstName = (string)reader["FirstName"];
                    var LastName = (string)reader["LastName"];
                    var Birthday = (DateTime)reader["Birthday"];

                    Console.WriteLine($"{id} \t{StageID} \t{StatusID} \t{CityID} \t{Phone} \t{Email} \t{FirstName} \t{LastName} \t{Birthday}");
                }
            }
            reader.Close();

            return (int)command.ExecuteScalar();
        }

        public int UpdateCandidateByID(SqlConnection connection, CandidateDTO candidate, int ID)
        {
            connection.Open();            
            SqlCommand command = ReferenceToProcedure("UpdateCandidateByID", connection);            

            SqlParameter IDParam = new SqlParameter("@ID", ID);
            command.Parameters.Add(IDParam);

            SqlParameter StageParam = new SqlParameter("@StageID", candidate.StageID);
            command.Parameters.Add(StageParam);

            SqlParameter StatusParam = new SqlParameter("@StatusID", candidate.StatusID);
            command.Parameters.Add(StatusParam);

            SqlParameter CityParam = new SqlParameter("@CityID", candidate.CityID);
            command.Parameters.Add(CityParam);

            SqlParameter PhoneParam = new SqlParameter("@Phone", candidate.Phone);
            command.Parameters.Add(PhoneParam);

            SqlParameter EmailParam = new SqlParameter("@Email", candidate.Email);
            command.Parameters.Add(EmailParam);

            SqlParameter FirstNameParam = new SqlParameter("@FirstName", candidate.FirstName);
            command.Parameters.Add(FirstNameParam);

            SqlParameter LastNameParam = new SqlParameter("@LastName", candidate.LastName);
            command.Parameters.Add(LastNameParam);

            SqlParameter BDParam = new SqlParameter("@BirthDay", candidate.BirthDay);
            command.Parameters.Add(BDParam);

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
