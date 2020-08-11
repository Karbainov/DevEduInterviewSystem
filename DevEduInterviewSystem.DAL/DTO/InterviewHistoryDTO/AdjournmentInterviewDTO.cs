using System;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.DTO.InterviewHistoryDTO
{
   public  class AdjournmentInterviewDTO : IDTO
    {
        public int CandidateID { get; set; }
        public string CandidateFirstName { get; set; }
        public string CandidateLastName { get; set; }
        public int Adjournment { get; set; }

        public AdjournmentInterviewDTO()
        {

        }

        public AdjournmentInterviewDTO(int candidateID, string firstName, string lastName, int adjournment)
        {
            CandidateID = candidateID;
            CandidateFirstName = firstName;
            CandidateLastName = lastName;
            Adjournment = adjournment;
        }
    }
}
