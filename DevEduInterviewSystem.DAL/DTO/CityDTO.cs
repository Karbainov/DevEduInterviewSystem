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
        public CityDTO(string City, bool isDeleted = false)
        {
            this.Name = City;
            this.IsDeleted = isDeleted;
        }
        public CityDTO(int id, string city, bool isDeleted=false) 
        {
            this.ID = id;
            this.Name = city;
            this.IsDeleted = isDeleted;
        }
    }
    

}
