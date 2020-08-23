using DevEduInterviewSystem.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevEduInterviewSystem.API.Models.Input
{
    public class CandidateFormModel
    {
        public CandidateDTO CandidateDTO { get; set; }
        public CandidatePersonalInfoDTO CandidatePersonalInfoDTO { get; set; }
    }
}

