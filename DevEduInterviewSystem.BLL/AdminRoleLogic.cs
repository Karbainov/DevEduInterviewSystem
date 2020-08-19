using DevEduInterviewSystem.DAL.DTO;
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
        public void ChangeNumberOfInterviewsInOnePeriod(int number)
        {
            InterviewsNumber interviewsLimit =  InterviewsNumber.GetInstance();
            interviewsLimit.InterviewsLimit = number;
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
        public void AddCity(CityDTO city)
        {
            CityCRUD crud = new CityCRUD();
            crud.Add(city);
        }
        public void AddCourse(CourseDTO course)
        {
            CourseCRUD crud = new CourseCRUD();
            crud.Add(course);
        }

        #endregion

        public void AddNewUser(UserDTO userDTO, int roleID)
        {
            UserCRUD user = new UserCRUD();
            user.Add(userDTO);
           
            UserRoleDTO roleDTO = new UserRoleDTO(userDTO.ID, roleID);
            UserRoleCRUD role = new UserRoleCRUD();
            role.Add(roleDTO);
        }

        public void ShowDeletedUsers()
        { 
            //+роли
            AllDeletedUsers users = new AllDeletedUsers();
            users.SelectAllDeletedUsers();
        }
    }
}