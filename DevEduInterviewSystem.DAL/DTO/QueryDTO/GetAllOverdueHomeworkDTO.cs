using System;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.DTO.QuereDTO
{
    public class GetAllOverdueHomeworkDTO:IDTO
    {
        public int CandidateID { get; set; }
        public string CandidateFirstName { get; set; }
        public string CandidateLastName { get; set; }
        public string StatusHomeWork { get; set; }
        public DateTime HomeWorkDate { get; set; }

        public GetAllOverdueHomeworkDTO()
        {

        }

        public GetAllOverdueHomeworkDTO(int candidateID, string candidateFirstName, string candidateLastName, string statusHomeWork, DateTime homeWorkDate)
        {
            CandidateID = candidateID;
            CandidateFirstName = candidateFirstName;
            CandidateLastName = candidateLastName;
            StatusHomeWork = statusHomeWork;
            HomeWorkDate = homeWorkDate;

        }
    }
}
