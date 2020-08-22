using System;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.DTO.QuereDTO
{
    public class UserWithRoleDTO
    {
        public int? ID { get; set; }
        public int? UserID { get; set; }
        public List<string> Roles { get; set; }

        public UserWithRoleDTO()
        {

        }


    }
}
