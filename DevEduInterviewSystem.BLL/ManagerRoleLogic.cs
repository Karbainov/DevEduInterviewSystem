﻿using System;
using System.Collections.Generic;
using System.Text;
using DevEduInterviewSystem.DAL.DTO;
using DevEduInterviewSystem.DAL.StoredProcedures.CRUD;


namespace DevEduInterviewSystem.BLL
{
    public class ManagerRoleLogic : IRoleLogic
    {
        // Менеджер может обновить данные кандидата и personal info.
        public void UpdateCandidatePersonalInfo(CandidateDTO candidateDTO, CandidatePersonalInfoDTO candidatePersonalInfoDTO)
        {
            CandidateCRUD candidate = new CandidateCRUD();
            candidate.UpdateByID(candidateDTO);

            CandidatePersonalInfoCRUD candidatePersonalInfo = new CandidatePersonalInfoCRUD();
            candidatePersonalInfo.UpdateByID(candidatePersonalInfoDTO);
        }
        // Менеджер(после интервью): обновить интервью статус + обновить стадию + создать фидбэк + обновить курс.
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
    }
}
