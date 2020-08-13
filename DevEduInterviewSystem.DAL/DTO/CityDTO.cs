using System;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.DTO
{
    public class CityDTO:IDTO
    {
        public int ID { get; set; }
        public string City { get; set; }
        public CityDTO() { }
        public CityDTO(string City)
        {
            this.City = City;
        }
        public CityDTO(int ID, string City) 
        {
            this.ID = ID;
            this.City = City;
        }
    }
    

}
