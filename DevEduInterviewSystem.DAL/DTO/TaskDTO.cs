using System;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.DTO
{
   public class TaskDTO : IDTO
    {
        public int ID { get; set; }
        public int? UserID { get; set; }
        public int? CandidateID { get; set; }
        public string Message { get; set; }
        public string IsCompleted { get; set; }
       
        public TaskDTO()
        {

        }

        public TaskDTO(int ID, int? UserID, int? CandidateID, string Message, string IsCompleted)
        {
            this.ID = ID;
            this.UserID = UserID;
            this.CandidateID = CandidateID;
            this.Message = Message;
            this.IsCompleted = IsCompleted;

        }

        public TaskDTO(int ID, int? UserID, int? CandidateID)
        {
            this.ID = ID;
            this.UserID = UserID;
            this.CandidateID = CandidateID;
        }

    }
   
}
