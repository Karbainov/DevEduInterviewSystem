﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks.Dataflow;
using DevEduInterviewSystem.DAL.DTO;
using DevEduInterviewSystem.DAL.Shared;
using DevEduInterviewSystem.DAL.DTO.QuereDTO;
using DevEduInterviewSystem.DAL.StoredProcedures;
using DevEduInterviewSystem.DAL.StoredProcedures.CRUD;
using DevEduInterviewSystem.DAL.StoredProcedures.Query;
using DevEduInterviewSystem.DAL.DTO.QueryDTO;
using DevEduInterviewSystem.DAL.StoredProcedures.Query.AllOverdueHomework;

namespace DevEduInterviewSystem.BLL
{
    public class ManagerRoleLogic : IRoleLogic
    {

        #region Candidate
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
        public AllInformationAboutTheCandidateByIDDTO AllInformationAboutCandidate(int id)
        {
            AllInformationAboutTheCandidateByIDProcedure infoCandidate = new AllInformationAboutTheCandidateByIDProcedure();
            AllInformationAboutTheCandidateByIDDTO q = infoCandidate.AllInformationAboutTheCandidateByID(id);
            return q;
        }
        public void UpdateCandidate(CandidateDTO candidateDTO)
        {
            CandidateCRUD candidate = new CandidateCRUD();
            candidate.UpdateByID(candidateDTO);
        }

        // Менеджер может обновить данные кандидата и personal info.
        public void UpdateCandidatePersonalInfo(CandidateDTO candidateDTO, CandidatePersonalInfoDTO candidatePersonalInfoDTO)
        {
            UpdateCandidate(candidateDTO);

            CandidatePersonalInfoCRUD candidatePersonalInfo = new CandidatePersonalInfoCRUD();
            candidatePersonalInfo.UpdateByID(candidatePersonalInfoDTO);
        }

        // Менеджер(после интервью): обновить интервью статус + обновить стадию + создать фидбэк + обновить курс.
        public void UpdateCandidateAfterInterview(CandidateDTO candidateDTO, InterviewDTO interviewDTO, int courseID,
            FeedbackDTO feedbackDTO = null)
        {
            UpdateCandidate(candidateDTO);

            ChangeStageAddFeedback((int)candidateDTO.ID, (int)candidateDTO.StageID, feedbackDTO);

            InterviewDTO _interviewDTO = new InterviewDTO(candidateDTO.ID, interviewDTO.InterviewStatusID, DateTime.Now);
            InterviewCRUD interview = new InterviewCRUD();
            interview.UpdateByID(_interviewDTO);

            Course_CandidateDTO courseCandidateDTO = new Course_CandidateDTO(courseID, (int)candidateDTO.ID);
            Course_CandidateCRUD courseCandidate = new Course_CandidateCRUD();
            courseCandidate.UpdateByID(courseCandidateDTO);
        }
        #endregion

        #region OneTimePassword
        public string AddOneTimePassword(OneTimePasswordDTO oneTimePasswordDTO)
        {
            string password = GetOneTimePassword();
            oneTimePasswordDTO.OneTimePassword = password;
            OneTimePasswordCRUD otp = new OneTimePasswordCRUD();
            otp.Add(oneTimePasswordDTO);
            return password;
        }

        public string GetOneTimePassword()
        {
            Random randomKey = new Random();
            string simbol = "QWERTYUIOPASDFGHJKLZXCVBNM1234567890";           
            char[] letters = simbol.ToCharArray();
            string password = "";
            for (int i = 0; i < Consts.passwordLength; i++)
            {
                password += letters[randomKey.Next(letters.Length)].ToString();
            }

            return password;
        }
        #endregion

        #region Course&Group

