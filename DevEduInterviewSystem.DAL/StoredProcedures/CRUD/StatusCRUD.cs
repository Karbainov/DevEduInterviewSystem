using System;
using System.Data.SqlClient;
using DevEduInterviewSystem.DAL.DTO;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Data;

namespace DevEduInterviewSystem.DAL.StoredProcedures.CRUD
{
    public class StatusCRUD : AbstractCRUD<StatusDTO>
    {
        public override int Add(StatusDTO dto)
        {
            var procedure = "[AddStatus]";
            var values = new
            {
                dto.Name
            };
            IDbConnection.Query(procedure, values, commandType: CommandType.StoredProcedure);
            Connection.Open();
            SqlCommand returnCurrentID = new SqlCommand("SELECT MAX([ID]) FROM dbo.[Status]", Connection);
            int count = (int)returnCurrentID.ExecuteScalar();

            Connection.Close();

            return count;          
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

            if (reader.HasRows) 
            {
                while (reader.Read()) 
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

            if (reader.HasRows) 
            {
                while (reader.Read()) 
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
            var procedure = "[UpdateStatusByID]";
            var values = new
            {
                dto.ID,
                dto.Name
            };
            IDbConnection.Query(procedure, values, commandType: CommandType.StoredProcedure);
            return (int)dto.ID;          
        }      
    }
}
