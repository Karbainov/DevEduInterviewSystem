using DevEduInterviewSystem.DAL.DTO.QuereDTO;
using DevEduInterviewSystem.DAL.Shared;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DevEduInterviewSystem.DAL.StoredProcedures.Query
{
    public class AllCandidateOfCourseQuery
    {
<<<<<<< HEAD:DevEduInterviewSystem.DAL/StoredProcedures/Query/AllStudentsOfCourse/AllStudentsOfCourseQuery.cs
        public List<AllStudentsOfCourseDTO> SelectAllAllStudentsOfCourse(int id)
=======

        public List<AllCandidateOfCourseDTO> SelectAllAllStudentsOfCourse(int id)
>>>>>>> AllStudentsOfAllCourses:DevEduInterviewSystem.DAL/StoredProcedures/Query/AllCandidateOfCourse/AllCandidateOfCourseQuery.cs
        {
            SqlConnection Connection = new SqlConnection(ConnectionSingleTone.GetInstance().ConnectionString); 
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("AllStudentsOfCourse", Connection);
            SqlParameter courseParam = new SqlParameter("@CourseID", id);
            command.Parameters.Add(courseParam);

            List<AllCandidateOfCourseDTO> allStudentsOfAllCourses = new List<AllCandidateOfCourseDTO>();

            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    AllCandidateOfCourseDTO allStudentsOfAllCourse = new AllCandidateOfCourseDTO()
                    {
                        Name = (string)reader["Name"]
                    };

                    allStudentsOfAllCourses.Add(allStudentsOfAllCourse);
                }
            }
            reader.Close();

            return allStudentsOfAllCourses;

        }
        private SqlCommand ReferenceToProcedure(string sqlExpression, SqlConnection connection)
        {
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            return command;
        }
    }
}


