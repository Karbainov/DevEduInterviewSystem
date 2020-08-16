using System;
using System.Collections.Generic;
using System.Text;
using DevEduInterviewSystem.DAL.DTO;
using DevEduInterviewSystem.DAL.StoredProcedures.CRUD;


namespace DevEduInterviewSystem.BLL
{
    public class ManagerRoleLogic : IRoleLogic
    {
        public void InsertCity(CityDTO city, CityCRUD crud)
        {
            throw new AccessDeniedException("Not enough rights");
        }
    }
}
