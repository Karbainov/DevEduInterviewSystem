using System;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.DTO
{
    public class CityDTO:IDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public CityDTO() { }
        public CityDTO(int ID, string Name) 
        {
            this.ID = ID;
            this.Name = Name;
        }
    }
    

}
