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
        public string Password { get; set; }
        public string Role { get; set; }

        public UsersAndRoleDTO()
        {

        }

        public UsersAndRoleDTO(string login, string name, string lastName,string password, string role)
        {
            Login = login;
            FirstName = name;
            LastName = lastName;
            Password = password;
            Role = role;
        }
    }
}
