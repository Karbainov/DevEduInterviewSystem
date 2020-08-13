using System;
using System.Data.SqlClient;
using DevEduInterviewSystem.DAL.DTO;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.StoredProcedures.CRUD
{
    public class StatusCRUD : AbstractCRUD<StatusDTO>
    {
        public override int Add(StatusDTO dto)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("AddStatus");

            SqlParameter CandidateIDParam = new SqlParameter("@Name", dto.Name);
            command.Parameters.Add(CandidateIDParam);

            return command.ExecuteNonQuery();
        }

        public override int DeleteByID(int id)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("DeleteStatusByID");

            SqlParameter IDParam = new SqlParameter("@ID", id);
            command.Parameters.Add(IDParam);

            return command.ExecuteNonQuery();
        }

        public override List<StatusDTO> SelectAll()
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectAllStatus");

            SqlDataReader reader = command.ExecuteReader();

            List<StatusDTO> list = new List<StatusDTO>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    StatusDTO status = new StatusDTO()
                    {
                        ID = (int)reader["id"],
                        Name = (string)reader["Name"]
                    };

                    list.Add(status);                    
                }
            }
            reader.Close();

            return list;
        }
                
        public override StatusDTO SelectByID(int id)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectStatusByID");

            SqlParameter IDParam = new SqlParameter("@ID", id);
            command.Parameters.Add(IDParam);

            SqlDataReader reader = command.ExecuteReader();

            StatusDTO status = new StatusDTO();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    status.ID = (int)reader["id"];
                    status.Name = (string)reader["Name"];
                }
            }
            reader.Close();

            return status;
        }

        public override int UpdateByID(StatusDTO dto)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("UpdateStatusByID");

            SqlParameter IDParam = new SqlParameter("@ID", dto.ID);
            command.Parameters.Add(IDParam);

            SqlParameter CandidateIDParam = new SqlParameter("@Name", dto.Name);
            command.Parameters.Add(CandidateIDParam);

            return command.ExecuteNonQuery();
        }
                
    }
}
