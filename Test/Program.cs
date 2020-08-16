using DevEduInterviewSystem.DAL.DTO;
using DevEduInterviewSystem.DAL.DTO.CalendarInterviews;
using DevEduInterviewSystem.DAL.Shared;
using DevEduInterviewSystem.DAL.StoredProcedures;
using DevEduInterviewSystem.DAL.StoredProcedures.CRUD;
using DevEduInterviewSystem.DAL.StoredProcedures.Query.CalendarInterviews;
using System;
using System.Data.SqlClient;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectionSingleTone.GetInstance().ConnectionString = SQLConnectionPaths.MainConnectionString;
            SqlConnection connection = new SqlConnection(ConnectionSingleTone.GetInstance().ConnectionString);
            connection.Open();
            Console.WriteLine("Подключение к серверу");
            //AllInterviewsByUserDTO intrview = new AllInterviewsByUserDTO();
            //AllInterviewsByUserQuery interView = new AllInterviewsByUserQuery();


            CandidateDTO cand = new CandidateDTO(1, 1, 1, 1, "+911", "v@ya.ru", "Vasya", "Pupkin", DateTime.Now);
            CandidateDTO cand2 = new CandidateDTO(2, 2, 2, 2, "+911", "v@ya.ru", "Ivan", "Sidorov", DateTime.Now);
            ////CandidateDTO cand3 = new CandidateDTO(3, 3, 3, 3, "+911", "v@ya.ru", "Yana", "Smirnova", DateTime.Now);
            CandidateCRUD crud = new CandidateCRUD();
            ////connection.Close();
            crud.Add(cand2);
            connection.Close();
            //crud.Add(cand2);
            //connection.Close();
            //crud.Add(cand3);
            //connection.Close();



            //InterviewStatusDTO interviewStatus = new InterviewStatusDTO(1, "success");
            //InterviewStatusDTO interviewStatus2 = new InterviewStatusDTO(2, "fail");
            //InterviewStatusCRUD statusCRUD = new InterviewStatusCRUD();
            //statusCRUD.AddInterviewStatus(connection, interviewStatus);
            //connection.Close();
            //statusCRUD.AddInterviewStatus(connection, interviewStatus2);
            //connection.Close();

            //UserInterviewDTO userInterview = new UserInterviewDTO(1, 1, 2);
            //UserInterviewDTO userInterview2 = new UserInterviewDTO(2, 2, 1);
            //UserInterviewDTO userInterview3 = new UserInterviewDTO(2, 2, 5);
            //UserInterviewCRUD usInterviewCRUD = new UserInterviewCRUD();
            //usInterviewCRUD.Add(userInterview);
            //connection.Close();
            //usInterviewCRUD.Add(userInterview2);
            //connection.Close();
            //usInterviewCRUD.Add(userInterview3);
            //connection.Close();

            //InterviewCRUD interviewCRUD = new InterviewCRUD();
            //InterviewDTO interview = new InterviewDTO(1, 1, 1, 1, DateTime.Now);
            //InterviewDTO interview2 = new InterviewDTO(1, 2, 1, 1, DateTime.Now);
            //InterviewDTO interview3 = new InterviewDTO(7, 9, 1, 1, DateTime.Now);
            ////InterviewCRUD interviewCRUD = new InterviewCRUD();
            //interviewCRUD.Add(interview);
            //connection.Close();
            //interviewCRUD.Add(interview2);
            //connection.Close();
            //interviewCRUD.Add(interview3);
            //connection.Close();

            //UserInterviewCRUD userInterviewCRUD = new UserInterviewCRUD();
            //UserInterviewDTOMock userInterviewDTOMock = new UserInterviewDTOMock();
            //foreach (UserInterviewDTO dto in userInterviewDTOMock)
            //{
            //    userInterviewCRUD.Add(dto);
            //    Connection.Close();
            //}

            AllInterviewsByUserQuery interviewsByUserQuery = new AllInterviewsByUserQuery();
            //interviewsByUserQuery.SelectAllByUser(65);

            connection.Close();



            Console.WriteLine("Выполнено");

            connection.Open();
            Console.WriteLine("Подключение к серверу");
            connection.Close();



            Console.WriteLine("Выполнено");

        }
    }
}
