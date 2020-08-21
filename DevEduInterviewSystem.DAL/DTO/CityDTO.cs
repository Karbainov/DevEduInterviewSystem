using System;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.DTO
{
    public class CityDTO:IDTO
    {
        public int? ID { get; set; }
        public string Name { get; set; }
        public CityDTO() { }
        public CityDTO(string City)
        {
            this.Name = City;
        }
        public CityDTO(int ID, string City) 
        {
            this.ID = ID;
            this.Name = City;
        }
    }
    

}
