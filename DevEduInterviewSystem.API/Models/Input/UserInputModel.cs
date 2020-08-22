using DevEduInterviewSystem.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevEduInterviewSystem.API.Models.Input
{
    public class UserInputModel
    {
        public UserDTO UserDTO { get; set; }
        public int? RoleID { get; set; }

    }
}
