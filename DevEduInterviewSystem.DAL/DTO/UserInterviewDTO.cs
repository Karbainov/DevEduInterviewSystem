using System;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.DTO
{
   public  class UserInterviewDTO : IDTO
   {

        public int? ID { get; set; }
        public int? InterviewID { get; set; }
        public int? UserID { get; set; }

        public UserInterviewDTO()
        {

        }

        public UserInterviewDTO(int? ID, int? interviewID, int? userID)
        {
            this.ID = ID;
            this.InterviewID = interviewID;
            this.UserID = userID;
        }
    }
}
