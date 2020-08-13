using System;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.DTO.QueryDTO
{
    public class OneUserRoleDTO : IDTO
    {
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public OneUserRoleDTO() {}

        public OneUserRoleDTO(string login, string firstName, string lastName, string password, string role)
        {
            Login = login;
            FirstName = firstName;
            LastName = lastName;
            Password = password;
            Role = role;
        }
    }
}
