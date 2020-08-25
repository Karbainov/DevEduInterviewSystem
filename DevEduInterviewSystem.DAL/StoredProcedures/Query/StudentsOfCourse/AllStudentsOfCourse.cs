using DevEduInterviewSystem.DAL.DTO.QuereDTO;
using DevEduInterviewSystem.DAL.DTO.QuereDTO.StudentsOfCourse;
using DevEduInterviewSystem.DAL.Shared;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DevEduInterviewSystem.DAL.StoredProcedures.Query
{
    public class AllStudentsOfCourse
    {

        public List<AllStudentsOfCourseDTO> SelectAllStudentsOfCourse(int idnumber )
        {
            SqlConnection Connection = new SqlConnection(ConnectionSingleTone.GetInstance().ConnectionString);
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("AllStudentsOfCourse", Connection);
            SqlParameter CourseParam = new SqlParameter("@CourseID", idnumber);
            command.Parameters.Add(CourseParam);

            List<AllStudentsOfCourseDTO> allStudentsOfCourses = new List<AllStudentsOfCourseDTO>();

            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    AllStudentsOfCourseDTO allStudentsOfCourse = new AllStudentsOfCourseDTO()
                    {
                        Name = (string)reader["Name"],
                        StudentFirstName = (string)reader["FirstName"],
                        StudentLastName = (string)reader["LastName"]
                    };

                    allStudentsOfCourses.Add(allStudentsOfCourse);
                }
            }
            reader.Close();

            return allStudentsOfCourses;

        }
        private SqlCommand ReferenceToProcedure(string sqlExpression, SqlConnection connection)
        {
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            return command;
        }
    }
}
