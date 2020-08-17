using DevEduInterviewSystem.DAL.DTO;
using DevEduInterviewSystem.DAL.StoredProcedures.CRUD;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.BLL
{
    public interface IRoleLogic
    {
        public void InsertCity(CityDTO city, CityCRUD crud);

    }

}
