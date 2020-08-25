using System;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.DTO
{
    public class CandidatePersonalInfoDTO : IDTO
    {
        public int? ID { get; set; }
        public int? CandidateID { get; set; }
        public bool? MaritalStatus { get; set; }
        public string Education { get; set; }
        public string WorkPlace { get; set; }
        public string ITExperience { get; set; }
        public string Hobbies { get; set; }
        public string InfoSourse { get; set; }
        public string Expectations { get; set; }

        public CandidatePersonalInfoDTO()
        {

        }

        public CandidatePersonalInfoDTO(int ID, int candidateID, bool maritalStatus, string education, string workPlace, 
            string ITExperience, string hobbies, string infoSourse, string expectations)
        {
            this.ID = ID;
            this.CandidateID = candidateID;
            this.MaritalStatus = maritalStatus;
            this.Education = education;
            this.WorkPlace = workPlace;
            this.ITExperience = ITExperience;
            this.Hobbies = hobbies;
            this.InfoSourse = infoSourse;
            this.Expectations = expectations;
        }
    }
}
