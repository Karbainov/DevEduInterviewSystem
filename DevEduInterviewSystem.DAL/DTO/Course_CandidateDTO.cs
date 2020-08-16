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

        public Course_CandidateDTO(){ }
        public Course_CandidateDTO(int id, int courseID, int candidateID)
        {
            ID = id;
            CourseID = courseID;
            CandidateID = candidateID;
        }
    }
}
