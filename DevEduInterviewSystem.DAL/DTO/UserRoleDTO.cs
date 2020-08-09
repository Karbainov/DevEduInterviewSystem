﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.DTO
{
    public class UserRoleDTO
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int RoleID { get; set; }

        public UserRoleDTO()
        {
        }
        public UserRoleDTO (int ID, int UserID, int RoleID)
        {
            this.ID = ID;
            this.UserID = UserID;
            this.RoleID = RoleID;
        }
    }
}