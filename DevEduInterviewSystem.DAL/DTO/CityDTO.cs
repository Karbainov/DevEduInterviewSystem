using System;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.DTO
{
    public class CityDTO:IDTO
    {
        public int ID { get; set; }
        public string CityName { get; set; }
        public CityDTO() { }
        public CityDTO(int id, string name) 
        {
            ID = id;
            CityName = name;
        }
    }
    

}
