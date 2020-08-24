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
            
            ChangeStageAddFeedback(candidateID, (int)candidateDTO.StageID, feedbackDTO);

            if (taskDTO != null)
            {
                AddTask(taskDTO);
            }
        }

        public void AddTask(TaskDTO taskDTO)
        {
            TaskCRUD task = new TaskCRUD();
            task.Add(taskDTO);
        }
        public void AddFeedback(FeedbackDTO feedbackDTO)
        {
            FeedbackCRUD feedback = new FeedbackCRUD();
            feedback.Add(feedbackDTO);
        }

        public void ChangeStageAddFeedback(int candidateID, int stageID, FeedbackDTO feedbackDTO = null)
        {
            StageChangedDTO stageChangedDTO = new StageChangedDTO();
            stageChangedDTO.CandidateID = candidateID;
            stageChangedDTO.ChangedDate = DateTime.Now;
            stageChangedDTO.StageID = stageID;

            StageChangedCRUD stage = new StageChangedCRUD();
            stage.Add(stageChangedDTO);
            if (feedbackDTO != null)
            {
                AddFeedback(feedbackDTO);
            }

        }

        //public void ScheduleInterview(InterviewDTO interviewDTO, int stageID, FeedbackDTO feedbackDTO = null) //Зачем отдельно Stage? Зачем при планировании Feedback? Где User? 
        //{
        //    List<AllInterviewsDTO> interviewsList = new List<AllInterviewsDTO>();
        //    AllInterviewsByDateQuery interviews = new AllInterviewsByDateQuery();
        //    interviewsList = interviews.SelectAllInterviewsByDate((DateTime)interviewDTO.DateTimeInterview);

        //    InterviewsNumber interviewsLimit = new InterviewsNumber(InterviewsNumber.GetInstance().InterviewsLimit);
        //    if (interviewsList.Count < interviewsLimit.InterviewsLimit)
        //    {
        //        InterviewCRUD interview = new InterviewCRUD();
        //        interview.Add(interviewDTO);
        //        ChangeStageAddFeedback((int)interviewDTO.CandidateID, stageID, feedbackDTO);
        //    }
        //    else
        //    {
        //        throw new Exception("The interviews limit is exceeded");
        //    }
        //    //To do: try catch in controller (catch - exception=> IActionResult bad request)
        //}

        public void ScheduleInterview(InterviewDTO interviewDTO, int userID) 
        {

            InterviewCRUD interview = new InterviewCRUD();

            int count = interview.CountInterviewsByDateTimeAndUser(userID, (DateTime)interviewDTO.DateTimeInterview);

            InterviewsNumber interviewsLimit = new InterviewsNumber(InterviewsNumber.GetInstance().InterviewsLimit);

            if (count < interviewsLimit.InterviewsLimit)
            {
                interview.Add(interviewDTO);
                UserInterviewCRUD userInterview = new UserInterviewCRUD();
                userInterview.Add(new UserInterviewDTO(null, interviewDTO.ID, userID));
            }
            else
            {
                throw new Exception("The interviews limit is exceeded");
            }
            
        }

    }
}
