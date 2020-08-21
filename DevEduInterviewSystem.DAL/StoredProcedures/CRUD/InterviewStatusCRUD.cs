using Dapper;
using DevEduInterviewSystem.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DevEduInterviewSystem.DAL.StoredProcedures.CRUD
{
    public class InterviewStatusCRUD : AbstractCRUD<InterviewStatusDTO>
    {
        public override int Add(InterviewStatusDTO dto)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("AddInterviewStatus");

            if (dto.Name != null)
            {
                SqlParameter NameParam = new SqlParameter("@Name", dto.Name);
                command.Parameters.Add(NameParam);
            }
                

            command.ExecuteNonQuery();
            SqlCommand returnCurrentID = new SqlCommand("SELECT MAX([ID]) FROM dbo.[InterviewStatus]", Connection);
            int count = (int)returnCurrentID.ExecuteScalar();

            Connection.Close();

            return count;
        }

        public override int DeleteByID(int ID)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("DeleteInterviewStatusByID");

            SqlParameter IDParam = new SqlParameter("@ID", ID);
            command.Parameters.Add(IDParam);

            int rows = command.ExecuteNonQuery();
            Connection.Close();

            return rows;
        }

        public override List<InterviewStatusDTO> SelectAll()
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectAllInterviewStatus");

            List<InterviewStatusDTO> interviewsstatus = new List<InterviewStatusDTO>();

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {

                while (reader.Read()) 
                {
                    InterviewStatusDTO interviewstatus = new InterviewStatusDTO()
                    {
                        ID = (int)reader["id"],
                        Name = (string)reader["Name"]
                    };

                    interviewsstatus.Add(interviewstatus);
                }
                
            }
            reader.Close();
            Connection.Close();
            return interviewsstatus;
        }

        public override InterviewStatusDTO SelectByID(int id)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectInterviewStatusByID");

            SqlParameter IDParam = new SqlParameter("@ID", id);
            command.Parameters.Add(IDParam);

            SqlDataReader reader = command.ExecuteReader();
            InterviewStatusDTO interviewStatus = new InterviewStatusDTO();

            InterviewStatusDTO interviewstatus = new InterviewStatusDTO();

            if (reader.HasRows) // если есть данные
            {
                while (reader.Read()) // построчно считываем данные
                {
                    interviewstatus.ID = (int)reader["id"];
                    interviewstatus.Name = (string)reader["Name"];
                }
            }
            reader.Close();
            Connection.Close();
            return interviewstatus;
        }

        public override int UpdateByID(InterviewStatusDTO interviewStatus)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("UpdateInterviewStatusByID");

            SqlParameter IDParam = new SqlParameter("@ID", interviewStatus.ID);
            command.Parameters.Add(IDParam);

            SqlParameter NameParam = new SqlParameter("@Name", interviewStatus.Name);
            command.Parameters.Add(NameParam);

            int rows = command.ExecuteNonQuery();
            Connection.Close();

            return rows;
        }
    }
}
