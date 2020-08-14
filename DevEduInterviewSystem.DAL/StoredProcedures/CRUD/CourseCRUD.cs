using DevEduInterviewSystem.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DevEduInterviewSystem.DAL.StoredProcedures.CRUD
{
    public class CourseCRUD : AbstractCRUD<CourseDTO>
    {
        public override int Add(CourseDTO dto)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("AddCourse");

            SqlParameter NameParam = new SqlParameter("@Name", dto.Name);
            command.Parameters.Add(NameParam);

            int a = (int)(decimal)command.ExecuteScalar();
            Connection.Close();
            return a;
        }

        public override int DeleteByID(int id)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("DeleteCourseByID");

            SqlParameter IDParam = new SqlParameter("@ID", id);
            command.Parameters.Add(IDParam);

            int a = command.ExecuteNonQuery();
            Connection.Close();
            return a;
        }

        public override int UpdateByID(CourseDTO dto)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("UpdateCourseByID");

            SqlParameter IDParam = new SqlParameter("@ID", dto.ID);
            command.Parameters.Add(IDParam);

            SqlParameter NameParam = new SqlParameter("@Name", dto.Name);
            command.Parameters.Add(NameParam);

            int a = command.ExecuteNonQuery();
            Connection.Close();
            return a;
        }

        public override List<CourseDTO> SelectAll()
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectAllCourse");

            SqlDataReader reader = command.ExecuteReader();

            List<CourseDTO> courses = new List<CourseDTO>();

            if (reader.HasRows) // если есть данные
            {
                while (reader.Read()) // построчно считываем данные
                {
                    CourseDTO course = new CourseDTO()
                    {
                        ID = (int)reader["id"],
                        Name = (string)reader["Name"],
                    };
                    courses.Add(course);
                }
            }
            reader.Close();
            Connection.Close();
            return courses;
        }

        public override CourseDTO SelectByID(int id)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectCourseByID");

            SqlParameter IDParam = new SqlParameter("@ID", id);
            command.Parameters.Add(IDParam);

            SqlDataReader reader = command.ExecuteReader();
            CourseDTO stage = new CourseDTO();

            if (reader.HasRows) // если есть данные
            {
                while (reader.Read()) // построчно считываем данные
                {
                    stage.ID = (int)reader["id"];
                    stage.Name = (string)reader["Name"];
                }
            }
            reader.Close();
            Connection.Close();
            return stage;
        }
    }
}
