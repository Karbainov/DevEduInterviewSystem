using DevEduInterviewSystem.DAL.DTO.QuereDTO;
using DevEduInterviewSystem.DAL.Shared;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DevEduInterviewSystem.DAL.StoredProcedures.Query.AllOverdueHomework
{
    public class AllOverdueHomework
    {
        public List<GetAllOverdueHomeworkDTO> GetAllOverdueHomework()
        {
            SqlConnection Connection = new SqlConnection(ConnectionSingleTone.GetInstance().ConnectionString);
            Connection.Open();
            DateTime dateCurrent = DateTime.Now;
            SqlCommand command = ReferenceToProcedure("AllOverdueHomeworksAndTests", Connection);
            SqlParameter currentDateParam = new SqlParameter("@DareCurrent", dateCurrent);
            command.Parameters.Add(currentDateParam);

            List<GetAllOverdueHomeworkDTO> allOverdueHomeworks = new List<GetAllOverdueHomeworkDTO>();

            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    GetAllOverdueHomeworkDTO allOverdueHomework = new GetAllOverdueHomeworkDTO()
                    {
                        CandidateID = (int)reader["CandidateID"],
                        CandidateFirstName = (string)reader["CandidateFirstName"],
                        CandidateLastName = (string)reader["CandidateLastName"],
                        HomeWorkDate = (DateTime)reader["HomeWorkDate"]
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
