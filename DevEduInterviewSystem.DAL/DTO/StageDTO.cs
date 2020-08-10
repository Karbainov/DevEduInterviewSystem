using System;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.DTO
{
    public class StageDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public StageDTO()
        {

        }

        public StageDTO(int ID, string Name )
        {
            this.ID = ID;
            this.Name = Name;
        }
    }
}
