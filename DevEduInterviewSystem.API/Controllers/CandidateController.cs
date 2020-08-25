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
        
        [Authorize(Roles = "Manager, Phone Operator")]
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

    

        [Authorize(Roles = "Manager, Teacher")]
        [HttpGet("{candidateID}")]
        public IActionResult AllInformationAboutCandidate(int candidateID)
        {
            if (new CandidateCRUD().SelectByID(candidateID) != null)
            {
                AllInformationAboutTheCandidateByIDDTO infoCandidate = _manager.AllInformationAboutCandidate(candidateID);
                return Ok(infoCandidate);
            }
            else
            {
                return new NotFoundResult();
            }
        }

        [Authorize(Roles = "Manager")]
        [HttpPut("{candidateID}")]
        public IActionResult UpdateCandidate(CandidateInputModel candidateInputModel)
        {
            if(new CandidateCRUD().SelectByID((int)candidateInputModel.CandidateDTO.ID) != null)
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

        
        [Authorize(Roles = "Manager, Teacher")]
        [HttpPut("update-candidate-after-interview")]
        public IActionResult UpdateCandidateAfterInterview            (UpdateCandidateAfterInterviewModel updateCandidateAfterInterviewModel)        {            if (updateCandidateAfterInterviewModel.CourseID == null)            {                return new NotFoundResult();            }            if (updateCandidateAfterInterviewModel.interviewDTO.InterviewStatusID == null)            {                return new NotFoundResult();            }            if (updateCandidateAfterInterviewModel.CandidateDTO.ID == null)            {                return new NotFoundResult();            }            if (updateCandidateAfterInterviewModel.CandidateDTO.StatusID == null)            {                return new NotFoundResult();            }            if (updateCandidateAfterInterviewModel.interviewDTO.InterviewStatusID == null)            {                return new NotFoundResult();            }            if (updateCandidateAfterInterviewModel.feedbackDTO.StageChangedID == null)            {                return new NotFoundResult();            }
            _teacher.UpdateCandidateAfterInterview(updateCandidateAfterInterviewModel.CandidateDTO,                updateCandidateAfterInterviewModel.interviewDTO,                (int)updateCandidateAfterInterviewModel.CourseID,                updateCandidateAfterInterviewModel.feedbackDTO);            return new OkResult();        }

        [Authorize(Roles = "CandidateTMP")]
        [HttpPut("{candidateID}/fill-the-form")]
        public IActionResult UpdateCandidateUponFormFilling(CandidateFormModel candidate)        {
            if (candidate.CandidateDTO.ID <= 0 || new CandidateCRUD().SelectByID((int)candidate.CandidateDTO.ID) == null)
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


