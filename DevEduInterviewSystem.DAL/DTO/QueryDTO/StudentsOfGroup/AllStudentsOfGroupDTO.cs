using System;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.DTO.QuereDTO.StudentsOfGroup
{
    public class AllStudentsOfGroupDTO : IDTO
    {
        public string Name {get;set;}
        public string StudentFirstName { get; set; }
        public string StudentLastName { get; set; }

        public AllStudentsOfGroupDTO()
        {

        }

        public AllStudentsOfGroupDTO(string name, string firstName, string lastName)
        {
            Name = name;
            StudentFirstName = firstName;
            StudentLastName = lastName;
            
        }
    }
}
