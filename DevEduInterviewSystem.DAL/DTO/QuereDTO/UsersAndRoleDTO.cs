using System;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.DTO.QuereDTO
{
    public class UsersAndRoleDTO
    {
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }

        public UsersAndRoleDTO()
        {

        }

        public UsersAndRoleDTO(string login, string name, string lastName, string role)
        {
            Login = login;
            FirstName = name;
            LastName = lastName;
            Role = role;
        }
    }
}
