using DevEduInterviewSystem.DAL.DTO;
using DevEduInterviewSystem.DAL.StoredProcedures.CRUD;
using System;
using System.Data.SqlClient;

namespace Test
{
    class Program
    {
        static public SqlConnection GetConnection()
        {
            string connectionString = @"Data Source = DESKTOP-9K6HNII\MSSQLSERVER2;Initial Catalog = test; Integrated Security = True";
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
        static void Main(string[] args)
        {
            CandidateDTO candidate = new CandidateDTO(1, 1, 1, 1, "123", "@@", "Vasa", "Pupkin", DateTime.Now);
            CandidateCRUD cRUD = new CandidateCRUD();
            Console.WriteLine(cRUD.AddCandidate(GetConnection(),candidate));
        }
    }
}
