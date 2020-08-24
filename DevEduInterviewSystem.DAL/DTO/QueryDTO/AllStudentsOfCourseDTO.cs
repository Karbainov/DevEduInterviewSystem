using System;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.DTO.QuereDTO
{
    public class AllStudentsOfCourseDTO : IDTO
    {
        public string Name { get; set; }
        public string StudentFirstName { get; set; }
        public string StudentLastName { get; set; }

        public AllStudentsOfCourseDTO()
        {

        }

        public AllStudentsOfCourseDTO(string name, string firstName, string lastName)
        {
            Name = name;
            StudentFirstName = firstName;
            StudentLastName = lastName;
        }
    }
}
