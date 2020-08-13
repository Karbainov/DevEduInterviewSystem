using System;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.DTO.CalendarInterviews
{
    public class AllInterviewsByUserDTO
    {
        public int UserID { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public int? IDCandidate { get; set; }
        public string CandidateFirstName { get; set; }
        public string CandidateLastName { get; set; }
        public string CandidatePhone { get; set; }
        public DateTime DateTimeInterview { get; set; }
        public int? Attempt { get; set; }
        public string InterviewStatus { get; set; }

        public AllInterviewsByUserDTO()
        {

        }
        public AllInterviewsByUserDTO(int userID, string userFirstName, string userLastName, int idCandidate, string candidateFirstName, 
            string candidateLastName, string candidatePhone, DateTime dateTimeInterview, int attempt, string interviewStatus)
        {
            UserID = userID;
            UserFirstName = userFirstName;
            UserLastName = userLastName;
            IDCandidate = idCandidate;
            CandidateFirstName = candidateFirstName;
            CandidateLastName = candidateLastName;
            CandidatePhone = candidatePhone;
            DateTimeInterview = dateTimeInterview;
            Attempt = attempt;
            InterviewStatus = interviewStatus;

        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;

            AllInterviewsByUserDTO dto = (AllInterviewsByUserDTO)obj;
            return (this.UserFirstName == dto.UserFirstName && this.UserLastName == dto.UserLastName
                && this.CandidateFirstName == dto.CandidateFirstName && this.CandidateLastName == dto.CandidateLastName
                && this.CandidatePhone == dto.CandidatePhone && this.Attempt == dto.Attempt && this.InterviewStatus == dto.InterviewStatus
                && this.DateTimeInterview.ToShortTimeString() == dto.DateTimeInterview.ToShortTimeString()
                && this.DateTimeInterview.ToShortDateString() == dto.DateTimeInterview.ToShortDateString());
        }
    }
}
