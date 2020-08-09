﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.DTO
{
    public class RoleDTO
    {
        public int ID { get; set; }
        public string TypeOfRole { get; set; }

        public RoleDTO()
        {
        }
        public RoleDTO(int ID, string TypeOfRole)
        {
            this.ID = ID;
            this.TypeOfRole = TypeOfRole;
        }
    }
}
