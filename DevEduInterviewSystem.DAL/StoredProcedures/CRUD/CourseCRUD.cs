﻿using Dapper;
using DevEduInterviewSystem.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DevEduInterviewSystem.DAL.StoredProcedures.CRUD
{
    public class CourseCRUD : AbstractCRUD<CourseDTO>
    {
        public override int Add(CourseDTO dto)
        {     
            var procedure = "[AddCourse]";
            var values = new
            {
                Name = dto.Name
                
            };

            IDbConnection.Query(procedure, values, commandType: CommandType.StoredProcedure);

            Connection.Open();
            SqlCommand returnCurrentID = new SqlCommand("SELECT MAX([ID]) FROM dbo.[Course]", Connection);
            int count = (int)returnCurrentID.ExecuteScalar();

            Connection.Close();

            return count;
        }

        public override int DeleteByID(int id)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("DeleteCourseByID");

            SqlParameter IDParam = new SqlParameter("@ID", id);
            command.Parameters.Add(IDParam);

            int rows = command.ExecuteNonQuery();
            Connection.Close();
            return rows;
        }

        public override int UpdateByID(CourseDTO dto)
        {
            var procedure = "[UpdateCourseByID]";
            var values = new
            {
                ID = dto.ID,
                Name = dto.Name
            };

            IDbConnection.Query(procedure, values, commandType: CommandType.StoredProcedure);

            return (int)dto.ID;
        }

        public override List<CourseDTO> SelectAll()
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectAllCourse");

            SqlDataReader reader = command.ExecuteReader();

            List<CourseDTO> courses = new List<CourseDTO>();

            if (reader.HasRows)
            {
                while (reader.Read())
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
            CourseDTO stage = null;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    stage = new CourseDTO();
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
