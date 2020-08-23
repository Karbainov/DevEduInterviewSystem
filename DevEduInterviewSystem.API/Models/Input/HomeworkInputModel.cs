using DevEduInterviewSystem.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevEduInterviewSystem.API.Models.Input
{
    public class HomeworkInputModel
    {
        public HomeworkDTO HomeworkDTO { get; set; }
        public FeedbackDTO FeedbackDTO { get; set; }
    }
}
