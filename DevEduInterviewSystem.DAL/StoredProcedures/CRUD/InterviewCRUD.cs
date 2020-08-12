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
            SqlCommand command = ReferenceToProcedure("Adddto", Connection);

            SqlParameter CandidateParam = new SqlParameter("@CandidateID", dto.CandidateID);
            command.Parameters.Add(CandidateParam);

            SqlParameter InterviewStatusParam = new SqlParameter("@InterviewStatusID", dto.InterviewStatusID);
            command.Parameters.Add(InterviewStatusParam);

            SqlParameter AttemptParam = new SqlParameter("@AttemptID", dto.Attempt);
            command.Parameters.Add(AttemptParam);

            SqlParameter DateTimeInterviewParam = new SqlParameter("@DateTimeInterview", dto.DateTimeInterview);
            command.Parameters.Add(DateTimeInterviewParam);

            return command.ExecuteNonQuery();
        }

        public override int DeleteByID(int id)
        {
            Connection.Open();
            string sqlExpression = "DeleteInterviewByID";
            SqlCommand command = new SqlCommand(sqlExpression, Connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter IDParam = new SqlParameter("@ID", id);
            command.Parameters.Add(IDParam);

            return command.ExecuteNonQuery();
        }

        public override List<InterviewDTO> SelectAll()
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectAllInterview", Connection);

            SqlDataReader reader = command.ExecuteReader();

            List<InterviewDTO> interviews = new List<InterviewDTO>();

            if (reader.HasRows) // если есть данные
            {
                // выводим названия столбцов
                Console.WriteLine($"id \t CandidateID \t InterviewStatusID \t Attempt \t DateTimeInterview ");

                while (reader.Read()) // построчно считываем данные
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

            return interviews;

        }

        public override InterviewDTO SelectByID(int ID)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectInterviewByID", Connection);

            SqlParameter IDParam = new SqlParameter("@ID", ID);
            command.Parameters.Add(IDParam);

            SqlDataReader reader = command.ExecuteReader();
            InterviewDTO interview = new InterviewDTO();

            if (reader.HasRows) // если есть данные
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

        public int UpdateInterviewByID(SqlConnection connection, InterviewDTO interview, int ID)
        {
            connection.Open();
            SqlCommand command = ReferenceToProcedure("UpdateInterviewByID", connection);

            SqlParameter IDParam = new SqlParameter("@ID", ID);
            command.Parameters.Add(IDParam);

            SqlParameter CandidateParam = new SqlParameter("@CandidateID", interview.CandidateID);
            command.Parameters.Add(CandidateParam);

            SqlParameter InterviewStatusParam = new SqlParameter("@InterviewStatusID", interview.InterviewStatusID);
            command.Parameters.Add(InterviewStatusParam);

            SqlParameter AttemptParam = new SqlParameter("@Attempt", interview.Attempt);
            command.Parameters.Add(AttemptParam);

            SqlParameter DateTimeInterviewParam = new SqlParameter("@DateTimeInterview", interview.DateTimeInterview);
            command.Parameters.Add(DateTimeInterviewParam); 

            return command.ExecuteNonQuery();
        }

        private SqlCommand ReferenceToProcedure(string sqlExpression, SqlConnection connection)
        {
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            return command;
        }
    }
}

