using System;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.DTO
{
    public class TaskDTO : IDTO
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int CandidateID { get; set; }
        public string Message { get; set; }
        public string IsCompleted { get; set; }

        public TaskDTO()
        {

        }

        public TaskDTO(int id, int userID, int candidateID, string message, string isCompleted)
        {
            ID = id;
            UserID = userID;
            CandidateID = candidateID;
            Message = message;
            IsCompleted = isCompleted;

        }

    }

}
