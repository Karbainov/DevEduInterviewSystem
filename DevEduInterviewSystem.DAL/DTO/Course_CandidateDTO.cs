using System;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.DTO
{
    public class Course_CandidateDTO
    {
        public int ID { get; set; }
        public int CourseID { get; set; }
        public int CandidateID { get; set; }

        public Course_CandidateDTO()
        {

        }
        public Course_CandidateDTO(int CourseID, int CandidateID)
        {
            this.ID = ID;
            this.CourseID = CourseID;
            this.CandidateID = CandidateID;
        }
        public Course_CandidateDTO(int ID, int CourseID, int CandidateID)
        {
            this.ID = ID;
            this.CourseID = CourseID;
            this.CandidateID = CandidateID;
        }
    }
}
