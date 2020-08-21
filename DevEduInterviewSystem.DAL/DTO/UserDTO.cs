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
        public UserDTO(int? ID, string Login, string Password, string FirstName, string LastName, bool? isDeleted = false)
        {
            this.ID = ID;
            this.Login = Login;
            this.Password = Password;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.IsDeleted = isDeleted;
        }
    }
}
