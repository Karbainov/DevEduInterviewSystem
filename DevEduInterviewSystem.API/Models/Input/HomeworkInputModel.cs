using DevEduInterviewSystem.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevEduInterviewSystem.API.Models.Input
{
    public class HomeworkInputModel
    {
        public CandidateDTO CandidateDTO { get; set; }
        public FeedbackDTO FeedbackDTO { get; set; }
        public int? HomeworkStatusID { get; set; }
        public int? TestStatusID { get; set; }
        public int? CourseID { get; set; }
    }
}
