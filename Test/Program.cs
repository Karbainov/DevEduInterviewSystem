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

            //CandidateDTO candidate = new CandidateDTO(1, 1, 1, 1, "123", "@@", "Vasa", "Pupkin", DateTime.Now);
            CandidateCRUD cRUD = new CandidateCRUD();
            //Console.WriteLine(cRUD.AddCandidate(connection, candidate));
            //Console.WriteLine(cRUD.DeleteCandidateByID(connection, 3));
            //Console.WriteLine(cRUD.SelectAllCandidate(connection));
            

            CandidateDTO candidate = new CandidateDTO(51, 5, 51, 51, "123", "@@", "Vasa", "Pupkin", DateTime.Now);
            Console.WriteLine(cRUD.UpdateCandidateByID(connection, candidate, 7));
            connection.Close();

            Console.WriteLine(cRUD.SelectCandidateByID(connection, 7));

            connection.Close();

            Console.ReadLine();
        }
    }
}
