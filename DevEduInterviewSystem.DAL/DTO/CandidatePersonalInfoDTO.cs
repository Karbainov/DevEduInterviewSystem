using System;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.DTO
{
    public class CandidatePersonalInfoDTO
    {
        public int ID { get; set; }
        public int CandidateID { get; set; }
        public bool MaritalStatus { get; set; }
        public string Education { get; set; }
        public string WorkPlace { get; set; }
        public string ITExperience { get; set; }
        public string Hobbies { get; set; }
        public string InfoSourse { get; set; }
        public string Expectations { get; set; }

        public CandidatePersonalInfoDTO()
        {

        }

        public CandidatePersonalInfoDTO(int ID, int CandidateID, bool MaritalStatus, string Education, string WorkPlace, string ITExperience, string Hobbies, string InfoSourse, string Expectations)
        {
            this.ID = ID;
            this.CandidateID = CandidateID;
            this.MaritalStatus = MaritalStatus;
            this.Education = Education;
            this.WorkPlace = WorkPlace;
            this.ITExperience = ITExperience;
            this.Hobbies = Hobbies;
            this.InfoSourse = InfoSourse;
            this.Expectations = Expectations;
        }
    }
}
