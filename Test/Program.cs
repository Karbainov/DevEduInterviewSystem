using DevEduInterviewSystem.DAL.DTO;
using DevEduInterviewSystem.DAL.Shared;
using DevEduInterviewSystem.DAL.StoredProcedures;
using DevEduInterviewSystem.DAL.StoredProcedures.CRUD;
using DevEduInterviewSystem.DAL.DTO.CalendarInterviews;
using DevEduInterviewSystem.DAL.StoredProcedures.Query.CalendarInterviews;
using System;
using System.Data.SqlClient;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {

            AllInterviewsByUserDTO intrview = new AllInterviewsByUserDTO();
            AllInterviewsByUserQuery interView = new AllInterviewsByUserQuery();

            Console.WriteLine(interView.SelectAllByUser(1));

            //CandidateDTO cand = new CandidateDTO();
            //CandidateCRUD cCrud = new CandidateCRUD();
            //Console.WriteLine(cCrud.SelectAll());

            //string connectionString = @"Data Source=DESKTOP-IEKEDGF;Initial Catalog=DevEduInterviewSystem.DataBase;Integrated Security=True; Data Source = (local)";
            //string connectionString = @"Data Source=DESKTOP-HRBRQKP;Initial Catalog=DevEduInterviewSystem.DataBase; Data Source = (local)";
            //SqlConnection Connection = new SqlConnection(ConnectionString);
            //SqlConnection Connection = new SqlConnection(PrimerConnection.ConnectionString);
            //Console.WriteLine("Подключение...");
            //Connection.Open();
            //Console.WriteLine("Подключение открыто");

            //// Вывод информации о подключении
            //Console.WriteLine($"База данных: {Connection.Database}");
            //Console.WriteLine($"Сервер: { Connection.DataSource}");
            //Console.WriteLine($"Версия сервера: {Connection.ServerVersion}");
            //Console.WriteLine($"Состояние: {Connection.State}");
            //Console.WriteLine($"WorkstationID: {Connection.WorkstationId}");

            //Connection.Close();
            //StageDTO stage = new StageDTO(1,"sdwqwa");
            //HomeworkStatusDTO homeworkStatus = new HomeworkStatusDTO(1, "jfjf");
            //StageCRUD cRUD = new StageCRUD();
            //HomeworkStatusCRUD Crud = new HomeworkStatusCRUD();
            //Console.WriteLine(cRUD.AddStage(connection, stage));
            //InterviewDTO interview = new InterviewDTO(1, 1, 1, 1, DateTime.Now);
            //InterviewCRUD iRUD = new InterviewCRUD();
            //CourseDTO course = new CourseDTO("C++");
            //CourseCRUD cRud = new CourseCRUD();
            //Course_CandidateDTO CorseCCRUD = new Course_CandidateDTO(1, 1);
            //Course_CandidateCRUD cc = new Course_CandidateCRUD();
            //CityDTO city = new CityDTO("Pyatigorsk");
            //CityCRUD cityCRUD = new CityCRUD();
            //Connection.Close();
            //Console.WriteLine(cRUD.AddStage(connection, stage));
            //connection.Close();
            //Console.WriteLine(cRUD.SelectAllStage(connection));
            //Console.WriteLine(Crud.UpdateByID(connection, homeworkStatus, 2));
            //Console.WriteLine(candCrud.AddCandidate(connection, cand));
            //connection.Close();

            //Console.WriteLine(cc.AddCourse_Candidate(connection, CorseCCRUD));
            //connection.Close();
            //Console.WriteLine(homeworkStatusCrud.Add(connection, homeworkStatus));

            //Console.WriteLine(cityCRUD.Add(city));
            //Connection.Close();

            //Console.WriteLine(cityCRUD.SelectAll());
            //Connection.Close();

            //Console.ReadLine();
        }
    }
}
