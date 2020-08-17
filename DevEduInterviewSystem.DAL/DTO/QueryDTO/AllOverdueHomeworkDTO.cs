using System;

namespace DevEduInterviewSystem.DAL.DTO.QuereDTO
{
    public class AllOverdueHomeworkDTO : IDTO
    {
        public int CandidateID { get; set; }
        public DateTime HomeWorkDate { get; set; }
        public string CandidateFirstName { get; set; }
        public string CandidateLastName { get; set; }
        public string HomeWorkStatus { get; set; }
        public string TestStatus { get; set; }

        public AllOverdueHomeworkDTO()
        {

        }

        public AllOverdueHomeworkDTO(int candidateID, DateTime homeWorkDate, string candidateFirstName, string candidateLastName,
            string homeWorkStatus, string testStatus)
        {
            CandidateID = candidateID;
            HomeWorkDate = homeWorkDate;
            CandidateFirstName = candidateFirstName;
            CandidateLastName = candidateLastName;
            HomeWorkStatus = homeWorkStatus;
            TestStatus = testStatus;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;

            AllOverdueHomeworkDTO dto = (AllOverdueHomeworkDTO)obj;
            return (this.CandidateID == dto.CandidateID
                && this.CandidateFirstName == dto.CandidateFirstName
                && this.CandidateLastName == dto.CandidateLastName
                && this.HomeWorkStatus == dto.HomeWorkStatus
                && this.TestStatus == dto.TestStatus
                && this.HomeWorkDate.ToShortDateString() == dto.HomeWorkDate.ToShortDateString());
        }
    }
}
