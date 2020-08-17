using DevEduInterviewSystem.DAL.DTO.QuereDTO;
using DevEduInterviewSystem.DAL.Shared;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DevEduInterviewSystem.DAL.StoredProcedures.Query.AllOverdueHomework
{
    public class GetAllOverdueHomework
    {
        public List<AllOverdueHomeworkDTO> AllOverdueHomework()
        {
            SqlConnection Connection = new SqlConnection(ConnectionSingleTone.GetInstance().ConnectionString);
            Connection.Open();
            DateTime dateCurrent = DateTime.Now;
            SqlCommand command = ReferenceToProcedure("AllOverdueHomework", Connection);
            SqlParameter currentDateParam = new SqlParameter("@DateCurrent", dateCurrent);
            command.Parameters.Add(currentDateParam);

            List<AllOverdueHomeworkDTO> allOverdueHomeworks = new List<AllOverdueHomeworkDTO>();

            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    AllOverdueHomeworkDTO allOverdueHomework = new AllOverdueHomeworkDTO()
                    {
                        CandidateID = (int)reader["CandidateID"],
                        CandidateFirstName = (string)reader["CandidateFirstName"],
                        CandidateLastName = (string)reader["CandidateLastName"],
                        HomeWorkDate = (DateTime)reader["HomeworkDate"],
                        HomeWorkStatus = (string)reader["HomeWorkStatus"],
                        TestStatus = (string)reader["TestStatus"]
                    };

                    allOverdueHomeworks.Add(allOverdueHomework);
                }
            }
            reader.Close();
            Connection.Close();
            return allOverdueHomeworks;

        }
        private SqlCommand ReferenceToProcedure(string sqlExpression, SqlConnection connection)
        {
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            return command;
        }
    }
}
