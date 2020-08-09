using System;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.DTO
{
   public class StageChangedDTO
    {
        public int ID { get; set; }
        public int StageID { get; set; }
        public int CandidateID { get; set; }
        public DateTime ChangedDate { get; set; }

        public StageChangedDTO()
        {

        }

        public StageChangedDTO(int ID, int StageID, int CandidateID, DateTime ChangedDate)
        {
            this.ID = ID;
            this.StageID = StageID;
            this.CandidateID = CandidateID;
            this.ChangedDate = ChangedDate;
        }
    }
}
