using System;
using System.Collections.Generic;
using System.Text;

namespace DevEduInterviewSystem.DAL.DTO.QueryDTO
{
    public class AllFeedbackByUserDTO : IDTO
    {
        public int? UserID { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string Message { get; set; }
        public DateTime? TimeFeedback { get; set; }
        public string CandidateFirstName { get; set; }
        public string CandidateLastName { get; set; }

        public AllFeedbackByUserDTO()
        {

        }

        public AllFeedbackByUserDTO(int userID, string userFirstName, string userLastName, string message, DateTime? timeFeedback,
                                    string candidateFirstName, string candidateLastName)
        {
            UserID = userID;
            UserFirstName = userFirstName;
            UserLastName = userLastName;
            Message = message;
            TimeFeedback = timeFeedback;
            CandidateFirstName = candidateFirstName;
            CandidateLastName = candidateLastName;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;

            AllFeedbackByUserDTO dto = (AllFeedbackByUserDTO)obj;
            return (this.UserFirstName == dto.UserFirstName
                && this.UserLastName == dto.UserLastName
                && this.Message == dto.Message
                && this.TimeFeedback == dto.TimeFeedback
                && this.CandidateFirstName == dto.CandidateFirstName
                && this.CandidateLastName == dto.CandidateLastName);
        }
    }
}
