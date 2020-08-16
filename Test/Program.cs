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
           

            SqlConnection connection = ConnectionSingleTone.GetInstance().Connection;


            //CandidateDTO cand = new CandidateDTO(1, 1, 1, 1, "+911", "v@ya.ru", "Vasya", "Pupkin", DateTime.Now);
            //CandidateDTO cand2 = new CandidateDTO(2, 2, 2, 2, "+911", "v@ya.ru", "Ivan", "Sidorov", DateTime.Now);
            //CandidateDTO cand3 = new CandidateDTO(3, 3, 3, 3, "+911", "v@ya.ru", "Yana", "Smirnova", DateTime.Now);
            //CandidateCRUD crud = new CandidateCRUD();
            //connection.Close();
            



            Console.WriteLine("Выполнено");
                        
        }
    }
}
