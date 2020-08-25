using System;
using System.Collections.Generic;
using System.Text;
using DevEduInterviewSystem.DAL.DTO;
using DevEduInterviewSystem.DAL.DTO.QuereDTO;
using DevEduInterviewSystem.DAL.DTO.QueryDTO;
using DevEduInterviewSystem.DAL.StoredProcedures.CRUD;
using DevEduInterviewSystem.DAL.StoredProcedures.Query;
using DevEduInterviewSystem.DAL.StoredProcedures.Query.AllOverdueHomework;

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

        public FeedbackDTO GetFeedback(int id)
        {
            FeedbackCRUD feedback = new FeedbackCRUD();
            return feedback.SelectByID(id);
        }

        public void AddFeedback(FeedbackDTO feedbackDTO)
        {
            FeedbackCRUD feedback = new FeedbackCRUD();
            feedback.Add(feedbackDTO);
        }
        public void UpdateFeedback(FeedbackDTO feedbackDTO) //нужно проверить
        {
            FeedbackCRUD feedback = new FeedbackCRUD();
            feedback.UpdateByID(feedbackDTO);
        }

        public List<AllFeedbackByUserDTO> GetAllFeedbacksByUser(int userID)
        {
            AllFeedbackByUserQuery tmp = new AllFeedbackByUserQuery();
            List<AllFeedbackByUserDTO> feedbacks = tmp.AllFeedbackByUser(userID);
            return feedbacks;
        }
        public List<AllOverdueTestsDTO> GetAllOverdueHomework()
        {
            DateTime dateTimeNow = DateTime.Now;
            AllOverdueHomeworks allOverdueHomeworks = new AllOverdueHomeworks();
            List<AllOverdueTestsDTO> overdueHomeworks = allOverdueHomeworks.GetAllOverdueHomeworks(dateTimeNow);


            return overdueHomeworks;
        }
    }
}
