using System;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.DTO.QuereDTO
{
    public class AllStudentsOfCourseDTO : IDTO
    {
        public string Name { get; set; }

        public AllStudentsOfCourseDTO()
        {

        }

        public AllStudentsOfCourseDTO(string name)
        {
            Name = name;
        }
    }
}
