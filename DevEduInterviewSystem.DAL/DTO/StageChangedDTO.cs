using Dapper;
using DevEduInterviewSystem.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace DevEduInterviewSystem.DAL.DTO
{
    public class StageChangedDTO : IDTO
    {
        public int? ID { get; set; }
        public int? StageID { get; set; }
        public int? CandidateID { get; set; }
        public DateTime? ChangedDate { get; set; }

        public StageChangedDTO()
        {

        }

        public StageChangedDTO(int id, int? stageID, int? candidateID, DateTime? changedDate)
        {
            ID = id;
            StageID = stageID;
            CandidateID = candidateID;
            ChangedDate = changedDate;
        }

        public StageChangedDTO(int stageID, int candidateID, DateTime changedDate)
        {
            StageID = stageID;
            CandidateID = candidateID;
            ChangedDate = changedDate;
        }
    }
}
