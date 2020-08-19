using System;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.DTO.QueryDTO
{
    public class OneUserRolesDTO : IDTO
    {
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<RoleDTO> Roles { get; set; }

        public OneUserRolesDTO() {}

        public OneUserRolesDTO(string login, string userFirstName, string userLastName, List<RoleDTO> roles)
        {
            Login = login;
            FirstName = userFirstName;
            LastName = userLastName;
            Roles = roles;
        }
        public override bool Equals(object obj)
        {
            var tmp = (OneUserRolesDTO)obj;
            if (tmp.Login == Login &&
                tmp.FirstName == FirstName &&
                tmp.LastName == LastName &&
                tmp.Roles == Roles)
            {
                return true;
            }
            return false;
        }

    }
}
