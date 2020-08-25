using DevEduInterviewSystem.DAL.DTO.QuereDTO;
using DevEduInterviewSystem.DAL.Shared;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DevEduInterviewSystem.DAL.StoredProcedures.Query.AllOverdueHomeworks
{
    public class AllOverdueHomeworks
    {
        public List<AllOverdueHomeworksDTO> GetAllOverdueHomeworks(DateTime dateTime)
        {
            SqlConnection Connection = new SqlConnection(ConnectionSingleTone.GetInstance().ConnectionString);
            Connection.Open();
            DateTime dateCurrent = DateTime.Now;
            SqlCommand command = ReferenceToProcedure("AllOverdueHomeworks", Connection);
            SqlParameter currentDateParam = new SqlParameter("@DateCurrent", new DateTime(2020, 07, 20, 18, 30, 00));
            command.Parameters.Add(currentDateParam);

            List<AllOverdueHomeworksDTO> allOverdueHomeworks = new List<AllOverdueHomeworksDTO>();

            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    AllOverdueHomeworksDTO allOverdueHomework = new AllOverdueHomeworksDTO()
                    {
                        /*CandidateID = (int)reader["CandidateID"],*/
                        HomeWorkDate = (DateTime)reader["HomeWorkDate"],
                        CandidateFirstName = (string)reader["CandidateFirstName"],
                        CandidateLastName = (string)reader["CandidateLastName"],
                        HomeWorkStatus = (string)reader["HomeWorkStatus"],
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

    
        
    

