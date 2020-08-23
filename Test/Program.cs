using DevEduInterviewSystem.DAL.DTO;
using DevEduInterviewSystem.DAL.Shared;
using DevEduInterviewSystem.DAL.StoredProcedures;
using DevEduInterviewSystem.DAL.StoredProcedures.CRUD;
using DevEduInterviewSystem.DAL.DTO.CalendarInterviews;
using DevEduInterviewSystem.DAL.StoredProcedures.Query.CalendarInterviews;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using DevEduInterviewSystem.DAL.DTO.QuereDTO;
using DevEduInterviewSystem.DAL.Tests.Mocks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectionSingleTone.GetInstance().ConnectionString = SQLConnectionPaths.TestConnectionString;            

            AllTablesMock allTablesMock = new AllTablesMock();
            allTablesMock.AddData();
            //allTablesMock.DeleteData();

            SqlConnection connection = new SqlConnection(ConnectionSingleTone.GetInstance().ConnectionString);
            connection.Open();
            Console.WriteLine("Подключение к серверу");

            connection.Close();
            Console.WriteLine("Выполнено");


        }
    }
}
