using System;

namespace DevEduInterviewSystem.DAL.DTO.QuereDTO
{
    public class AllOverdueTestsDTO : IDTO
    {
        public int CandidateID { get; set; }
        public DateTime HomeWorkDate { get; set; }
        public string CandidateFirstName { get; set; }
        public string CandidateLastName { get; set; }
        public string TestStatus { get; set; }

        public AllOverdueTestsDTO()
        {

        }

        public AllOverdueTestsDTO(int candidateID, DateTime homeWorkDate, string candidateFirstName,
            string candidateLastName, string testStatus)
        {
            CandidateID = candidateID;
            HomeWorkDate = homeWorkDate;
            CandidateFirstName = candidateFirstName;
            CandidateLastName = candidateLastName;
            TestStatus = testStatus;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;

            AllOverdueTestsDTO dto = (AllOverdueTestsDTO)obj;
            return (this.CandidateID == dto.CandidateID
                && this.CandidateFirstName == dto.CandidateFirstName
                && this.CandidateLastName == dto.CandidateLastName
                && this.TestStatus == dto.TestStatus
                && this.HomeWorkDate.ToShortDateString() == dto.HomeWorkDate.ToShortDateString());
        }
    }
}