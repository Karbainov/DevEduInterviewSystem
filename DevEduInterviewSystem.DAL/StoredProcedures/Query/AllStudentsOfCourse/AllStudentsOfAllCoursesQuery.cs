using DevEduInterviewSystem.DAL.DTO.QuereDTO;
using DevEduInterviewSystem.DAL.Shared;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DevEduInterviewSystem.DAL.StoredProcedures.Query
{
    public class AllStudentsOfAllCoursesQuery
    {

        public List<AllStudentsOfCourseDTO> SelectAllAllStudentsOfCourse()
        {
            SqlConnection Connection = ConnectionSingleTone.GetInstance().Connection;
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("AllStudentsOfCourse", Connection);

            List<AllStudentsOfCourseDTO> allStudentsOfAllCourses = new List<AllStudentsOfCourseDTO>();

            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    AllStudentsOfCourseDTO allStudentsOfAllCourse = new AllStudentsOfCourseDTO()
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

