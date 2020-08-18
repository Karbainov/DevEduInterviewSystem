using DevEduInterviewSystem.DAL.DTO;
using DevEduInterviewSystem.DAL.StoredProcedures.CRUD;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DevEduInterviewSystem.BLL
{
    public class AdminRoleLogic : IRoleLogic
    {
        //public SqlConnection Connection { get ; set; }
        //public void GetConnection()
        //{
        //}

        #region Methods for adding fields in system tables
        public void AddRole(RoleDTO role, RoleCRUD crud)
        {
            crud.Add(role);
        }
        public void AddStage(StageDTO stage, StageCRUD crud)
        {
            crud.Add(stage);
        }
        public void AddStatus(StatusDTO status, StatusCRUD crud)
        {
            crud.Add(status);
        }
        public void InsertCity(CityDTO city, CityCRUD crud)
        {
            crud.Add(city);
        }
        #endregion

        public void AddNewUser(UserDTO userDTO, UserCRUD user, UserRoleDTO roleDTO, UserRoleCRUD role)
        {
            user.Add(userDTO);
            role.UpdateByID(roleDTO);
        }

    }
}