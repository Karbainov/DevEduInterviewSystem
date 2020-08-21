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
        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;

            AllStudentsOfGroupByStartDTO dto = (AllStudentsOfGroupByStartDTO)obj;
            return (Name == dto.Name
                && this.StudentFirstName == dto.StudentFirstName
                && this.StudentLastName == dto.StudentLastName
                && this.StartDate.ToShortTimeString() == dto.StartDate.ToShortTimeString());
        }
    }
}
