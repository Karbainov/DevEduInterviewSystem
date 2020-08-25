using DevEduInterviewSystem.DAL.DTO.QuereDTO;
using DevEduInterviewSystem.DAL.Shared;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DevEduInterviewSystem.DAL.StoredProcedures.Query.AllOverdueHomework
{
    public class AllOverdueHomeworks
    {
        public List<AllOverdueHomeworksDTO> GetAllOverdueHomeworks(DateTime dateTime)
        {
            SqlConnection Connection = new SqlConnection(ConnectionSingleTone.GetInstance().ConnectionString);
            Connection.Open();
            DateTime dateCurrent = DateTime.Now;
            SqlCommand command = ReferenceToProcedure("AllOverdueHomeworks", Connection);
            SqlParameter currentDateParam = new SqlParameter("@DateCurrent", dateCurrent);
            command.Parameters.Add(currentDateParam);

            List<AllOverdueHomeworksDTO> allOverdueList = new List<AllOverdueHomeworksDTO>();

            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    AllOverdueHomeworksDTO allOverdueTest = new AllOverdueHomeworksDTO()
                    {
                        HomeWorkDate = (DateTime)reader["HomeWorkDate"],
                        CandidateFirstName = (string)reader["CandidateFirstName"],
                        CandidateLastName = (string)reader["CandidateLastName"],
                        TestStatus = (string)reader["TestStatus"],
                        HomeWorkStatus = (string)reader["HomeWorkStatus"]
                    };

                    allOverdueList.Add(allOverdueTest);
                }
            }
            reader.Close();
            Connection.Close();
            return allOverdueList;

        }
        private SqlCommand ReferenceToProcedure(string sqlExpression, SqlConnection connection)
        {
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            return command;
        }
    }
}
