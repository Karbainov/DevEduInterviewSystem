using DevEduInterviewSystem.DAL.DTO.QueryDTO.CandidateSelectionProcessInfoDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.DTO.QuereDTO.StudentsOfCourse
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
        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;

            AllStudentsOfCourseDTO dto = (AllStudentsOfCourseDTO)obj;
            return (Name == dto.Name
                && this.StudentFirstName == dto.StudentFirstName
                && this.StudentLastName == dto.StudentLastName);

        }
    }
}
