using System;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.DTO
{
   public class TaskDTO : IDTO
    {
        public int? ID { get; set; }
        public int? UserID { get; set; }
        public int? CandidateID { get; set; }
        public string Message { get; set; }
        public bool? IsCompleted { get; set; }
       
        public TaskDTO()
        {

        }

        public TaskDTO(int? ID, int? userID, int? candidateID, string message, bool? isCompleted)
        {
            this.ID = ID;
            this.UserID = userID;
            this.CandidateID = candidateID;
            this.Message = message;
            this.IsCompleted = isCompleted;

        }

        public TaskDTO(int? ID, int? userID, int? candidateID)
        {
            this.ID = ID;
            this.UserID = userID;
            this.CandidateID = candidateID;
        }

    }
   
}
