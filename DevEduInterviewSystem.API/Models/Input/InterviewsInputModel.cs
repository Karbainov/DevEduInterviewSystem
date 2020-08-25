using DevEduInterviewSystem.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevEduInterviewSystem.API.Models.Input
{
    public class InterviewsInputModel
    {
        public InterviewDTO InterviewDTO  { get; set;}
        public int? UserID { get; set; }

    }
}
