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
        public InterviewsNumber interviewsLimit { get; set; }
        public void ChangeNumberOfInterviewsInOnePeriod(int number)
        {
            interviewsLimit = new InterviewsNumber(number);
        }

        #region Methods for adding fields in system tables
        public void AddRole(RoleDTO role)
        {
            RoleCRUD crud = new RoleCRUD();
            crud.Add(role);
        }
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

        //public void AddUser(UserDTO userDTO, UserRoleDTO roleDTO)
        //{
        //    UserCRUD user = new UserCRUD();
        //    UserRoleCRUD role = new UserRoleCRUD();
        //    user.Add(userDTO);
        //    role.UpdateByID(roleDTO);
        //}
    }
}