using System;
using System.Collections.Generic;
using System.Text;
using DevEduInterviewSystem.DAL.DTO;
using DevEduInterviewSystem.DAL.StoredProcedures.CRUD;

namespace DevEduInterviewSystem.BLL
{
    public class TeacherRoleLogic : IRoleLogic
    {
        public void UpdateCandidateAfterInterview(CandidateDTO candidateDTO, InterviewDTO interviewDTO, int courseID, 
            FeedbackDTO feedbackDTO = null)
        {
            CandidateCRUD candidate = new CandidateCRUD();
            candidate.UpdateByID(candidateDTO);

            StageChangedDTO stageDTO = new StageChangedDTO((int)candidateDTO.ID, (int)candidateDTO.StageID, DateTime.Now);
            StageChangedCRUD stageChanged = new StageChangedCRUD();
            stageChanged.Add(stageDTO);

            InterviewDTO _interviewDTO = new InterviewDTO(candidateDTO.ID, interviewDTO.InterviewStatusID, DateTime.Now);
            InterviewCRUD interview = new InterviewCRUD();
            interview.UpdateByID(_interviewDTO);

            Course_CandidateDTO courseCandidateDTO = new Course_CandidateDTO(courseID, (int)candidateDTO.ID);
            Course_CandidateCRUD courseCandidate = new Course_CandidateCRUD();
            courseCandidate.UpdateByID(courseCandidateDTO);
           
            FeedbackCRUD feedback = new FeedbackCRUD();
           
            if (feedbackDTO != null)
            {
                feedback.Add(feedbackDTO);
            }
            
        }
        public void UpdateHomeworkAfterDoneHomework(HomeworkDTO homeworkDTO, FeedbackDTO feedbackDTO)
        {
           
            HomeworkCRUD homeworkCRUD = new HomeworkCRUD();
            homeworkCRUD.UpdateByID(homeworkDTO);
            FeedbackCRUD feedback = new FeedbackCRUD();
            if (new FeedbackCRUD().SelectByID((int)feedbackDTO.ID)==null)
            {
                feedback.Add(feedbackDTO);
            }
            else
            {
                feedback.UpdateByID(feedbackDTO);
            }
        }


        public List<InterviewDTO> GetInterviews(int? userID, DateTime? startDateTimeInterview, DateTime? finishDateTimeInterview, DateTime? dateTime)
        {

            InterviewCRUD interviewCRUD = new InterviewCRUD();

            if(userID != null && startDateTimeInterview != null && finishDateTimeInterview != null)
            {
                return interviewCRUD.SelectByDateTimeIntervalAndUser((int)userID, (DateTime)startDateTimeInterview, (DateTime)finishDateTimeInterview);
            }
            else if (userID != null && dateTime != null)
            {
                return interviewCRUD.SelectByUserAndDateTime((DateTime)dateTime, (int)userID);
            }
            else if (userID != null)
            {
                return interviewCRUD.SelectByUser((int)userID);
            }
            else if (startDateTimeInterview != null && finishDateTimeInterview != null)
            {
                return interviewCRUD.SelectByDateTimeInterval((DateTime)startDateTimeInterview, (DateTime)finishDateTimeInterview);
            }
            else if (dateTime != null)
            {
                return interviewCRUD.SelectByDateTime((DateTime)dateTime);
            }

            return interviewCRUD.SelectAll();
        }


        public void AddFeedback(FeedbackDTO feedbackDTO, StatusDTO status = null)
        {
            FeedbackCRUD feedback = new FeedbackCRUD();
            feedback.Add(feedbackDTO);

            if(status != null)
            {
                StatusCRUD statusCRUD = new StatusCRUD();
                statusCRUD.UpdateByID(status);
            }
        }
    }
}
