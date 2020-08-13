using DevEduInterviewSystem.DAL.DTO;
using DevEduInterviewSystem.DAL.Shared;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace DevEduInterviewSystem.DAL.StoredProcedures.CRUD
{
    public class Course_CandidateCRUD : AbstractCRUD<Course_CandidateDTO>
    {
        public override int Add(Course_CandidateDTO dto)
        {
            SqlConnection connection = ConnectionSingleTone.GetInstance().Connection;
            connection.Open();
            SqlCommand command = ReferenceToProcedure("@AddCourse_Candidate");

            SqlParameter CourseIDParam = new SqlParameter("@CourseID", dto.CourseID);
            command.Parameters.Add(CourseIDParam);

            SqlParameter CandidateIDParam = new SqlParameter("@CandidateID", dto.CandidateID);
            command.Parameters.Add(CandidateIDParam);

            return command.ExecuteNonQuery();
        }

        public override int DeleteByID(int id)
        {
            SqlConnection connection = ConnectionSingleTone.GetInstance().Connection;
            connection.Open();
            SqlCommand command = ReferenceToProcedure("@DeleteCourse_CandidateByID");

            SqlParameter IDParam = new SqlParameter("@ID", id);
            command.Parameters.Add(IDParam);

            return command.ExecuteNonQuery();
        }

        public override int UpdateByID(Course_CandidateDTO dto)
        {
            SqlConnection connection = ConnectionSingleTone.GetInstance().Connection;
            connection.Open();
            SqlCommand command = ReferenceToProcedure("@UpdateCourse_CandidateByID");

            SqlParameter IDParam = new SqlParameter("@ID", dto.ID);
            command.Parameters.Add(IDParam);

            SqlParameter CandidateIDParam = new SqlParameter("@CandidateID", dto.CandidateID);
            command.Parameters.Add(CandidateIDParam);

            SqlParameter CourseIDParam = new SqlParameter("@CourseID", dto.CourseID);
            command.Parameters.Add(CandidateIDParam);

            return command.ExecuteNonQuery();
        }

        public override List<Course_CandidateDTO> SelectAll()
        {
            SqlConnection connection = ConnectionSingleTone.GetInstance().Connection;
            connection.Open();
            SqlCommand command = ReferenceToProcedure("@SelectAllCourse_Candidate");

            SqlDataReader reader = command.ExecuteReader();
            List<Course_CandidateDTO> courseCandidates = new List<Course_CandidateDTO>();

            // Если есть данные
            if (reader.HasRows)
            {
                // Построчно считываем данные
                while (reader.Read())
                {
                    Course_CandidateDTO courseCandidate = new Course_CandidateDTO()
                    {
                        ID = (int)reader["id"],
                        CourseID = (int)reader["CourseID"],
                        CandidateID = (int)reader["CandidateID"]
                    };
                    courseCandidates.Add(courseCandidate);
                    Console.WriteLine($"{courseCandidate.ID} \t{courseCandidate.CourseID} \t{courseCandidate.CandidateID}");
                }
            }
            reader.Close();

            return courseCandidates;
        }

        public override Course_CandidateDTO SelectByID(int id)
        {
            SqlConnection connection = ConnectionSingleTone.GetInstance().Connection;
            connection.Open();
            SqlCommand command = ReferenceToProcedure("@SelectCourse_CandidateByID");

            SqlParameter IDParam = new SqlParameter("@ID", id);
            command.Parameters.Add(IDParam);

            SqlDataReader reader = command.ExecuteReader();

            Course_CandidateDTO courseCandidate = new Course_CandidateDTO();
            if (reader.HasRows) // если есть данные
            {
                // выводим названия столбцов
                Console.WriteLine($"ID \t CourseID \t CandidateID");

                while (reader.Read()) // построчно считываем данные
                {
                    courseCandidate.ID = (int)reader["id"];
                    courseCandidate.CourseID = (int)reader["CourseID"];
                    courseCandidate.CandidateID = (int)reader["CandidateID"];
                    Console.WriteLine($"{courseCandidate.ID} \t{courseCandidate.CourseID} \t{courseCandidate.CandidateID} ");
                }
            }
            reader.Close();

            return courseCandidate;
        }
    }
}
