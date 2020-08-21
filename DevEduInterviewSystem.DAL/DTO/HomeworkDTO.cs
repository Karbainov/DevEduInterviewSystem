using System;
using System.Collections.Generic;
using System.Text;


namespace DevEduInterviewSystem.DAL.DTO
{
    public class HomeworkDTO : IDTO
    {
        public int? ID { get; set; }
        public int? CandidateID { get; set; }
        public int? HomeworkStatusID { get; set; }
        public int? TestStatusID { get; set; }
        public DateTime HomeworkDate { get; set; }

        public HomeworkDTO()
        {

        }

        public HomeworkDTO(int ID, int? CandidateID, int? HomeworkStatusID, int? TestStatusID, DateTime HomeworkDate)
        {
            this.ID = ID;
            this.CandidateID = CandidateID;
            this.HomeworkStatusID = HomeworkStatusID;
            this.TestStatusID = TestStatusID;
            this.HomeworkDate = HomeworkDate;

        }
    }
}

