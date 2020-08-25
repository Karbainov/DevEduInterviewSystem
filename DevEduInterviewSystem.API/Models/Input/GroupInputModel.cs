using DevEduInterviewSystem.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevEduInterviewSystem.API.Models.Input
{
    public class GroupInputModel
    {
        public int CandidateID { get; set; }
        public int StageID { get; set; }
        public int CourseID { get; set; }
        public int GroupID { get; set; }
        public FeedbackDTO feedbackDTO { get; set; }

    }
}
