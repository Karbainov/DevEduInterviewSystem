﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.DTO.CalendarInterviews
{
    public class AllInterviewsByUserDTO: IDTO 
    {
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public int CandidateID { get; set; }
        public string CandidateFirstName { get; set; }
        public string CandidateLastName { get; set; }
        public string CandidatePhone { get; set; }
        public DateTime DateTimeInterview { get; set; }
        public int Attempt { get; set; }
        public string InterviewStatus { get; set; }

        public AllInterviewsByUserDTO()
        {

        }
        public AllInterviewsByUserDTO(string userFirstName, string userLastName, int candidateID, string candidateFirstName, 
            string candidateLastName, string candidatePhone, DateTime dateTimeInterview, int attempt, string interviewStatus)
        {
            UserFirstName = userFirstName;
            UserLastName = userLastName;
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
