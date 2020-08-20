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
            FeedbackDTO feedbackDTO)
        {
            CandidateCRUD candidate = new CandidateCRUD();
            candidate.UpdateByID(candidateDTO);

            StageChangedDTO stageDTO = new StageChangedDTO(candidateDTO.ID, candidateDTO.StageID, DateTime.Now);
            StageChangedCRUD stageChanged = new StageChangedCRUD();
            stageChanged.Add(stageDTO);

            InterviewDTO _interviewDTO = new InterviewDTO(candidateDTO.ID, interviewDTO.InterviewStatusID, DateTime.Now);
            InterviewCRUD interview = new InterviewCRUD();
            interview.UpdateByID(_interviewDTO);

            Course_CandidateDTO courseCandidateDTO = new Course_CandidateDTO(courseID, candidateDTO.ID);
            Course_CandidateCRUD courseCandidate = new Course_CandidateCRUD();
            courseCandidate.UpdateByID(courseCandidateDTO);

            FeedbackCRUD feedback = new FeedbackCRUD();
            if (feedbackDTO != null)
            {                
                feedback.UpdateByID(feedbackDTO);
            }
            feedback.Add(feedbackDTO);
        }
        // Препод(после получения дз от кандидата): обновить статус домашки  
        // +обновить стадию + обновить статус + добавить фидбэк
        public void UpdateHomeworkAfterDoneHomework(CandidateDTO candidateDTO, HomeworkDTO homeworkDTO, 
            int homeworkStatusID, int testStatusID, FeedbackDTO feedbackDTO)
        {
            HomeworkDTO homework = new HomeworkDTO(homeworkDTO.ID, homeworkDTO.CandidateID, homeworkStatusID,
                testStatusID, DateTime.Now);
            HomeworkCRUD homeworkCRUD = new HomeworkCRUD();
            homeworkCRUD.Add(homework);

            StageChangedDTO stageChangedDTO = new StageChangedDTO(candidateDTO.ID, candidateDTO.StageID, DateTime.Now);
            StageChangedCRUD stageChanged = new StageChangedCRUD();
            stageChanged.Add(stageChangedDTO);

            CandidateCRUD candidate = new CandidateCRUD();
            candidate.UpdateByID(candidateDTO);

            FeedbackCRUD feedback = new FeedbackCRUD();
            if (feedbackDTO != null)
            {
                feedback.UpdateByID(feedbackDTO);
            }
            feedback.Add(feedbackDTO);
        }
        
        
    }
}
