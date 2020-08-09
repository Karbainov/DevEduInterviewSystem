using DevEduInterviewSystem.DAL.DTO;
using DevEduInterviewSystem.DAL.StoredProcedures;
using DevEduInterviewSystem.DAL.StoredProcedures.CRUD;
using System;
using System.Data.SqlClient;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=DESKTOP-IEKEDGF;Initial Catalog=DevEduInterviewSystem.DataBase;Integrated Security=True; Data Source = (local)";
            //string connectionString = @"Data Source=DESKTOP-IEKEDGF\SQLEXPRESS;Initial Catalog=DevEduInterviewSystem.DataBase; Data Source = (local)";
            SqlConnection connection = new SqlConnection(connectionString);
            Console.WriteLine("Подключение...");
            connection.Open();
            Console.WriteLine("Подключение открыто");

            // Вывод информации о подключении
            Console.WriteLine($"База данных: {connection.Database}");
            Console.WriteLine($"Сервер: { connection.DataSource}");
            Console.WriteLine($"Версия сервера: {connection.ServerVersion}");
            Console.WriteLine($"Состояние: {connection.State}");
            Console.WriteLine($"WorkstationID: {connection.WorkstationId}");


            //StageDTO stage = new StageDTO(1,"sdwqwa");
            CandidateDTO cand = new CandidateDTO(1, 1, 1, 1, "3242342", "fefefw", "Denis", "Matveev", DateTime.Today);
            //StageCRUD cRUD = new StageCRUD();
            CandidateCRUD candCrud = new CandidateCRUD();
            //Console.WriteLine(cRUD.AddStage(connection, stage));
            //InterviewDTO interview = new InterviewDTO(1, 1, 1, 1, DateTime.Now);
            //InterviewCRUD iRUD = new InterviewCRUD();
            CourseDTO course = new CourseDTO("C++");
            CourseCRUD cRud = new CourseCRUD();
            Course_CandidateDTO CorseCCRUD = new Course_CandidateDTO(1, 1);
            Course_CandidateCRUD cc = new Course_CandidateCRUD();
            CityDTO city = new CityDTO("Moskow");
            CityCRUD cityCRUD = new CityCRUD();
            connection.Close();
            //Console.WriteLine(cRUD.AddStage(connection, stage));
            //connection.Close();
            //Console.WriteLine(cRUD.SelectAllStage(connection));
            //Console.WriteLine(cRUD.DeleteStageByID(connection, 1));
            //Console.WriteLine(candCrud.AddCandidate(connection, cand));
            //connection.Close();

            //Console.WriteLine(cc.AddCourse_Candidate(connection, CorseCCRUD));
            //connection.Close();
            Console.WriteLine(cityCRUD.UpdateCityByID(connection, "Leningrad", 3));
            connection.Close();
            Console.WriteLine(cityCRUD.SelectAllCity(connection));
            connection.Close();

            //Console.ReadLine();
        }
    }
}
