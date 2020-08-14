using DevEduInterviewSystem.DAL.DTO.QuereDTO;
using DevEduInterviewSystem.DAL.Shared;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DevEduInterviewSystem.DAL.StoredProcedures.Query
{
    public class AllInformationAboutTheCandidateByIDProcedure
    {
        SqlConnection Connection = ConnectionSingleTone.GetInstance().Connection;

        public AllInformationAboutTheCandidateByIDDTO AllInformationAboutTheCandidateByID(int ID)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("AllInformationAboutTheCandidateByID", Connection);
            AllInformationAboutTheCandidateByIDDTO allInfoCandidate = new AllInformationAboutTheCandidateByIDDTO();

            SqlParameter IDParam = new SqlParameter("@ID", ID);
            command.Parameters.Add(IDParam);

            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())

                {             
                   
                    allInfoCandidate.ID = (int)reader["ID"];
                    allInfoCandidate.TypeOfStage = (string)reader["TypeOfStage"];
                    allInfoCandidate.TypeOfStatus = (string)reader["TypeOfStatus"];
                    allInfoCandidate.CityName = (string)reader["CityName"];
                    //allInfoCandidate.Phone = (string)reader["Phone"];
                    allInfoCandidate.Email = (string)reader["Email"];
                    allInfoCandidate.FirstName = (string)reader["FirstName"];
                    allInfoCandidate.LastName = (string)reader["LastName"];
                    allInfoCandidate.Birthday = (DateTime)reader["Birthday"];
                    allInfoCandidate.FeedBack = (string)reader["FeedBack"];
                    //allInfoCandidate.CourseName = (string)reader["CourseName"];
                    //allInfoCandidate.GroupName = (string)reader["GroupName"];
                    allInfoCandidate.MaritalStatus = (bool)reader["MaritalStatus"];
                    allInfoCandidate.Education = (string)reader["Education"];
                    allInfoCandidate.WorkPlace = (string)reader["WorkPlace"];
                    allInfoCandidate.ITExperience = (string)reader["ITExperience"];
                    allInfoCandidate.Hobbies = (string)reader["Hobbies"];
                    allInfoCandidate.InfoSourse = (string)reader["InfoSourse"];
                    allInfoCandidate.Expectations = (string)reader["Expectations"];
                }
            }
            reader.Close();

            return allInfoCandidate;

        }
        private SqlCommand ReferenceToProcedure(string sqlExpression, SqlConnection connection)
        {
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            return command;
        }
    }
}
