using System;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.DTO.QueryDTO.CandidateSelectionProcessInfoDTO
{
    public class AllSelectionProcessDTO : IDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Status { get; set; }
        public string Stage { get; set; }
        public string Course { get; set; }


        public AllSelectionProcessDTO()
        {

        }

        public AllSelectionProcessDTO(int idCandidate, string candidateFirstName, string candidateLastName,
                                                   string status, string stage, string course)
        {
            FirstName = candidateFirstName;
            LastName = candidateLastName;
            Status = status;
            Stage = stage;
            Course = course;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;

            AllSelectionProcessDTO dto = (AllSelectionProcessDTO)obj;
            return (this.FirstName == dto.FirstName
                && this.LastName == dto.LastName
                && this.Status == dto.Status
                && this.Stage == dto.Stage
                && this.Course == dto.Course);         
        }

    }
}
