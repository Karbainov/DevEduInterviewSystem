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
using DevEduInterviewSystem.DAL.StoredProcedures.Query.User;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //ConnectionSingleTone.GetInstance().ConnectionString = SQLConnectionPaths.TestConnectionString;
            SqlConnection connection = new SqlConnection(ConnectionSingleTone.GetInstance().ConnectionString);

            //UsersWithRoleProcedure test = new UsersWithRoleProcedure();
            ////List<UsersWithRoleDTO> result = test.SelectUsersWithRole();

            //CandidateCRUD crud = new CandidateCRUD();
            ////crud.Add(new CandidateDTO(1, null, null, null, "911", "v@ya.ru", "Vasya", "Pupkin", DateTime.Now));

            //CandidateDTO candidate = new CandidateDTO();
            //candidate.Phone = "911";
            //candidate.LastName = "Pupkin";
            //candidate.BirthDay = DateTime.Now;
            //crud.Add(candidate);

            //crud.UpdateByID(new CandidateDTO(232, null, null, null, "911", "v@ya.ru", "Vasya", "Pupkin", DateTime.Now));

            GetRolesByUserID getRolesByUserID = new GetRolesByUserID();
            var q = getRolesByUserID.GetListOfRoles(228);

            connection.Open();
            Console.WriteLine("Подключение к серверу");
            

            connection.Close();
            Console.WriteLine("Выполнено");


        }
    }
}
