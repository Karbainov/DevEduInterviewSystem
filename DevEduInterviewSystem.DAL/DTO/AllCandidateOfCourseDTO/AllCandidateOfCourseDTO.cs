using System;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.DTO.QuereDTO
{
    public class AllCandidateOfCourseDTO : IDTO
    {
        public string Name { get; set; }

        public AllCandidateOfCourseDTO()
        {

        }

        public AllCandidateOfCourseDTO(string name)
        {
            Name = name;
        }
    }
}
