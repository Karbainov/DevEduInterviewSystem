using DevEduInterviewSystem.DAL.DTO.QuereDTO;
using DevEduInterviewSystem.DAL.Shared;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DevEduInterviewSystem.DAL.StoredProcedures.Query
{
    public class AllStudentsOfGroupProcedure
    {

        public List<AllStudentsOfGroupDTO> SelectAllStudentsOfGroup()
        {
            SqlConnection Connection = ConnectionSingleTone.GetInstance().Connection;
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("AllStudentsOfGroup", Connection);

            List<AllStudentsOfGroupDTO> allStudentsOfGroups = new List<AllStudentsOfGroupDTO>();

            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    AllStudentsOfGroupDTO allStudentsOfGroup = new AllStudentsOfGroupDTO()
                    {
                        Name = (string)reader["Name"],
                        StudentFirstName = (string)reader["FirstName"],
                        StudentLastName = (string)reader["LastName"]
                    };

                    allStudentsOfGroups.Add(allStudentsOfGroup);
                }
            }
            reader.Close();

            return allStudentsOfGroups;

        }
        private SqlCommand ReferenceToProcedure(string sqlExpression, SqlConnection connection)
        {
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            return command;
        }
    }
}
