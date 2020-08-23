using System;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.DTO
{
    public class CityDTO:IDTO
    {
        public int? ID { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public CityDTO() { }
        public CityDTO(string City)
        {
            this.Name = City;
        }
        public CityDTO(int id, string City)
        {
            this.ID = id;
            this.Name = City;
        }
        public CityDTO(int id, string city, bool isDeleted) 
        {
            this.ID = id;
            this.Name = city;
            this.IsDeleted = isDeleted;
        }
    }
    

}
