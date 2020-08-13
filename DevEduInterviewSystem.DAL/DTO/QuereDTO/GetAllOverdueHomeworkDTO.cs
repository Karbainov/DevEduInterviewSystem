using System;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.DTO.QuereDTO
{
    public class GetAllOverdueHomeworkDTO:IDTO
    {
        public string CandidateFirstName { get; set; }
        public string CandidateLastName { get; set; }
        public string StatusHomeWork { get; set; }
        public DateTime HomeWorkDate { get; set; }

        public GetAllOverdueHomeworkDTO()
        {

        }

        public GetAllOverdueHomeworkDTO(string candidateFirstName, string candidateLastName, string statusHomeWork, DateTime homeWorkDate)
        {
            CandidateFirstName = candidateFirstName;
            CandidateLastName = candidateLastName;
            StatusHomeWork = statusHomeWork;
            HomeWorkDate = homeWorkDate;

        }
    }
}
