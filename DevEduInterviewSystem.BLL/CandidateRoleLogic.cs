using System;
using System.Collections.Generic;
using System.Text;
using DevEduInterviewSystem.DAL.DTO;
using DevEduInterviewSystem.DAL.StoredProcedures;
using DevEduInterviewSystem.DAL.StoredProcedures.CRUD;

namespace DevEduInterviewSystem.BLL
{
    public class CandidateRoleLogic : IRoleLogic
    {
        // Во время собседеования кандидат может обновить свои данные, а одноразовый пароль должен удалиться

        public void UpdateCandidateInfo(CandidateDTO candidateDTO, CandidatePersonalInfoDTO candidatePersonalInfoDTO)
        {
            new CandidateCRUD().UpdateByID(candidateDTO);

            new CandidatePersonalInfoCRUD().Add(candidatePersonalInfoDTO);

            new DeleteOneTimePasswordByCandidateIDQuery().DeleteOneTimePasswordByCandidateID((int)candidateDTO.ID);

        }

    }
}
