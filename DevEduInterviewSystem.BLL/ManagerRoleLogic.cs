using System;
using System.Collections.Generic;
using System.Text;
using DevEduInterviewSystem.DAL.DTO;
using DevEduInterviewSystem.DAL.DTO.QuereDTO;
using DevEduInterviewSystem.DAL.StoredProcedures;
using DevEduInterviewSystem.DAL.StoredProcedures.CRUD;
using DevEduInterviewSystem.DAL.StoredProcedures.Query;

namespace DevEduInterviewSystem.BLL
{
    public class ManagerRoleLogic : IRoleLogic
    {
        // Менеджер может обновить данные кандидата и personal info.
        public void UpdateCandidatePersonalInfo(CandidateDTO candidateDTO, CandidatePersonalInfoDTO candidatePersonalInfoDTO)
        {
            UpdateCandidate(candidateDTO);

            CandidatePersonalInfoCRUD candidatePersonalInfo = new CandidatePersonalInfoCRUD();
            candidatePersonalInfo.UpdateByID(candidatePersonalInfoDTO);
        }
        public void UpdateCandidate(CandidateDTO candidateDTO)
        {
            CandidateCRUD candidate = new CandidateCRUD();
            candidate.UpdateByID(candidateDTO);
        }
        public void AddOneTimePassword(OneTimePasswordDTO oneTimePasswordDTO)
        {
            string password = GetOneTimePassword();
            oneTimePasswordDTO.OneTimePassword = password;
            OneTimePasswordCRUD otp = new OneTimePasswordCRUD();
            otp.Add(oneTimePasswordDTO);
        }

        private string GetOneTimePassword()
        {
            Random randomKey = new Random();
            string simvol = "QWERTYUIOPASDFGHJKLZXCVBNM!@#$%^&*()qwertyuiopasdfghjklzxcvbnm1234567890-=[];'./,";
            int lenghtPass = 12;
            char[] letters = simvol.ToCharArray();
            string password = "";
            for (int i = 0; i < lenghtPass; i++)
            {
                password += letters[randomKey.Next(letters.Length)].ToString();
            }

            return password;
        }

        public AllInformationAboutTheCandidateByIDDTO AllInformationAboutCandidate(int id)
        {
            AllInformationAboutTheCandidateByIDProcedure infoCandidate = new AllInformationAboutTheCandidateByIDProcedure();
            AllInformationAboutTheCandidateByIDDTO q = infoCandidate.AllInformationAboutTheCandidateByID(id);
            return q;
        }
        

        public void AddCourseCandidate(Course_CandidateDTO course_Candidate)
        {
            Course_CandidateCRUD course_CandidateCRUD = new Course_CandidateCRUD();
            course_CandidateCRUD.Add(course_Candidate);
        }
        public void AddCandidate(CandidateDTO candidate)
        {
            CandidateCRUD candidateCRUD = new CandidateCRUD();
            candidateCRUD.Add(candidate);
        }

        // WHICH ONE?

        public void AddCandidate(CandidateDTO candidateDTO, int courseID, TaskDTO taskDTO = null, FeedbackDTO feedbackDTO = null)
        {
            CandidateCRUD candidate = new CandidateCRUD();
            int candidateID = candidate.Add(candidateDTO);

            Course_CandidateDTO courseCandidateDTO = new Course_CandidateDTO(courseID, candidateID);
            Course_CandidateCRUD courseCandidate = new Course_CandidateCRUD();
            courseCandidate.Add(courseCandidateDTO);

            ChangeStageAddFeedback(candidateID, candidateDTO.StageID, feedbackDTO);

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

        // Грант получен, группа есть

        public void AddCandidateToGroup(int candidateID, int groupID, int stageID, FeedbackDTO feedbackDTO = null)
        {
            GroupCandidateDTO candidate = new GroupCandidateDTO();
            candidate.CandidateID = candidateID;
            candidate.GroupID = groupID;
            GroupCandidateCRUD group = new GroupCandidateCRUD();
            group.Add(candidate);



        }
    }
}
