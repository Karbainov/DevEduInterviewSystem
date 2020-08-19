using System;
using System.Collections.Generic;
using System.Text;
using DevEduInterviewSystem.DAL.DTO;
using DevEduInterviewSystem.DAL.StoredProcedures.CRUD;

namespace DevEduInterviewSystem.BLL
{
    public class TeacherRoleLogic : IRoleLogic
    {
        public void DoUpdatesAfterInterview(CandidateDTO candidateDTO, InterviewDTO interviewDTO, int courseID, FeedbackDTO feedbackDTO)
        {
            CandidateCRUD candidate = new CandidateCRUD();
            int candidateID = candidate.UpdateByID(candidateDTO);

            StageChangedDTO stageDTO = new StageChangedDTO(candidateID, candidateDTO.StageID, DateTime.Now);
            StageChangedCRUD stageChanged = new StageChangedCRUD();
            stageChanged.UpdateByID(stageDTO);

            StatusDTO statusDTO = new StatusDTO(candidateDTO.StatusID);
            StatusCRUD status = new StatusCRUD();
            status.UpdateByID(statusDTO);

            InterviewDTO _interviewDTO = new InterviewDTO(candidateID, interviewDTO.InterviewStatusID, DateTime.Now);
            InterviewCRUD interview = new InterviewCRUD();
            interview.UpdateByID(_interviewDTO);

            Course_CandidateDTO courseCandidateDTO = new Course_CandidateDTO(courseID, candidateID);
            Course_CandidateCRUD courseCandidate = new Course_CandidateCRUD();
            courseCandidate.UpdateByID(courseCandidateDTO);

            FeedbackCRUD feedback = new FeedbackCRUD();
            if (feedbackDTO != null)
            {                
                feedback.UpdateByID(feedbackDTO);
            }
            feedback.Add(feedbackDTO);
        }
    }
}
