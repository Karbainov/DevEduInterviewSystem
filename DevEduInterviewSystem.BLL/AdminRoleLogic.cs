using DevEduInterviewSystem.DAL.DTO;
using DevEduInterviewSystem.DAL.StoredProcedures.CRUD;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DevEduInterviewSystem.BLL
{
    public class AdminRoleLogic : ARoleLogic
    {
        public void InsertCity(CityDTO city, CityCRUD crud)
        {
            crud.Add(city);
        }
        public void AddNewUser(UserDTO user, UserRoleDTO role)
        {
            AddUser(user);
            UpdateUserRole(role);

        }
        private int AddUser(UserDTO dto)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("AddUser");

            SqlParameter LoginParam = new SqlParameter("@Login", dto.Login);
            command.Parameters.Add(LoginParam);

            SqlParameter PasswordParam = new SqlParameter("@Password", dto.Password);
            command.Parameters.Add(PasswordParam);

            SqlParameter FirstNameParam = new SqlParameter("@FirstName", dto.FirstName);
            command.Parameters.Add(FirstNameParam);

            SqlParameter LastNameParam = new SqlParameter("@LastName", dto.LastName);
            command.Parameters.Add(LastNameParam);

            SqlParameter IsDeletedParam = new SqlParameter("@IsDeleted", dto.IsDeleted);
            command.Parameters.Add(IsDeletedParam);

            command.ExecuteNonQuery();

            SqlCommand returnCurrentID = new SqlCommand("SELECT MAX([ID]) FROM dbo.[User]", Connection);
            int count = (int)returnCurrentID.ExecuteScalar();

            Connection.Close();
            return count;
        }
        private int UpdateUserRole(UserRoleDTO dto)
        {
            Connection.Open();
            SqlCommand command = ReferenceToProcedure("UpdateUserRoleByID");

            SqlParameter IDParam = new SqlParameter("@ID", dto.ID);
            command.Parameters.Add(IDParam);

            SqlParameter UserID = new SqlParameter("@UserID", dto.UserID);
            command.Parameters.Add(UserID);

            SqlParameter RoleID = new SqlParameter("@RoleID", dto.RoleID);
            command.Parameters.Add(RoleID);

            int rows = command.ExecuteNonQuery();
            Connection.Close();

            return rows;
        }
    }
}