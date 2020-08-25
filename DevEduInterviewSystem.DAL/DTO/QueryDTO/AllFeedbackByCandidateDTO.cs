using System;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.DTO.QueryDTO
{
    public class AllFeedbackByCandidateDTO : IDTO
    {
        public int? CandidateID { get; set; }
        public string CandidateFirstName { get; set; }
        public string CandidateLastName { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string StageName { get; set; }
        public string Message { get; set; }
        public DateTime? TimeFeedback { get; set; }

        public AllFeedbackByCandidateDTO()
        {

        }

        public AllFeedbackByCandidateDTO(int candidateID, string candidateFirstName, string candidateLastName,
            string userFirstName, string userLastName, string stageName, string message, DateTime? timeFeedback)
        {
            CandidateID = candidateID;
            CandidateFirstName = candidateFirstName;
            CandidateLastName = candidateLastName;
            UserFirstName = userFirstName;
            UserLastName = userLastName;
            StageName = stageName;
            Message = message;
            TimeFeedback = timeFeedback;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;

            AllFeedbackByCandidateDTO dto = (AllFeedbackByCandidateDTO)obj;
            return (this.CandidateID == dto.CandidateID
                && this.CandidateFirstName == dto.CandidateFirstName
                && this.CandidateLastName == dto.CandidateLastName
                && this.UserFirstName == dto.UserFirstName
                && this.UserLastName == dto.UserLastName
                && this.StageName == dto.StageName
                && this.Message == dto.Message
                && this.TimeFeedback == dto.TimeFeedback);
        }
    }
}