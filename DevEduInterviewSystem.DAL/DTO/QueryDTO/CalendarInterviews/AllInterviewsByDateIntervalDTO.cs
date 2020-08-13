using System;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.DTO.QueryDTO.CalendarInterviews
{
    public class AllInterviewsByDateIntervalDTO : IDTO
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
        public string Status { get; set; }

        public AllInterviewsByDateIntervalDTO()
        {

        }
        public AllInterviewsByDateIntervalDTO(string userFirstName, string userLastName, string login, int idCandidate, string candidateFirstName,
            string candidateLastName, string candidatePhone, DateTime dateTimeInterview, int attempt, string status)
        {
            UserFirstName = userFirstName;
            UserLastName = userLastName;
            UserLogin = login;
            CandidateID = idCandidate;
            CandidateFirstName = candidateFirstName;
            CandidateLastName = candidateLastName;
            CandidatePhone = candidatePhone;
            DateTimeInterview = dateTimeInterview;
            Attempt = attempt;
            Status = status;
        }
    }
}
