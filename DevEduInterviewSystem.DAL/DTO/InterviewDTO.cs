using System;

namespace DevEduInterviewSystem.DAL.DTO
{
    public class InterviewDTO : IDTO
    {
        public int? ID { get; set; }
        public int? CandidateID { get; set; }
        public int? InterviewStatusID { get; set; }
        public int? Attempt { get; set; }
        public DateTime? DateTimeInterview { get; set; }

        public InterviewDTO()
        {

        }

        public InterviewDTO(int ID, int? candidateID, int? interviewStatusID, int? attempt, DateTime dateTimeInterview)
        {
            this.ID = ID;
            this.CandidateID = candidateID;
            this.InterviewStatusID = interviewStatusID;
            this.Attempt = attempt;
            this.DateTimeInterview = dateTimeInterview;

        }
        public InterviewDTO(int? candidateID, int? interviewStatusID, DateTime dateTimeInterview)
        {            
            this.CandidateID = candidateID;
            this.InterviewStatusID = interviewStatusID;            
            this.DateTimeInterview = dateTimeInterview;

        }
    }
}

