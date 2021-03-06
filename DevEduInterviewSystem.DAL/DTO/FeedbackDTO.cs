﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.DTO
{
    public class FeedbackDTO : IDTO
    {
        public int? ID { get; set; }
        public int? StageChangedID { get; set; }
        public int? UserID { get; set; }
        public string Message { get; set; }
        public DateTime? TimeFeedback { get; set; }

        public FeedbackDTO()
        {

        }

        public FeedbackDTO(int ID, int stageChangedID, int userID, string message, DateTime timeFeedback)
        {
            this.ID = ID;
            this.StageChangedID = stageChangedID;
            this.UserID = userID;
            this.Message = message;
            this.TimeFeedback = timeFeedback;
        }

        public FeedbackDTO( int stageChangedID, int userID, string message, DateTime timeFeedback)
        {
           
            this.StageChangedID = stageChangedID;
            this.UserID = userID;
            this.Message = message;
            this.TimeFeedback = timeFeedback;
        }
        public override bool Equals(object obj)
        {

            if (obj.GetType() != GetType()) return false;

            var tmp = (FeedbackDTO)obj;
            if (tmp.ID == ID &&
                tmp.StageChangedID == StageChangedID &&
                tmp.UserID == UserID &&
                tmp.Message == Message &&
                tmp.TimeFeedback == TimeFeedback)
                
            {
                return true;
            }
            return false;
        }
    }
}

