using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevEduInterviewSystem.API.Models.Input;
using DevEduInterviewSystem.BLL;
using DevEduInterviewSystem.DAL.DTO;
using DevEduInterviewSystem.DAL.DTO.QuereDTO;
using DevEduInterviewSystem.DAL.StoredProcedures.CRUD;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevEduInterviewSystem.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CandidateController : Controller
    {
        private PhoneOperatorRoleLogic _phoneOperator = new PhoneOperatorRoleLogic();
        private TeacherRoleLogic _teacher = new TeacherRoleLogic();
        private ManagerRoleLogic _manager = new ManagerRoleLogic();
        private CandidateRoleLogic _tmpCandidate = new CandidateRoleLogic();

        // Manager and phoneoperator
        [HttpPost]
        public IActionResult CreateCandidate(CandidateInputModel candidateInputModel)
        {
            if (new CityCRUD().SelectByID((int)candidateInputModel.CandidateDTO.CityID) == null)
            {
                return new NotFoundObjectResult("City not found");
            }
            if (new CourseCRUD().SelectByID((int)candidateInputModel.CourseID) == null)
            {
                return new NotFoundObjectResult("Course not found");
            }
            if ((candidateInputModel.CandidateDTO.FirstName != null
                || candidateInputModel.CandidateDTO.LastName != null)
                && candidateInputModel.CandidateDTO.Phone != null
                && candidateInputModel.CandidateDTO.CityID > 0
                && candidateInputModel.CourseID != null)
            {
                candidateInputModel.CandidateDTO.BirthDay = DateTime.Now;
                _phoneOperator.AddCandidate(candidateInputModel.CandidateDTO, (int)candidateInputModel.CourseID);
                return new OkResult();
            }
            else
            {
                return BadRequest("Fields missing");
            }

        }

        [HttpGet("{candidateID}/one-time-password")]
        public IActionResult GetOneTimePassword(int candidateID)
        {
            CandidateCRUD candidateCRUD = new CandidateCRUD();
            string password = null;
            if (candidateCRUD.SelectByID(candidateID) == null)
            {
                return new NotFoundResult();
            }
            password = _manager.GetOneTimePassword();

            OneTimePasswordCRUD pass = new OneTimePasswordCRUD();
            List<OneTimePasswordDTO> passwords = pass.SelectAll();
            foreach (OneTimePasswordDTO otp in passwords)
            {
                if (otp.OneTimePassword == password)
                {
                    return BadRequest(new { errorText = "Same OneTimePassword already exists" });
                }
            }
            return Ok(password);
        }

        [HttpGet("{candidateID}")]
        public IActionResult AllInformationAboutCandidate(int candidateID)
        {
            CandidateCRUD candidateCRUD = new CandidateCRUD();
            if (candidateCRUD.SelectByID(candidateID) != null)
            {
                AllInformationAboutTheCandidateByIDDTO infoCandidate = _manager.AllInformationAboutCandidate(candidateID);
                return Ok(infoCandidate);
            }
            else
            {
                return new NotFoundResult();
            }
        }

        [HttpPut("{candidateID}")]
        public IActionResult UpdateCandidate(CandidateInputModel candidateInputModel)
        {
            CandidateCRUD candidateCRUD = new CandidateCRUD();
            
            if(candidateCRUD.SelectByID((int)candidateInputModel.CandidateDTO.ID) != null)
            {
                _manager.UpdateCandidate(candidateInputModel.CandidateDTO);
                return new OkResult();
            }
            else
            {
                return new NotFoundResult();
            }
        }

        [Authorize(Roles = "Manager")]
        [HttpPut("update-course-candidate")]
        public IActionResult UpdateCourseByCandidate(Course_CandidateDTO course_CandidateDTO)
        {
            int? courseID = course_CandidateDTO.CourseID;
            int? candidateID = course_CandidateDTO.CandidateID;
            if (new CandidateCRUD().SelectByID((int)candidateID).ID == null)
            {
                return new NotFoundObjectResult("candidate not found");
            }
            if (new CourseCRUD().SelectByID((int)courseID).ID == null)
            {
                return new NotFoundObjectResult("group not found");
            }
            _manager.UpdateCourseByCandidate(course_CandidateDTO);

            return Ok();

        }

        [HttpPut("update-candidate-after-interview")]
        public IActionResult UpdateCandidateAfterInterview            (UpdateCandidateAfterInterviewModel updateCandidateAfterInterviewModel)        {            if (updateCandidateAfterInterviewModel.CourseID == null)            {                return new NotFoundResult();            }            if (updateCandidateAfterInterviewModel.interviewDTO.InterviewStatusID == null)            {                return new NotFoundResult();            }            if (updateCandidateAfterInterviewModel.CandidateDTO.ID == null)            {                return new NotFoundResult();            }            if (updateCandidateAfterInterviewModel.CandidateDTO.StatusID == null)            {                return new NotFoundResult();            }            if (updateCandidateAfterInterviewModel.interviewDTO.InterviewStatusID == null)            {                return new NotFoundResult();            }            if (updateCandidateAfterInterviewModel.feedbackDTO.StageChangedID == null)            {                return new NotFoundResult();            }
            _teacher.UpdateCandidateAfterInterview(updateCandidateAfterInterviewModel.CandidateDTO,                updateCandidateAfterInterviewModel.interviewDTO,                (int)updateCandidateAfterInterviewModel.CourseID,                updateCandidateAfterInterviewModel.feedbackDTO);            return new OkResult();        }

        [HttpPut("{candidateID}/fill-the-form")]
        public IActionResult UpdateCandidateUponFormFilling(CandidateFormModel candidate)        {
            CandidateCRUD candidateCRUD = new CandidateCRUD();
            if (candidate.CandidateDTO.ID <= 0 || candidateCRUD.SelectByID((int)candidate.CandidateDTO.ID) == null)
            {
                return new NotFoundResult();
            }
            if (candidate.CandidatePersonalInfoDTO.MaritalStatus == null || candidate.CandidatePersonalInfoDTO.ITExperience == null ||
                candidate.CandidatePersonalInfoDTO.Education == null || candidate.CandidatePersonalInfoDTO.Expectations == null || 
                candidate.CandidatePersonalInfoDTO.WorkPlace == null || candidate.CandidatePersonalInfoDTO.InfoSourse == null ||
                candidate.CandidatePersonalInfoDTO.Hobbies == null)
            {
                return BadRequest("Fields missing");
            }
            _tmpCandidate.UpdateCandidateInfo(candidate.CandidateDTO, candidate.CandidatePersonalInfoDTO);

            return new OkResult();
        }
    }
}


