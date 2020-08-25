using System;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.DTO
{
    public class Course_CandidateDTO : IDTO
    {
        public int ID { get; set; }
        public int? CourseID { get; set; }
        public int? CandidateID { get; set; }

        public Course_CandidateDTO()
        {

        }
        public Course_CandidateDTO(int courseID, int candidateID)
        {
            this.CourseID = courseID;
            this.CandidateID = candidateID;
        }
        public Course_CandidateDTO(int ID, int courseID, int candidateID)
        {
            this.ID = ID;
            this.CourseID = courseID;
            this.CandidateID = candidateID;
        }
        public Course_CandidateDTO(int courseID)
        {
            this.CourseID = courseID;
        }
    }
}
