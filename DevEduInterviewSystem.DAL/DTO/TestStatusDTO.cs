using System;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.DTO
{
    public class TestStatusDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public TestStatusDTO()
        {
        }

        public TestStatusDTO(int ID, string Name)
        {
            this.ID = ID;
            this.Name = Name;
        }
    }
}
