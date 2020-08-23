using DevEduInterviewSystem.DAL.DTO;
using DevEduInterviewSystem.DAL.DTO.QuereDTO;
using DevEduInterviewSystem.DAL.StoredProcedures;
using DevEduInterviewSystem.DAL.StoredProcedures.CRUD;
using DevEduInterviewSystem.DAL.StoredProcedures.Query;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DevEduInterviewSystem.BLL
{
    public class AdminRoleLogic : IRoleLogic
    {
        public void ChangeNumberOfInterviewsInOnePeriod(int? number)
        {
            InterviewsNumber interviewsLimit =  InterviewsNumber.GetInstance();
            interviewsLimit.InterviewsLimit = (int)number;
        }

        #region Methods for adding fields in system tables
       
        public void AddStage(StageDTO stage)
        {
            StageCRUD crud = new StageCRUD();
            crud.Add(stage);
        }
        public void AddStatus(StatusDTO status)
        {
            StatusCRUD crud = new StatusCRUD();
            crud.Add(status);
        }
        public void AddCourse(CourseDTO course)
        {
            CourseCRUD crud = new CourseCRUD();
            crud.Add(course);
        }

        #endregion

        #region Methods for user
        public void AddNewUser(UserDTO userDTO, int? roleID)
        {
            UserCRUD user = new UserCRUD();
            int id = user.Add(userDTO);
           
            UserRoleDTO roleDTO = new UserRoleDTO(id, roleID);
            UserRoleCRUD role = new UserRoleCRUD();
            role.Add(roleDTO);
        }

        public List<UsersWithRoleDTO> ShowAllUsersWithRoles()
        {
            UsersWithRoleProcedure usersWithRole = new UsersWithRoleProcedure();
            List<UsersWithRoleDTO> allUsers = usersWithRole.SelectUsersWithRole();
            return allUsers;
        }

        public void ShowDeletedUsers()
        { 
            AllDeletedUsers users = new AllDeletedUsers();
            users.SelectAllDeletedUsers();
        }

        public void DeleteUser(int? userID)
        {
            UserCRUD deletion = new UserCRUD();
            deletion.DeleteByID((int)userID);
        }

        public void RestoreUser(int? userID)
        {
            RestoreDeletedUserByID restoration = new RestoreDeletedUserByID();
            restoration.RestoreUserByID((int)userID);
        }

        public void UpdateUser(UserDTO dto)
        {
            UserCRUD user = new UserCRUD();
            user.UpdateByID(dto);
        }
        #endregion

        #region Methods for City
        public void AddCity(CityDTO city)
        {
            CityCRUD crud = new CityCRUD();
            crud.Add(city);
        }
        public void DeleteCity(CityDTO cityDTO)
        {
            CityCRUD city = new CityCRUD();
            city.DeleteByID((int)cityDTO.ID);
        }
        #endregion
    }
}