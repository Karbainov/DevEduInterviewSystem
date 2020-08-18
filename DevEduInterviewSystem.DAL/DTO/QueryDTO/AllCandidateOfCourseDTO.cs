using System;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.DTO.QuereDTO
{
    public class AllCandidateOfCourseDTO : IDTO
    {
        public int? CourseID { get; set; }
        public string Name { get; set; }
        public int? CandidateID { get; set; }
        public string CandidateFirstName { get; set; }
        public string CandidateLastName { get; set; }

        public AllCandidateOfCourseDTO()
        {

        }

        public AllCandidateOfCourseDTO(string name, int candidateID, string candidateFirstName, string candidateLastName)
        {
            Name = name; 
            CandidateID = candidateID;
            CandidateFirstName = candidateFirstName;
            CandidateLastName = candidateLastName;
        }

        public AllCandidateOfCourseDTO(int courseID, int candidateID)
        {
            
            CourseID = courseID;
            CandidateID = candidateID;

        }
        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;

            AllCandidateOfCourseDTO dto = (AllCandidateOfCourseDTO)obj;
            return (this.Name == dto.Name
                && this.CandidateID == dto.CandidateID
                && this.CandidateFirstName == dto.CandidateFirstName
                && this.CandidateLastName == dto.CandidateLastName);
        }
    }
}
