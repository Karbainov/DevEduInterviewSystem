using DevEduInterviewSystem.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevEduInterviewSystem.API.Models.Input
{
    public class UpdateCandidateAfterInterviewModel // Можно ли недостающие свойства добавить в кандидатМодель?????
    {
        public CandidateDTO CandidateDTO { get; set; }
        public InterviewDTO interviewDTO { get; set; }
        public int? CourseID { get; set; }
        public FeedbackDTO feedbackDTO { get; set; }
    }
    
}