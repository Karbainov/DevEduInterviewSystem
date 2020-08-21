using Dapper;
using DevEduInterviewSystem.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DevEduInterviewSystem.DAL.StoredProcedures.CRUD
{
    public class InterviewCRUD : AbstractCRUD<InterviewDTO>
    {
        public override int Add(InterviewDTO dto)
        {
            var procedure = "[AddInterview]";
            var values = new
            {
                CandidateID = dto.CandidateID,
                InterviewStatusID = dto.InterviewStatusID,
                Attempt = dto.Attempt,
                DateTimeInterview = dto.DateTimeInterview
            };

            IDbConnection.Query(procedure, values, commandType: CommandType.StoredProcedure);

            Connection.Open();
            SqlCommand returnCurrentID = new SqlCommand("SELECT MAX([ID]) FROM dbo.[Interview]", Connection);
            int count = (int)returnCurrentID.ExecuteScalar();

            Connection.Close();

            return count;
        }

        public override int DeleteByID(int id)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("DeleteInterviewByID");

            SqlParameter IDParam = new SqlParameter("@ID", id);
            command.Parameters.Add(IDParam);

            int rows = command.ExecuteNonQuery();
            Connection.Close();

            return rows;
        }

        public override List<InterviewDTO> SelectAll()
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectAllInterview");

            SqlDataReader reader = command.ExecuteReader();

            List<InterviewDTO> interviews = new List<InterviewDTO>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    InterviewDTO interview = new InterviewDTO()
                    {
                        ID = (int)reader["id"],
                        CandidateID = (int)reader["CandidateID"],
                        InterviewStatusID = (int)reader["InterviewStatusID"],
                        Attempt = (int)reader["Attempt"],
                        DateTimeInterview = (DateTime)reader["DateTimeInterview"]
                    };

                    interviews.Add(interview);
                }
            }
            reader.Close();
            Connection.Close();

            return interviews;

        }

        public override InterviewDTO SelectByID(int ID)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectInterviewByID");

            SqlParameter IDParam = new SqlParameter("@ID", ID);
            command.Parameters.Add(IDParam);

            SqlDataReader reader = command.ExecuteReader();
            InterviewDTO interview = new InterviewDTO();

            if (reader.HasRows)
            {

                while (reader.Read())
                {
                    interview.ID = (int)reader["id"];
                    interview.CandidateID = (int)reader["CandidateID"];
                    interview.InterviewStatusID = (int)reader["InterviewStatusID"];
                    interview.Attempt = (int)reader["Attempt"];
                    interview.DateTimeInterview = (DateTime)reader["DateTimeInterview"];
                }
            }
            reader.Close();
            Connection.Close();
            return interview;
        }

        public override int UpdateByID(InterviewDTO dto)
        {
            var procedure = "[UpdateInterviewByID]";
            var values = new
            {
                ID = dto.ID,
                CandidateID = dto.CandidateID,
                InterviewStatusID = dto.InterviewStatusID,
                Attempt = dto.Attempt,
                DateTimeInterview = dto.DateTimeInterview
            };

            IDbConnection.Query(procedure, values, commandType: CommandType.StoredProcedure);

            return (int)dto.ID;
        }
    }
}

