using System;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.DTO
{
    public class CourseDTO : IDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public CourseDTO() { }
        public CourseDTO(int id, string name)
        {
            ID = id;
            Name = name;
        }
        public CourseDTO(string name)
        {
            Name = name;
        }
    }
}
