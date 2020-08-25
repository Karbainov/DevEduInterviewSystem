using DevEduInterviewSystem.DAL.DTO;


namespace DevEduInterviewSystem.API.Models.Input
{
    public class InterviewsInputModel
    {
        public InterviewDTO InterviewDTO  { get; set;}
        public int? UserID { get; set; }

        public int? StageID { get; set; }

        public FeedbackDTO? FeedbackDTO  { get; set; }
    }
}
