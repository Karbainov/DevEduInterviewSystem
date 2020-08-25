using System;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.DTO
{
    public class GroupCandidateDTO : IDTO
    {
        public int? ID { get; set; }
        public int? GroupID { get; set; }
        public int? CandidateID { get; set; }

        public GroupCandidateDTO()
        {

        }

        public GroupCandidateDTO(int ID, int groupID, int candidateID)
        {
            this.ID = ID;
            this.GroupID = groupID;
            this.CandidateID = candidateID;
        }
    }
}
