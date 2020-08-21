using System;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.DTO
{
    public class OneTimePasswordDTO : IDTO
    {
        public int? ID { get; set; }
        public int? CandidateID { get; set; }
        public DateTime? DateOfPasswordIssue { get; set; }
        public string OneTimePassword { get; set; }

        public OneTimePasswordDTO() {}

        public OneTimePasswordDTO(int id, int? candidateID, DateTime? dateOfPasswordIssue, string oneTimePassword)
        {
            this.ID = id;
            this.CandidateID = candidateID;
            this.DateOfPasswordIssue = dateOfPasswordIssue;
            this.OneTimePassword = oneTimePassword;
        }
    }
}
