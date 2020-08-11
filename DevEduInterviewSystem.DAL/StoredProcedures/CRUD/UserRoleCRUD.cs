﻿using DevEduInterviewSystem.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DevEduInterviewSystem.DAL.StoredProcedures.CRUD
{
    public class UserRoleCRUD: AbstractCRUD<UserRoleDTO>
    {
        public override int Add(UserRoleDTO dto)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("AddUserRole", Connection);

            SqlParameter UserID = new SqlParameter("@UserID", dto.UserID);
            command.Parameters.Add(UserID);

            SqlParameter RoleID = new SqlParameter("@RoleID", dto.RoleID);
            command.Parameters.Add(RoleID);

            return command.ExecuteNonQuery();
        }

        public override int DeleteByID(int id)
        {
            Connection.Open();
            string sqlExpression = "DeleteUserRoleByID";
            SqlCommand command = new SqlCommand(sqlExpression, Connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter IDParam = new SqlParameter("@ID", id);
            command.Parameters.Add(IDParam);

            return command.ExecuteNonQuery();
        }

        public override List<UserRoleDTO> SelectAll()
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectAllUserRole", Connection);
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
            return userRoles;
        }
        public override UserRoleDTO SelectByID(int id)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("SelectUserRoleByID", Connection);

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
            return userRole;
        }
        public override int UpdateByID(UserRoleDTO dto)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("UpdateUserRoleByID", Connection);

            SqlParameter IDParam = new SqlParameter("@ID", dto.ID);
            command.Parameters.Add(IDParam);

            SqlParameter UserID = new SqlParameter("@UserID", dto.UserID);
            command.Parameters.Add(UserID);

            SqlParameter RoleID = new SqlParameter("@RoleID", dto.RoleID);
            command.Parameters.Add(RoleID);

            return command.ExecuteNonQuery();
        }
    }
}
