using DevEduInterviewSystem.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DevEduInterviewSystem.DAL.StoredProcedures.CRUD
{
    public class InterviewStatusCRUD : AbstractCRUD<InterviewStatusDTO>
    {
        public override int Add(InterviewStatusDTO dto)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("AddInterviewStatus");

            SqlParameter NameParam = new SqlParameter("@Name", dto.Name);
            command.Parameters.Add(NameParam);

            return command.ExecuteNonQuery();
        }

        public override int DeleteByID(int id)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("DeleteInterviewStatusByID");

            SqlParameter IDParam = new SqlParameter("@ID", id);
            command.Parameters.Add(IDParam);

            return command.ExecuteNonQuery();
        }

        public override List<InterviewStatusDTO> SelectAll()
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectAllInterviewStatus");

            SqlDataReader reader = command.ExecuteReader();

            List<InterviewStatusDTO> list = new List<InterviewStatusDTO>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    InterviewStatusDTO interviewStatus = new InterviewStatusDTO();

                    interviewStatus.ID = (int)reader["id"];
                    interviewStatus.Name = (string)reader["Name"];

                    list.Add(interviewStatus);
                }
            }
            reader.Close();

            return list;
        }

        public override InterviewStatusDTO SelectByID(int id)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectInterviewStatusByID");

            SqlParameter IDParam = new SqlParameter("@ID", id);
            command.Parameters.Add(IDParam);

            SqlDataReader reader = command.ExecuteReader();
            InterviewStatusDTO interviewStatus = new InterviewStatusDTO();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    interviewStatus.ID = (int)reader["id"];
                    interviewStatus.Name = (string)reader["Name"];
                }
            }
            reader.Close();

            return interviewStatus;
        }

        public override int UpdateByID(InterviewStatusDTO dto)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("UpdateInterviewStatusByID");

            SqlParameter IDParam = new SqlParameter("@ID", dto.ID);
            command.Parameters.Add(IDParam);

            SqlParameter NameParam = new SqlParameter("@Name", dto.Name);
            command.Parameters.Add(NameParam);

            return command.ExecuteNonQuery();
        }
    }
}
