using System;
using System.Data.SqlClient;
using DevEduInterviewSystem.DAL.DTO;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Data;

namespace DevEduInterviewSystem.DAL.StoredProcedures.CRUD
{
    public class TestStatusCRUD : AbstractCRUD<TestStatusDTO>
    {
        public override int Add(TestStatusDTO dto)
        {
            var procedure = "[AddTestStatus]";
            var values = new
            {
                dto.Name              
            };
            IDbConnection.Query(procedure, values, commandType: CommandType.StoredProcedure);
            Connection.Open();
            SqlCommand returnCurrentID = new SqlCommand("SELECT MAX([ID]) FROM dbo.[TestStatus]", Connection);
            int count = (int)returnCurrentID.ExecuteScalar();

            Connection.Close();

            return count;           
        }

        public override int DeleteByID(int id)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("DeleteTestStatusByID");

            SqlParameter IDParam = new SqlParameter("@ID", id);
            command.Parameters.Add(IDParam);

            int rows = command.ExecuteNonQuery();
            Connection.Close();

            return rows;
        }

        public override List<TestStatusDTO> SelectAll()
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectAllTestStatus");

            SqlDataReader reader = command.ExecuteReader();

            List<TestStatusDTO> tests = new List<TestStatusDTO>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    TestStatusDTO testStatus = new TestStatusDTO()
                    {
                        ID = (int)reader["id"],
                        Name = (string)reader["Name"]
                    };

                    tests.Add(testStatus);
                }
            }
            reader.Close();
            Connection.Close();
            return tests;
        }

        public override TestStatusDTO SelectByID(int id)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectTestStatusByID");

            SqlParameter IDParam = new SqlParameter("@ID", id);
            command.Parameters.Add(IDParam);

            SqlDataReader reader = command.ExecuteReader();
            TestStatusDTO testStatus = new TestStatusDTO();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    testStatus.ID = (int)reader["id"];
                    testStatus.Name = (string)reader["Name"];
                }
            }
            reader.Close();
            Connection.Close();
            return testStatus;
        }

        public override int UpdateByID(TestStatusDTO dto)
        {
            var procedure = "[UpdateTestStatus]";
            var values = new
            {
                dto.ID,
                dto.Name
            };
            IDbConnection.Query(procedure, values, commandType: CommandType.StoredProcedure);
            return (int)dto.ID;
        }
            

    }
}
