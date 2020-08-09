using System;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.DTO
{
    public class GroupCandidateDTO
    {
        public int ID { get; set; }
        public int GroupID { get; set; }
        public int CandidateID { get; set; }

        public GroupCandidateDTO()
        {

        }

        public GroupCandidateDTO(int ID, int GroupID, int CandidateID)
        {
            this.ID = ID;
            this.GroupID = GroupID;
            this.CandidateID = CandidateID;
        }
    }
}
