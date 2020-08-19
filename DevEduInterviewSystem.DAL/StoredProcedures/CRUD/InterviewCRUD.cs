using System;
using DevEduInterviewSystem.DAL.DTO;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace DevEduInterviewSystem.DAL.StoredProcedures.CRUD
{
    public class InterviewCRUD : AbstractCRUD<InterviewDTO>
    {
        public override int Add(InterviewDTO dto)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("AddInterview");

            if(dto.CandidateID != null)
            {
                SqlParameter CandidateParam = new SqlParameter("@CandidateID", dto.CandidateID);
                command.Parameters.Add(CandidateParam);
            }

            if (dto.InterviewStatusID!= null)
            {
                SqlParameter InterviewStatusParam = new SqlParameter("@InterviewStatusID", dto.InterviewStatusID);
                command.Parameters.Add(InterviewStatusParam);
            }

            if (dto.Attempt != null)
            {
                SqlParameter AttemptParam = new SqlParameter("@Attempt", dto.Attempt);
                command.Parameters.Add(AttemptParam);
            }

            if (dto.DateTimeInterview != null)
            {
                SqlParameter DateTimeInterviewParam = new SqlParameter("@DateTimeInterview", dto.DateTimeInterview);
                command.Parameters.Add(DateTimeInterviewParam);
            }
                

                

            command.ExecuteNonQuery();

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
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("UpdateInterviewByID");

            SqlParameter IDParam = new SqlParameter("@ID", dto.ID);
            command.Parameters.Add(IDParam);

            SqlParameter CandidateParam = new SqlParameter("@CandidateID", dto.CandidateID);
            command.Parameters.Add(CandidateParam);

            SqlParameter InterviewStatusParam = new SqlParameter("@InterviewStatusID", dto.InterviewStatusID);
            command.Parameters.Add(InterviewStatusParam);

            SqlParameter AttemptParam = new SqlParameter("@Attempt", dto.Attempt);
            command.Parameters.Add(AttemptParam);

            SqlParameter DateTimeInterviewParam = new SqlParameter("@DateTimeInterview", dto.DateTimeInterview);
            command.Parameters.Add(DateTimeInterviewParam);

            int rows = command.ExecuteNonQuery();
            Connection.Close();

            return rows;

        }
    }
}

