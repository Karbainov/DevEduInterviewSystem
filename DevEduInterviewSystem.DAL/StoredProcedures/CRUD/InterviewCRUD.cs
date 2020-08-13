using DevEduInterviewSystem.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace DevEduInterviewSystem.DAL.StoredProcedures.CRUD
{
    public class InterviewCRUD : AbstractCRUD<InterviewDTO>
    {
        public override int Add(InterviewDTO dto)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("AddInterview");

            SqlParameter CandidateParam = new SqlParameter("@CandidateID", dto.CandidateID);
            command.Parameters.Add(CandidateParam);

            SqlParameter InterviewStatusParam = new SqlParameter("@InterviewStatusID", dto.InterviewStatusID);
            command.Parameters.Add(InterviewStatusParam);

            SqlParameter AttemptParam = new SqlParameter("@Attempt", dto.Attempt);
            command.Parameters.Add(AttemptParam);

            SqlParameter DateTimeInterviewParam = new SqlParameter("@DateTimeInterview", dto.DateTimeInterview);
            command.Parameters.Add(DateTimeInterviewParam);

            return command.ExecuteNonQuery();
        }

        public override int DeleteByID(int id)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("DeleteInterviewByID");

            SqlParameter IDParam = new SqlParameter("@ID", id);
            command.Parameters.Add(IDParam);

            return command.ExecuteNonQuery();
        }

        public override List<InterviewDTO> SelectAll()
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectAllInterview");

            SqlDataReader reader = command.ExecuteReader();

            List<InterviewDTO> list = new List<InterviewDTO>();

            if (reader.HasRows)
            {

                while (reader.Read())
                {
                    InterviewDTO interview = new InterviewDTO();
                    interview.ID = (int)reader["id"];
                    interview.CandidateID = (int)reader["CandidateID"];
                    interview.InterviewStatusID = (int)reader["InterviewStatusID"];
                    interview.Attempt = (int)reader["Attempt"];
                    interview.DateTimeInterview = (DateTime)reader["DateTimeInterview"];

                    list.Add(interview);
                }
            }
            reader.Close();

            return list;
        }

        public override InterviewDTO SelectByID(int id)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectInterviewByID");

            SqlParameter IDParam = new SqlParameter("@ID", id);
            command.Parameters.Add(IDParam);

            SqlDataReader reader = command.ExecuteReader();

            InterviewDTO interview = new InterviewDTO();

            if (reader.HasRows)
            {
                while (reader.Read()) // построчно считываем данные
                {
                    interview.ID = (int)reader["id"];
                    interview.CandidateID = (int)reader["CandidateID"];
                    interview.InterviewStatusID = (int)reader["InterviewStatusID"];
                    interview.Attempt = (int)reader["Attempt"];
                    interview.DateTimeInterview = (DateTime)reader["DateTimeInterview"];
                }
            }
            reader.Close();

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

            return command.ExecuteNonQuery();

        }
    }
}

