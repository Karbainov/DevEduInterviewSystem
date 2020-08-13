using System;

namespace DevEduInterviewSystem.DAL.DTO
{
    public class InterviewDTO : IDTO
    {
        public int ID { get; set; }
        public int? CandidateID { get; set; }
        public int? InterviewStatusID { get; set; }
        public int? Attempt { get; set; }
        public DateTime DateTimeInterview { get; set; }

        public InterviewDTO()
        {

        }

        public InterviewDTO(int ID, int CandidateID, int InterviewStatusID, int Attempt, DateTime DateTimeInterview)
        {
            this.ID = ID;
            this.CandidateID = CandidateID;
            this.InterviewStatusID = InterviewStatusID;
            this.Attempt = Attempt;
            this.DateTimeInterview = DateTimeInterview;

        }
    }
}

