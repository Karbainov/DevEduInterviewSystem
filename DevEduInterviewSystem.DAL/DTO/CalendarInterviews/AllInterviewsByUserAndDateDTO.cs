using System;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.DTO.CalendarInterviews
{
    public class AllInterviewsByUserAndDateDTO:IDTO
    {
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public int IDCandidate { get; set; }
        public string CandidateFirstName { get; set; }
        public string CandidateLastName { get; set; }
        public string CandidatePhone { get; set; }
        public DateTime DateTimeInterview { get; set; }
        public int Attempt { get; set; }
        public string InterviewStatus { get; set; }

        public AllInterviewsByUserAndDateDTO()
        {

        }
        public AllInterviewsByUserAndDateDTO(string userFirstName, string userLastName, int idCandidate, string candidateFirstName,
            string candidateLastName, string candidatePhone, DateTime dateTimeInterview, int attempt, string interviewStatus)
        {
            UserFirstName = userFirstName;
            UserLastName = userLastName;
            DateTimeInterview = dateTimeInterview;
            IDCandidate = idCandidate;
            CandidateFirstName = candidateFirstName;
            CandidateLastName = candidateLastName;
            CandidatePhone = candidatePhone;
            Attempt = attempt;
            InterviewStatus = interviewStatus;
        }
    }
}
