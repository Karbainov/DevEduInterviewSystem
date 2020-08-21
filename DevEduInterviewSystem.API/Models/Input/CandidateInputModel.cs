using DevEduInterviewSystem.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevEduInterviewSystem.API.Models.Input
{
    public class CandidateInputModel
    {
        public CandidateDTO CandidateDTO { get; set; }
        public CandidatePersonalInfoDTO CandidatePersonalInfoDTO { get; set; }
        public int? CourseID { get; set; }      
        public InterviewDTO interviewDTO { get; set; }      
        public FeedbackDTO feedbackDTO { get; set; }
    }
}
