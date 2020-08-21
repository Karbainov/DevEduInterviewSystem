using System;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.DTO
{
    public class HomeworkStatusDTO : IDTO
    {
        public int? ID { get; set; }
        public string Name { get; set; }

        public HomeworkStatusDTO()
        {

        }

        public HomeworkStatusDTO(int ID, string Name)
        {
            this.ID = ID;
            this.Name = Name;
        }
    }
}

