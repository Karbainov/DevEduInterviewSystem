using Microsoft.AspNetCore.Authorization.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevEduInterviewSystem.API.Token
{
    public class Person
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public List<string> Roles { get; set; }

        public Person(string login, string password, List<string> roles)
        {
            Login = login;
            Password = password;
            Roles = roles;
        }
    }
}
