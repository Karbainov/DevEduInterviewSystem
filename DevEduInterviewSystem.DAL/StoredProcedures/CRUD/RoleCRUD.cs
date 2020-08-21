using Dapper;
using DevEduInterviewSystem.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DevEduInterviewSystem.DAL.StoredProcedures.CRUD
{
    public class RoleCRUD : AbstractCRUD<RoleDTO>
    {
        public override int Add(RoleDTO dto)
        {
            var procedure = "[AddRole]";
            var values = new
            {
                TypeOfRole = dto.TypeOfRole
            };

            IDbConnection.Query(procedure, values, commandType: CommandType.StoredProcedure);

            Connection.Open();
            SqlCommand returnCurrentID = new SqlCommand("SELECT MAX([ID]) FROM dbo.[Role]", Connection);
            int count = (int)returnCurrentID.ExecuteScalar();

            Connection.Close();

            return count;
        }

        public override int DeleteByID(int id)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("DeleteRoleByID");

            SqlParameter IDParam = new SqlParameter("@ID", id);
            command.Parameters.Add(IDParam);

            int rows = command.ExecuteNonQuery();
            Connection.Close();

            return rows;
        }
        public override List<RoleDTO> SelectAll()
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectAllRole");
            SqlDataReader reader = command.ExecuteReader();
            List<RoleDTO> roles = new List<RoleDTO>();
            if (reader.HasRows)
            {
                while (reader.Read()) 
                {
                    RoleDTO role = new RoleDTO()
                    { 
                    ID = (int)reader["ID"],
                    TypeOfRole = (string)reader["TypeOfRole"]
                    };
                    roles.Add(role);
                }
            }
            reader.Close();
            Connection.Close();
            return roles;
        }
        public override RoleDTO SelectByID(int id)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectRoleByID");

            SqlParameter IDParam = new SqlParameter("@ID", id);
            command.Parameters.Add(IDParam);

            SqlDataReader reader = command.ExecuteReader();
            RoleDTO role = new RoleDTO();
            if (reader.HasRows) 
            {
                while (reader.Read()) 
                {
                    role.ID = (int)reader["id"];
                    role.TypeOfRole = (string)reader["TypeOfRole"];
                }
            }
            reader.Close();
            Connection.Close();
            return role;
        }
        public override int UpdateByID(RoleDTO dto)
        {
            var procedure = "[UpdateRoleByID]";
            var values = new
            {
                ID = dto.ID,
                TypeOfRole = dto.TypeOfRole
            };

            IDbConnection.Query(procedure, values, commandType: CommandType.StoredProcedure);

            return (int)dto.ID;
        }
    }
}
