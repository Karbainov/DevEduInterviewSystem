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

            SqlParameter NameParam = new SqlParameter("@Name", dto.Name);
            command.Parameters.Add(NameParam);

            int a = (int)(decimal)command.ExecuteScalar();
            Connection.Close();
            return a;
        }
        

        public override int DeleteByID(int id)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("DeleteStatusByID");

            SqlParameter IDParam = new SqlParameter("@ID", id);
            command.Parameters.Add(IDParam);

            int a = command.ExecuteNonQuery();
            Connection.Close();
            return a;
        }

       

        public override List<StatusDTO> SelectAll()
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectAllStatus");

            SqlDataReader reader = command.ExecuteReader();

            List<StatusDTO> statuses = new List<StatusDTO>();

            if (reader.HasRows) // если есть данные
            {
                while (reader.Read()) // построчно считываем данные
                {
                    StatusDTO status = new StatusDTO()
                    {
                        ID = (int)reader["id"],
                        Name = (string)reader["Name"],
                    };
                    statuses.Add(status);
                }
            }
            reader.Close();
            Connection.Close();

            return statuses;
        }

       

        public override StatusDTO SelectByID(int id)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectStatusByID");

            SqlParameter IDParam = new SqlParameter("@ID", id);
            command.Parameters.Add(IDParam);

            SqlDataReader reader = command.ExecuteReader();
            StatusDTO status = new StatusDTO();

            if (reader.HasRows) // если есть данные
            {
                while (reader.Read()) // построчно считываем данные
                {
                    status.ID = (int)reader["id"];
                    status.Name = (string)reader["Name"];
                }
            }
            reader.Close();
            Connection.Close();
            return status;
        }

        

        public override int UpdateByID(StatusDTO dto)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("UpdateStatusByID");

            SqlParameter IDParam = new SqlParameter("@ID", dto.ID);
            command.Parameters.Add(IDParam);

            SqlParameter NameParam = new SqlParameter("@Name", dto.Name);
            command.Parameters.Add(NameParam);

            int a = command.ExecuteNonQuery();
            Connection.Close();
            return a;
        }      
    }
}
