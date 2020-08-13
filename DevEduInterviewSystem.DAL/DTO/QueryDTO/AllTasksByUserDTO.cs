using System;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.DTO.QueryDTO
{
    public class AllTasksByUserDTO
    {
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public int? CandidateID { get; set; }
        public string CandidateFirstName { get; set; }
        public string CandidateLastName { get; set; }
        public string Task { get; set; }
        public bool? IsCompleted { get; set; }
        public string Stage { get; set; }

        public AllTasksByUserDTO() { }

        public AllTasksByUserDTO(string userFirstName, string userLastName, int candidateID, string candidateFirstName,
            string candidateLastName, string task, bool isCompleted, string stage)
        {
            UserFirstName = userFirstName;
            UserLastName = userLastName;
            CandidateID = candidateID;
            CandidateFirstName = candidateFirstName;
            CandidateLastName = candidateLastName;
            Task = task;
            IsCompleted = isCompleted;
            Stage = stage;
        }
    }
}
