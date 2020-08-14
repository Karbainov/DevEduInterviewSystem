using System;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.DTO.QuereDTO.StudentsOfGroup
{
    public class AllStudentsOfGroupByStartDTO : IDTO
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public string StudentFirstName { get; set; }
        public string StudentLastName { get; set; }

        public AllStudentsOfGroupByStartDTO()
        {

        }

        public AllStudentsOfGroupByStartDTO(string name, DateTime startDate, string firstName, string lastName)
        {
            Name = name;
            StartDate = startDate;
            StudentFirstName = firstName;
            StudentLastName = lastName;
        }
    }
}
