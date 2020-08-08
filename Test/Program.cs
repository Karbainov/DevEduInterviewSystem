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
            string connectionString = @"Data Source=DESKTOP-9K6HNII;Initial Catalog=DevEduInterviewSystem.DataBase;Integrated Security=True; Data Source = (local)";
            SqlConnection connection = new SqlConnection(connectionString);

            StageDTO stage = new StageDTO(2, "qwer");
            StageCRUD cRUD = new StageCRUD();
           // Console.WriteLine(cRUD.AddStage(connection, stage));
           // Console.WriteLine(cRUD.DeleteStageByID(connection, 1));
           


           
           // Console.WriteLine(cRUD.UpdateStageByID(connection, stage, 2));
            connection.Close();

            Console.WriteLine(cRUD.SelectAllStage(connection));

            connection.Close();

            Console.ReadLine();
        }
    }
}
