using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace DevEduInterviewSystem.DAL.DTO
{
    public class UserDTO : IDTO
    {
        public int? ID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool? IsDeleted { get; set; }
        public UserDTO()
        {
        }
        public UserDTO(int? ID, string login, string password, string firstName, string lastName, bool? isDeleted = false)
        {
            this.ID = ID;
            this.Login = login;
            this.Password = password;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.IsDeleted = isDeleted;
        }
    }
}
