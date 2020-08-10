using System;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.DTO
{
    public class FeedbackDTO
    {
        public int ID { get; set; }
        public int StageChangedID { get; set; }
        public int UserID { get; set; }
        public string Message { get; set; }
        public DateTime TimeFeedback { get; set; }

        public FeedbackDTO()
        {

        }

        public FeedbackDTO(int ID, int StageChangedID, int UserID, string Message, DateTime TimeFeedback)
        {
            this.ID = ID;
            this.StageChangedID = StageChangedID;
            this.UserID = UserID;
            this.Message = Message;
            this.TimeFeedback = TimeFeedback;
        }

    }
}

