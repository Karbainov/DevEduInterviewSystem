using System;
using System.Collections.Generic;
using System.Text;
using DevEduInterviewSystem.DAL.DTO;
using DevEduInterviewSystem.DAL.DTO.CalendarInterviews;
using DevEduInterviewSystem.DAL.StoredProcedures.Query.CalendarInterviews;
using DevEduInterviewSystem.DAL.StoredProcedures;
using DevEduInterviewSystem.DAL.StoredProcedures.CRUD;

namespace DevEduInterviewSystem.BLL
{
    public class PhoneOperatorRoleLogic : IRoleLogic
    {

        public void AddCandidate(CandidateDTO candidateDTO, int courseID, TaskDTO taskDTO = null, FeedbackDTO feedbackDTO = null)
        {
            CandidateCRUD candidate = new CandidateCRUD();
            int candidateID = candidate.Add(candidateDTO);

            Course_CandidateDTO courseCandidateDTO = new Course_CandidateDTO(courseID, candidateID);
            Course_CandidateCRUD courseCandidate = new Course_CandidateCRUD();
            courseCandidate.Add(courseCandidateDTO);

            StageChangedDTO stageDTO = new StageChangedDTO(candidateID, candidateDTO.StageID, DateTime.Now);
            StageChangedCRUD stageChanged = new StageChangedCRUD();
            stageChanged.Add(stageDTO);
            
            if (taskDTO != null)
            {
                AddTask(taskDTO, feedbackDTO);
            }


        }

        public void AddTask(TaskDTO taskDTO, FeedbackDTO feedbackDTO = null)
        {
            TaskCRUD task = new TaskCRUD();
            task.Add(taskDTO);

            if (feedbackDTO != null)
            {
                FeedbackCRUD feedback = new FeedbackCRUD();
                feedback.Add(feedbackDTO);
            }
        }

        public void ChangeStageAddFeedback(StageChangedDTO stageChangedDTO, FeedbackDTO feedbackDTO = null)
        {
            StageChangedCRUD stage = new StageChangedCRUD();
            int stageChangedID = stage.Add(stageChangedDTO);
            
            if (feedbackDTO != null)
            {
                FeedbackCRUD feedback = new FeedbackCRUD();
                feedbackDTO.StageChangedID = stageChangedID;
                feedback.Add(feedbackDTO);
            }
            
        }

        public void ScheduleInterview(InterviewDTO interviewDTO, StageChangedDTO stageChangedDTO, FeedbackDTO feedbackDTO = null)
        {
            List <AllInterviewsDTO> interviewsList = new List<AllInterviewsDTO>();
            AllInterviewsByDateQuery interviews = new AllInterviewsByDateQuery();
            interviewsList = interviews.SelectAllInterviewsByDate(interviewDTO.DateTimeInterview);

            InterviewsNumber interviewsLimit = new InterviewsNumber(InterviewsNumber.GetInstance().InterviewsLimit);
            if (interviewsList.Count < interviewsLimit.InterviewsLimit)
            {
                InterviewCRUD interview = new InterviewCRUD();
                interview.Add(interviewDTO);
                ChangeStageAddFeedback(stageChangedDTO, feedbackDTO);
            }
            else
            {
                throw new Exception("The interviews limit is exceeded");
            }

            //To do: try catch in controller (catch - exception=> IActionResult bad request)
        }
    }
}
