using DevEduInterviewSystem.DAL.DTO.QuereDTO.StudentsOfGroup;
using DevEduInterviewSystem.DAL.Shared;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DevEduInterviewSystem.DAL.StoredProcedures.Query.StudentsOfGroup
{
  public class AllStudentsOfGroupByStartProcedure
    {
        public List<AllStudentsOfGroupByStartDTO> SelectAllStudentsOfGroupByStart( DateTime startDate)
        {
            SqlConnection Connection = ConnectionSingleTone.GetInstance().Connection;
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("AllStudentsOfGroupByStart", Connection);
            SqlParameter dateParam = new SqlParameter("@StartDate", startDate);
            command.Parameters.Add(dateParam);
            
            List<AllStudentsOfGroupByStartDTO> allStudentsOfGroupByStarts = new List<AllStudentsOfGroupByStartDTO>();

            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    AllStudentsOfGroupByStartDTO allStudentsOfGroupByStart = new AllStudentsOfGroupByStartDTO()
                    {
                        Name = (string)reader["Name"],
                        StartDate = (DateTime)reader["StartDate"],
                        StudentFirstName = (string)reader["FirstName"],
                        StudentLastName = (string)reader["LastName"]
                    };

                     allStudentsOfGroupByStarts.Add(allStudentsOfGroupByStart);
                }
            }
            reader.Close();

            return  allStudentsOfGroupByStarts;

        }
        private SqlCommand ReferenceToProcedure(string sqlExpression, SqlConnection connection)
        {
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            return command;
        }
    }
}
