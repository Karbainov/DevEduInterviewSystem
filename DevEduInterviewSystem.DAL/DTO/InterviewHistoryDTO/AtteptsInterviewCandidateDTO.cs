using System;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.DTO.InterviewHistoryDTO
{
    public class AtteptsInterviewCandidateDTO : IDTO
    {
        public string CandidateFirstName { get; set; }
        public string CandidateLastName { get; set; }
        public int AttemptInterview { get; set; }

        public AtteptsInterviewCandidateDTO()
        {

        }

        public AtteptsInterviewCandidateDTO(string firstName, string lastName, int attempt)
        {
            CandidateFirstName = firstName;
            CandidateLastName = lastName;
            AttemptInterview = attempt;
        }
    }
}
