﻿using DevEduInterviewSystem.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevEduInterviewSystem.API.Models.Input
{
    public class UpdateCourseByCandidateModel
    {
        public int? CourseID { get; set; }
        public int? CandidateID { get; set; }
    }
}
