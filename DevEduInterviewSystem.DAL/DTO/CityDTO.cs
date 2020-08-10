using System;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.DTO
{
    public class CityDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public CityDTO() { }
        public CityDTO(string Name)
        {
            this.Name = Name;
        }
        public CityDTO(int ID, string Name) 
        {
            this.ID = ID;
            this.Name = Name;
        }
    }
    

}
