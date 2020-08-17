using System;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.DTO.QuereDTO
{
    public class UsersWithRoleDTO
    {
        public int ID { get; set; }
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public List<RoleDTO> Roles { get; set; }

        public UsersWithRoleDTO()
        {

        }
        

    }
}
