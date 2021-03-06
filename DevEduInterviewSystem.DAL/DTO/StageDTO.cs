﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.DTO
{
    public class StageDTO : IDTO
    {
        public int? ID { get; set; }
        public string Name { get; set; }

        public StageDTO()
        {

        }

        public StageDTO(int ID, string name)
        {
            this.ID = ID;
            this.Name = name;
        }
    }
}
