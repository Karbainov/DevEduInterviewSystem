using DevEduInterviewSystem.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevEduInterviewSystem.API.Models.Input
{
    public class FeedbackInputModel
    {
        public FeedbackDTO feedbackDTO { get; set; }
        public StageChangedDTO stageChangedDTO { get; set; }
        public UserDTO userDTO { get; set; }
      
    }
}
