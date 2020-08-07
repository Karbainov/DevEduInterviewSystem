using DevEduInterviewSystem.DAL.DTO;
using DevEduInterviewSystem.DAL.StoredProcedures.CRUD;
using System;
using System.Data.SqlClient;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=.\HP;Initial Catalog=DevEduInterviewSystem.DataBase;Integrated Security=True; Data Source = (local)";
            SqlConnection connection = new SqlConnection(connectionString);

            CandidateDTO candidate = new CandidateDTO(1, 1, 1, 1, "123", "@@", "Vasa", "Pupkin", DateTime.Now);
            CandidateCRUD cRUD = new CandidateCRUD();
            //Console.WriteLine(cRUD.AddCandidate(connection, candidate));
            //Console.WriteLine(cRUD.DeleteCandidateByID(connection, 3));            

            connection.Close();

            Console.ReadLine();
        }
    }
}
