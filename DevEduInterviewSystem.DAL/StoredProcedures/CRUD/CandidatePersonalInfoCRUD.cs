using System;
using System.Data.SqlClient;
using DevEduInterviewSystem.DAL.DTO;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.StoredProcedures.CRUD
{
    public class CandidatePersonalInfoCRUD
    {
        public int AddCandidatePersonalInfo(SqlConnection connection, CandidatePersonalInfoDTO candidatePersonalInfo)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("AddCandidatePersonalInfo", connection);

            SqlParameter CandidateIDParam = new SqlParameter("@CandidateID", candidatePersonalInfo.CandidateID);
            command.Parameters.Add(CandidateIDParam);

            SqlParameter MaritalStatusParam = new SqlParameter("MaritalStatus", candidatePersonalInfo.MaritalStatus);
            command.Parameters.Add(MaritalStatusParam);

            SqlParameter EducationParam = new SqlParameter("@Education", candidatePersonalInfo.Education);
            command.Parameters.Add(EducationParam);

            SqlParameter WorkPlaceParam = new SqlParameter("@WorkPlace", candidatePersonalInfo.WorkPlace);
            command.Parameters.Add(WorkPlaceParam);

            SqlParameter ITExperienceParam = new SqlParameter("@ITExperience", candidatePersonalInfo.ITExperience);
            command.Parameters.Add(ITExperienceParam);

            SqlParameter HobbiesParam = new SqlParameter("@Hobbies", candidatePersonalInfo.Hobbies);
            command.Parameters.Add(HobbiesParam);

            SqlParameter InfoSourseParam = new SqlParameter("@InfoSourse", candidatePersonalInfo.InfoSourse);
            command.Parameters.Add(InfoSourseParam);

            SqlParameter ExpectationsParam = new SqlParameter("@Expectations", candidatePersonalInfo.Expectations);
            command.Parameters.Add(ExpectationsParam);

            return command.ExecuteNonQuery();
        }

        public int DeleteCandidatePersonalInfoByID(SqlConnection connection, int ID)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("DeleteCandidatePersonalInfoByID", connection);
            
            SqlParameter IDParam = new SqlParameter("@ID", ID);
            command.Parameters.Add(IDParam);

            return command.ExecuteNonQuery();
        }

        public int SelectAllCandidatePersonalInfo(SqlConnection connection)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectAllCandidatePersonalInfo", connection);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows) // если есть данные
            {
                // выводим названия столбцов
                //Console.WriteLine($"ID \t StageID \t StatusID \t CityID \t Phone \t Email \t FirstName \t LastName \t Birthday");

                while (reader.Read()) // построчно считываем данные
                {
                    int ID = (int)reader["id"];
                    int CandidateID = (int)reader["CandidateID"];
                    bool MaritalStatus = (bool)reader["MaritalStatus"];
                    var Education = (string)reader["Education"];
                    var WorkPlace = (string)reader["WorkPlace"];
                    var ITExperience = (string)reader["ITExperience"];
                    var Hobbies = (string)reader["Hobbies"];
                    var InfoSourse = (string)reader["InfoSourse"];
                    var Expectations = (string)reader["Expectations"];

                    Console.WriteLine($"{ID} \t{CandidateID} \t{MaritalStatus} \t{Education} \t{WorkPlace} \t{ITExperience} \t{Hobbies} \t{InfoSourse} \t{Expectations}");
                }
            }
            reader.Close();


            SqlCommand countRows = new SqlCommand("SELECT COUNT(*) FROM CandidatePersonalInfo", connection);
            int count = (int)countRows.ExecuteScalar();

            return count;
        }

        public int SelectCandidatePersonalInfoByID(SqlConnection connection, int ID)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectCandidatePersonalInfoByID", connection);

            SqlParameter IDParam = new SqlParameter("@ID", ID);
            command.Parameters.Add(IDParam);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows) // если есть данные
            {
                // выводим названия столбцов
                //Console.WriteLine($"id \tStageID \tStatusID \tCityID \tPhone \tEmail \tFirstName \tLastName \tBirthday");

                while (reader.Read()) // построчно считываем данные
                {
                    int id = (int)reader["id"];
                    int CandidateID = (int)reader["CandidateID"];
                    bool MaritalStatus = (bool)reader["MaritalStatus"];
                    var Education = (string)reader["Education"];
                    var WorkPlace = (string)reader["WorkPlace"];
                    var ITExperience = (string)reader["ITExperience"];
                    var Hobbies = (string)reader["Hobbies"];
                    var InfoSourse = (string)reader["InfoSourse"];
                    var Expectations = (string)reader["Expectations"];

                    Console.WriteLine($"{id} \t{CandidateID} \t{MaritalStatus} \t{Education} \t{WorkPlace} \t{ITExperience} \t{Hobbies} \t{InfoSourse} \t{Expectations}");
                }
            }
            reader.Close();

            return (int)command.ExecuteScalar();
        }

        public int UpdateCandidatePersonalInfoByID(SqlConnection connection, CandidatePersonalInfoDTO candidatePersonalInfo, int ID)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("UpdateCandidatePersonalInfoByID", connection);

            SqlParameter IDParam = new SqlParameter("@ID", ID);
            command.Parameters.Add(IDParam);

            SqlParameter CandidateIDParam = new SqlParameter("@CandidateID", candidatePersonalInfo.CandidateID);
            command.Parameters.Add(CandidateIDParam);

            SqlParameter MaritalStatusParam = new SqlParameter("MaritalStatus", candidatePersonalInfo.MaritalStatus);
            command.Parameters.Add(MaritalStatusParam);

            SqlParameter EducationParam = new SqlParameter("@Education", candidatePersonalInfo.Education);
            command.Parameters.Add(EducationParam);

            SqlParameter WorkPlaceParam = new SqlParameter("@WorkPlace", candidatePersonalInfo.WorkPlace);
            command.Parameters.Add(WorkPlaceParam);

            SqlParameter ITExperienceParam = new SqlParameter("@ITExperience", candidatePersonalInfo.ITExperience);
            command.Parameters.Add(ITExperienceParam);

            SqlParameter HobbiesParam = new SqlParameter("@Hobbies", candidatePersonalInfo.Hobbies);
            command.Parameters.Add(HobbiesParam);

            SqlParameter InfoSourseParam = new SqlParameter("@InfoSourse", candidatePersonalInfo.InfoSourse);
            command.Parameters.Add(InfoSourseParam);

            SqlParameter ExpectationsParam = new SqlParameter("@Expectations", candidatePersonalInfo.Expectations);
            command.Parameters.Add(ExpectationsParam);

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
