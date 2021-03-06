﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.DTO
{
    public class CourseDTO : IDTO
    {
        public int? ID { get; set; }
        public string Name { get; set; }

        public CourseDTO() { }
        public CourseDTO(string name)
        {
            this.Name = name;
        }
        public CourseDTO(int ID, string name)
        {
            this.ID = ID;
            this.Name = name;
        }
    }
}
