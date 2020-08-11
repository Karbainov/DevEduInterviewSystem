using System;
using System.Data.SqlClient;
using DevEduInterviewSystem.DAL.DTO;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.StoredProcedures.CRUD
{
    public class RoleCRUD : AbstractCRUD<RoleDTO>
    {
        public override int Add(RoleDTO dto)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("AddRole", Connection);

            SqlParameter TypeOfRoleParam = new SqlParameter("@TypeOfRole", dto.TypeOfRole);
            command.Parameters.Add(TypeOfRoleParam);

            return command.ExecuteNonQuery();
        }

        public override int DeleteByID(int id)
        {
            Connection.Open();
            string sqlExpression = "DeleteRoleByID";
            SqlCommand command = new SqlCommand(sqlExpression, Connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter IDParam = new SqlParameter("@ID", id);
            command.Parameters.Add(IDParam);

            return command.ExecuteNonQuery();
        }
        public override List<RoleDTO> SelectAll()
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectAllRole", Connection);
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
            return roles;
        }
        public override RoleDTO SelectByID(int id)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectRoleByID", Connection);

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
            return role;
        }
        public override int UpdateByID(RoleDTO dto)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("UpdateRoleByID", Connection);

            SqlParameter IDParam = new SqlParameter("@ID", dto.ID);
            command.Parameters.Add(IDParam);

            SqlParameter TypeOfRoleParam = new SqlParameter("@TypeOfRole", dto.TypeOfRole);
            command.Parameters.Add(TypeOfRoleParam);

            return command.ExecuteNonQuery();
        }
    }
}
