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
using DevEduInterviewSystem.DAL.StoredProcedures.Query.AllOverdueHomework;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectionSingleTone.GetInstance().ConnectionString = SQLConnectionPaths.TestConnectionString;
            SqlConnection connection = new SqlConnection(ConnectionSingleTone.GetInstance().ConnectionString);

            UsersWithRoleProcedure test = new UsersWithRoleProcedure();
            List<UsersWithRoleDTO> result = test.SelectUsersWithRole();

            AllOverdueHomeworkDTO dto = new AllOverdueHomeworkDTO();
            AllOverdueHomework creud = new AllOverdueHomework();
            creud.GetAllOverdueHomework(new DateTime(2020, 07, 20, 18, 30, 00));


            connection.Open();
            Console.WriteLine("Подключение к серверу");
            

            connection.Close();
            Console.WriteLine("Выполнено");


        }
    }
}
