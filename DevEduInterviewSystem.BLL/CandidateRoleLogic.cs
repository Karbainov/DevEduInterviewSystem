using System;
using System.Collections.Generic;
using System.Text;
using DevEduInterviewSystem.DAL.DTO;
using DevEduInterviewSystem.DAL.StoredProcedures;
using DevEduInterviewSystem.DAL.StoredProcedures.CRUD;

namespace DevEduInterviewSystem.BLL
{
    public class CandidateRoleLogicL : IRoleLogic
    {
        // Во время собседеования кандидат может обновить свои данные, а одноразовый пароль должен удалиться

        public void UpdateCandidateInfo(CandidateDTO candidateDTO, CandidatePersonalInfoDTO candidatePersonalInfoDTO)
        {
            CandidateCRUD candidate = new CandidateCRUD();
            candidate.UpdateByID(candidateDTO);

            CandidatePersonalInfoCRUD candidatePersonalInfo = new CandidatePersonalInfoCRUD();
            candidatePersonalInfo.UpdateByID(candidatePersonalInfoDTO);

            DeleteOneTimePasswordByCandidateIDQuery password = new DeleteOneTimePasswordByCandidateIDQuery();
            password.DeleteOneTimePasswordByCandidateID(candidateDTO.ID);

        }

    }
}
