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
            string connectionString = @"Data Source=.\HP;Initial Catalog=DevEduInterviewSystem.DataBase;Integrated Security=True; Data Source = (local)";
            SqlConnection connection = new SqlConnection(connectionString);

            //CandidateDTO candidate = new CandidateDTO(1, 1, 1, 1, "123", "@@", "Vasa", "Pupkin", DateTime.Now);
            //CandidateCRUD cRUD = new CandidateCRUD();
            //Console.WriteLine(cRUD.AddCandidate(connection, candidate));
            //Console.WriteLine(cRUD.DeleteCandidateByID(connection, 3));
            //Console.WriteLine(cRUD.SelectAllCandidate(connection));   
            //CandidateDTO candidate = new CandidateDTO(51, 5, 51, 51, "123", "@@", "Vasa", "Pupkin", DateTime.Now);
            // Console.WriteLine(cRUD.UpdateCandidateByID(connection, candidate, 7));
            //Console.WriteLine(cRUD.SelectCandidateByID(connection, 7));

            //TaskCRUD taskCrud = new TaskCRUD();
            //TaskDTO task = new TaskDTO(1, 1, 1,"hw1","done");
            //TaskDTO task1 = new TaskDTO(2, 2, 2, "hw2", "done");
            //TaskDTO task2 = new TaskDTO(3, 3, 3, "hw3", "not ready");
            //Console.WriteLine(taskCrud.AddTask(connection, task));
            //connection.Close();
            //Console.WriteLine(taskCrud.AddTask(connection, task1));
            //connection.Close();
            //Console.WriteLine(taskCrud.AddTask(connection, task2));
            //connection.Close();
            //Console.WriteLine(taskCrud.SelectAllTask(connection));
            //Console.WriteLine(taskCrud.SelectTaskByID(connection,3));
            //Console.WriteLine(taskCrud.DeleteTaskByID(connection, 2));
            //connection.Close();
            //TaskDTO task4 = new TaskDTO(4, 4, 4, "hw4", "done");
            //Console.WriteLine(taskCrud.UpdateTaskByID(connection, task4,1));
            //connection.Close();
            //Console.WriteLine(taskCrud.SelectAllTask(connection));

            StageChangedCRUD stageChangedCrud = new StageChangedCRUD();
            StageChangedDTO stage = new StageChangedDTO(1, 1, 1, DateTime.Now);
            StageChangedDTO stage1 = new StageChangedDTO(2, 2, 2, DateTime.Now);
            StageChangedDTO stage2 = new StageChangedDTO(3, 3, 3, DateTime.Now);
            //Console.WriteLine(stageChangedCrud.AddStageChanged(connection, stage));
            //connection.Close();
            //Console.WriteLine(stageChangedCrud.AddStageChanged(connection, stage1));
            //connection.Close();
            //Console.WriteLine(stageChangedCrud.AddStageChanged(connection, stage2));
            //connection.Close();
            
            //Console.WriteLine(stageChangedCrud.SelectStageChangedByID(connection, 3));
            //connection.Close();
            //Console.WriteLine(stageChangedCrud.DeleteStageChangedByID(connection, 2));
            //connection.Close();
            //StageChangedDTO task4 = new StageChangedDTO(4, 4, 4, DateTime.Now);
            //connection.Close();
            //Console.WriteLine(stageChangedCrud.UpdateStageChangedByID(connection, task4, 1));
            //connection.Close();
            Console.WriteLine(stageChangedCrud.SelectAllStageChanged(connection));

            connection.Close();

            Console.ReadLine();
        }
    }
}