        // Менеджер(запуск группы): создать группу
        public void CreateGroup(GroupDTO groupDTO)
        {
            GroupCRUD group = new GroupCRUD();
            group.Add(groupDTO);
        }
        public void UpdateGroup(GroupDTO groupDTO)
        {
            GroupCRUD group = new GroupCRUD();
            group.UpdateByID(groupDTO);
        }
        public void DeleteGroup(int? groupID)
        {
            GroupCRUD groupCRUD = new GroupCRUD();
            groupCRUD.DeleteByID((int)groupID);
        }
        public void UpdateCourseByCandidate(Course_CandidateDTO course_CandidateDTO)
        {
            Course_CandidateCRUD course = new Course_CandidateCRUD();
            course.UpdateByID(course_CandidateDTO);
        }
        // Грант получен, группа есть
        public void AddCandidateToGroup(int candidateID, int groupID, int stageID, FeedbackDTO feedbackDTO = null)
        {
            GroupCandidateDTO candidate = new GroupCandidateDTO();
            candidate.CandidateID = candidateID;
            candidate.GroupID = groupID;
            GroupCandidateCRUD group = new GroupCandidateCRUD();
         
            group.Add(candidate);

            DeleteCandidateFromCourseCandidateByCandidateID deletion = new DeleteCandidateFromCourseCandidateByCandidateID();
            deletion.DeleteCandidateFromCourseByCandidateID(candidateID);

            ChangeStageAddFeedback(candidateID, stageID, feedbackDTO);
        }
        public void UpdateGroupByCandidate(GroupCandidateDTO groupCandidateDTO)
        {
            GroupCandidateCRUD group = new GroupCandidateCRUD();
            group.UpdateByID(groupCandidateDTO);
        }            
        
        // Грант получен, нет вохможности начать с текущей группой
        public void ReturnAwaitingCandidateToCourse(int candidateID, int courseID, int stageID, FeedbackDTO feedbackDTO = null)
        {
            Course_CandidateDTO candidate = new Course_CandidateDTO();
            candidate.CandidateID = candidateID;
            candidate.CourseID = courseID;
            Course_CandidateCRUD course = new Course_CandidateCRUD();
            course.Add(candidate);

            DeleteCandidateFromGroupCandidateByCandidateID deletion = new DeleteCandidateFromGroupCandidateByCandidateID();
            deletion.DeleteCandidateFromGroupByCandidateID(candidateID);

            ChangeStageAddFeedback(candidateID, stageID, feedbackDTO);
        }
        #endregion

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

        public List<InterviewDTO> GetInterviews(int? userID, DateTime? startDateTimeInterview, DateTime? finishDateTimeInterview, DateTime? dateTime)
        {
            InterviewCRUD interviewCRUD = new InterviewCRUD();

            if (userID != null && startDateTimeInterview != null && finishDateTimeInterview != null)
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

        public void UpdateFeedback(FeedbackDTO feedbackDTO)
        {
            FeedbackCRUD feedback = new FeedbackCRUD();
            feedback.UpdateByID(feedbackDTO);
        }
        public List<FeedbackDTO> GetAllFeedbacks()
        {
            FeedbackCRUD feedbackCRUD = new FeedbackCRUD();
            List<FeedbackDTO> feedbacks = feedbackCRUD.SelectAll();
            return feedbacks;
        }

        public List<AllFeedbackByUserDTO> GetAllFeedbacksByUser(int userID)
        {
            AllFeedbacksByUserQuery tmp = new AllFeedbacksByUserQuery();
            List<AllFeedbackByUserDTO> feedbacks = tmp.AllFeedbacksByUser(userID);
            return feedbacks;
        }

        public List<AllFeedbackByCandidateDTO> GetAllFeedbacksByCandidate(int candidateID)
        {
            AllFeedbacksByCandidateQuery allFeedbacksByCandidate = new AllFeedbacksByCandidateQuery();
            List<AllFeedbackByCandidateDTO> feedbacks = allFeedbacksByCandidate.AllFeedbacksByCandidate(candidateID);
            return feedbacks;
        }
    }
}
