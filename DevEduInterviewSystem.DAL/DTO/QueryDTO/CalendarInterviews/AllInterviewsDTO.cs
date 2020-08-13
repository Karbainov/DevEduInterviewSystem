using System;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.DTO.CalendarInterviews
{
    public class AllInterviewsDTO : IDTO
    {
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserLogin { get; set; }
        public int CandidateID { get; set; }
        public string CandidateFirstName { get; set; }
        public string CandidateLastName { get; set; }
        public string CandidatePhone { get; set; }
        public DateTime DateTimeInterview { get; set; }
        public int Attempt { get; set; }
        public string InterviewStatus { get; set; }

        public AllInterviewsDTO()
        {

        }
        public AllInterviewsDTO(string userFirstName, string userLastName, string login, int candidateID, string candidateFirstName,
            string candidateLastName, string candidatePhone, DateTime dateTimeInterview, int attempt, string interviewStatus)
        {
            UserFirstName = userFirstName;
            UserLastName = userLastName;
            UserLogin = login;
            CandidateID = candidateID;
            CandidateFirstName = candidateFirstName;
            CandidateLastName = candidateLastName;
            CandidatePhone = candidatePhone;
            DateTimeInterview = dateTimeInterview;
            Attempt = attempt;
            InterviewStatus = interviewStatus;
        }
    }
}


