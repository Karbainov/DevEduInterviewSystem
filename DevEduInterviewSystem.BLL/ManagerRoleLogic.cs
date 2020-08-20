using System;
using System.Collections.Generic;
using System.Text;
using DevEduInterviewSystem.DAL.DTO;
using DevEduInterviewSystem.DAL.DTO.QuereDTO;
using DevEduInterviewSystem.DAL.StoredProcedures.CRUD;
using DevEduInterviewSystem.DAL.StoredProcedures.Query;

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

        public void AddCandidate(CandidateDTO candidate)
        {
            CandidateCRUD candidateCRUD = new CandidateCRUD();
            candidateCRUD.Add(candidate);
        }

        public void AddCourseCandidate(Course_CandidateDTO course_Candidate )
        {
            Course_CandidateCRUD course_CandidateCRUD = new Course_CandidateCRUD();
            course_CandidateCRUD.Add(course_Candidate);
        }

        public void UpdateCandidate(CandidateDTO candidateDTO)
        {
            CandidateCRUD candidate = new CandidateCRUD();
            candidate.UpdateByID(candidateDTO);            
        }

       public string GetOneTimePassword()
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
    }
}
