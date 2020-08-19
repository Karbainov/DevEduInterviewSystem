using System;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.DTO
{
    public class StatusDTO : IDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public StatusDTO()
        {
        }
        public StatusDTO(int ID)
        {
            this.ID = ID;
           
        }

        public StatusDTO(int ID, string Name)
        {
            this.ID = ID;
            this.Name = Name;
        }
    }
}
