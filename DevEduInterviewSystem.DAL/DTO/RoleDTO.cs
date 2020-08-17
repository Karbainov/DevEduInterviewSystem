using System;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.DTO
{
    public class RoleDTO: IDTO
    {
        public int ID { get; set; }
        public string TypeOfRole { get; set; }

        public RoleDTO()
        {
        }
        public RoleDTO(int ID, string TypeOfRole)
        {
            this.ID = ID;
            this.TypeOfRole = TypeOfRole;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;

            RoleDTO dto = (RoleDTO)obj;
            return (this.TypeOfRole == dto.TypeOfRole);
        }
    }
}
