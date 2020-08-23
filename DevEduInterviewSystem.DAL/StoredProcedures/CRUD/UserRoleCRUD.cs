using Dapper;
using DevEduInterviewSystem.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DevEduInterviewSystem.DAL.StoredProcedures.CRUD
{
    public class UserRoleCRUD: AbstractCRUD<UserRoleDTO>
    {
        public override int Add(UserRoleDTO dto)
        {
           var procedure = "[AddUser_Role]";
                var values = new
                {
                    dto.UserID,
                    dto.RoleID
                };
            IDbConnection.Query(procedure, values, commandType: CommandType.StoredProcedure);

            Connection.Open();
            SqlCommand returnCurrentID = new SqlCommand("SELECT MAX([ID]) FROM dbo.[User_Role]", Connection);
            int count = (int)returnCurrentID.ExecuteScalar();

            Connection.Close();

            return count;
        }

        public override int DeleteByID(int id)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("DeleteUser_RoleByID");

            SqlParameter IDParam = new SqlParameter("@ID", id);
            command.Parameters.Add(IDParam);

            int rows = command.ExecuteNonQuery();
            Connection.Close();

            return rows;
        }

        public override List<UserRoleDTO> SelectAll()
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectAllUser_Role");
            SqlDataReader reader = command.ExecuteReader();
            List<UserRoleDTO> userRoles = new List<UserRoleDTO>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    UserRoleDTO userRole = new UserRoleDTO() 
                    {
                        ID = (int)reader["ID"],
                        UserID = (int)reader["UserID"],
                        RoleID = (int)reader["RoleID"]
                    };
                    userRoles.Add(userRole);
                }
            }
            reader.Close();
            Connection.Close();
            return userRoles;
        }
        public override UserRoleDTO SelectByID(int id)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectUser_RoleByID");

            SqlParameter IDParam = new SqlParameter("@ID", id);
            command.Parameters.Add(IDParam);

            SqlDataReader reader = command.ExecuteReader();
            UserRoleDTO userRole = new UserRoleDTO();
            if (reader.HasRows) 
            {
                while (reader.Read())
                {
                    userRole.ID = (int)reader["id"];
                    userRole.UserID = (int)reader["UserID"];
                    userRole.RoleID = (int)reader["RoleID"];
                }
            }
            reader.Close();
            Connection.Close();
            return userRole;
        }
        public override int UpdateByID(UserRoleDTO dto)
        {
            var procedure = "[UpdateUser_RoleByID]";
            var values = new
            {
                dto.ID,
                dto.UserID,
                dto.RoleID             
            };
            IDbConnection.Query(procedure, values, commandType: CommandType.StoredProcedure);
            return (int) dto.ID;
        }
    }
}
