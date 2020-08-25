using DevEduInterviewSystem.DAL.DTO.QuereDTO;
using DevEduInterviewSystem.DAL.Shared;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DevEduInterviewSystem.DAL.StoredProcedures.Query.AllOverdueHomework
{
    public class AllOverdueHomeworks
    {
        public List<AllOverdueTestsDTO> GetAllOverdueHomeworks(DateTime dateTime)
        {
            SqlConnection Connection = new SqlConnection(ConnectionSingleTone.GetInstance().ConnectionString);
            Connection.Open();
            DateTime dateCurrent = DateTime.Now;
            SqlCommand command = ReferenceToProcedure("AllOverdueTests", Connection);
            SqlParameter currentDateParam = new SqlParameter("@DateCurrent", new DateTime(2020, 07, 20, 18, 30, 00));
            command.Parameters.Add(currentDateParam);

            List<AllOverdueTestsDTO> allOverdueTests = new List<AllOverdueTestsDTO>();

            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    AllOverdueTestsDTO allOverdueTest = new AllOverdueTestsDTO()
                    {
                        //CandidateID = (int)reader["CandidateID"],
                        HomeWorkDate = (DateTime)reader["HomeWorkDate"],
                        CandidateFirstName = (string)reader["CandidateFirstName"],
                        CandidateLastName = (string)reader["CandidateLastName"],
                        TestStatus = (string)reader["TestStatus"],
                    };

                    allOverdueTests.Add(allOverdueTest);
                }
            }
            reader.Close();
            Connection.Close();
            return allOverdueTests;

        }
        private SqlCommand ReferenceToProcedure(string sqlExpression, SqlConnection connection)
        {
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            return command;
        }
    }
}
