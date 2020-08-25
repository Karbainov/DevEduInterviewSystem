using System;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.DTO
{
    public class UserRoleDTO : IDTO
    {
        public int? ID { get; set; }
        public int? UserID { get; set; }
        public int? RoleID { get; set; }

        public UserRoleDTO()
        {
        }
        public UserRoleDTO (int? ID, int? userID, int? roleID)
        {
            this.ID = ID;
            this.UserID = userID;
            this.RoleID = roleID;
        }
        public UserRoleDTO(int? userID, int? roleID)
        {
            this.UserID = userID;
            this.RoleID = roleID;
        }
    }
}
