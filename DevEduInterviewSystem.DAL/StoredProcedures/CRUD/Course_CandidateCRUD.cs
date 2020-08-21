using Dapper;
using DevEduInterviewSystem.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DevEduInterviewSystem.DAL.StoredProcedures.CRUD
{
    public class Course_CandidateCRUD: AbstractCRUD<Course_CandidateDTO>
    {
        public override int Add(Course_CandidateDTO dto)
        {
            var procedure = "[AddCourse_Candidate]";
            var values = new
            {
                CourseID = dto.CourseID,
                CandidateID = dto.CandidateID
            };

            IDbConnection.Query(procedure, values, commandType: CommandType.StoredProcedure);

            Connection.Open();
            SqlCommand returnCurrentID = new SqlCommand("SELECT MAX([ID]) FROM dbo.[Candidate]", Connection);
            int count = (int)returnCurrentID.ExecuteScalar();

            Connection.Close();

            return count;
        }

        public override int DeleteByID(int id)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("DeleteCourse_CandidateByID");

            SqlParameter IDParam = new SqlParameter("@ID", id);
            command.Parameters.Add(IDParam);

            int rows = command.ExecuteNonQuery();
            Connection.Close();

            return rows;
        }

        public override int UpdateByID(Course_CandidateDTO dto)
        {
            var procedure = "[UpdateCourse_CandidateByID]";
            var values = new
            {
                ID = dto.ID,
                CourseID = dto.CourseID,
                CandidateID = dto.CandidateID
            };

            IDbConnection.Query(procedure, values, commandType: CommandType.StoredProcedure);           

            return (int)dto.ID;
        }

        public override List<Course_CandidateDTO> SelectAll()
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectAllCourse_Candidate");

            SqlDataReader reader = command.ExecuteReader();

            List<Course_CandidateDTO> candidates = new List<Course_CandidateDTO>();

            if (reader.HasRows)
            {

                while (reader.Read())
                {
                    Course_CandidateDTO candidate = new Course_CandidateDTO();
                    candidate.ID = (int)reader["id"];
                    candidate.CourseID = (int)reader["CourseID"];
                    candidate.CandidateID = (int)reader["CandidateID"];
                    candidates.Add(candidate);
                }
            }
            reader.Close();
            Connection.Close();
            return candidates;
        }

        public override Course_CandidateDTO SelectByID(int id)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectCourse_CandidateByID");

            SqlParameter IDParam = new SqlParameter("@ID", id);
            command.Parameters.Add(IDParam);

            SqlDataReader reader = command.ExecuteReader();
            Course_CandidateDTO candidate = new Course_CandidateDTO();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    candidate.ID = (int)reader["id"];
                    candidate.CourseID = (int)reader["CourseID"];
                    candidate.CandidateID = (int)reader["CandidateID"];
                }
            }
            reader.Close();
            Connection.Close();
            return candidate;
        }
    }
}
