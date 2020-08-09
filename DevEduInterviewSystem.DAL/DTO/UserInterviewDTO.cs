﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.DTO
{
   public  class UserInterviewDTO
   {

        public int ID { get; set; }
        public int InterviewID { get; set; }
        public int UserID { get; set; }

        public UserInterviewDTO()
        {

        }

        public UserInterviewDTO(int ID, int InterviewID, int UserID)
        {
            this.ID = ID;
            this.InterviewID = InterviewID;
            this.UserID = UserID;
        }
    }
}