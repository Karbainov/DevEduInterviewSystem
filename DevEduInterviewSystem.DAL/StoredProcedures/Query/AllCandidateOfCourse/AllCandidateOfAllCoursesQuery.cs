using DevEduInterviewSystem.DAL.DTO.QuereDTO;
using DevEduInterviewSystem.DAL.Shared;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DevEduInterviewSystem.DAL.StoredProcedures.Query
{
    public class AllCandidateOfAllCoursesQuery
    {
<<<<<<< HEAD:DevEduInterviewSystem.DAL/StoredProcedures/Query/AllStudentsOfCourse/AllStudentsOfAllCoursesQuery.cs
        public List<AllStudentsOfCourseDTO> SelectAllAllStudentsOfCourse()
=======

        public List<AllCandidateOfCourseDTO> SelectAllAllStudentsOfCourse()
>>>>>>> AllStudentsOfAllCourses:DevEduInterviewSystem.DAL/StoredProcedures/Query/AllCandidateOfCourse/AllCandidateOfAllCoursesQuery.cs
        {
            SqlConnection Connection = new SqlConnection(ConnectionSingleTone.GetInstance().ConnectionString);
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("AllStudentsOfCourse", Connection);

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

