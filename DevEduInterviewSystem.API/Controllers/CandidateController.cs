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
            if (new CityCRUD().SelectByID((int)candidateInputModel.CandidateDTO.CityID).ID == null)
            {
                return NotFound("City not found");
            }
            if (new CourseCRUD().SelectByID((int)candidateInputModel.CourseID).ID == null)
            {
                return NotFound("Course not found");
            }
            if ((candidateInputModel.CandidateDTO.FirstName != null
                || candidateInputModel.CandidateDTO.LastName != null)
                && candidateInputModel.CandidateDTO.Phone != null
                && candidateInputModel.CandidateDTO.CityID > 0
                && candidateInputModel.CourseID != null)
            {
                candidateInputModel.CandidateDTO.BirthDay = DateTime.Now;
                _phoneOperator.AddCandidate(candidateInputModel.CandidateDTO, (int)candidateInputModel.CourseID);
                return  Ok();
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
                return NotFound();
            }
        }

        [Authorize(Roles = "Manager")]
        [HttpPut("{candidateID}")]
        public IActionResult UpdateCandidate(CandidateInputModel candidateInputModel)
        {
            if(new CandidateCRUD().SelectByID((int)candidateInputModel.CandidateDTO.ID).ID != null)
            {
                _manager.UpdateCandidate(candidateInputModel.CandidateDTO);
                return Ok();
            }
            else
            {
                return NotFound();
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
                return NotFound("candidate not found");
            }
            if (new CourseCRUD().SelectByID((int)courseID).ID == null)
            {
                return NotFound("group not found");
            }
            _manager.UpdateCourseByCandidate(course_CandidateDTO);

            return Ok();

        }

        
        [Authorize(Roles = "Manager, Teacher")]
        [HttpPut("update-candidate-after-interview")]
        public IActionResult UpdateCandidateAfterInterview            (UpdateCandidateAfterInterviewModel updateCandidateAfterInterviewModel)        {            if (updateCandidateAfterInterviewModel.CourseID == null)            {                return NotFound("Course not found");            }            if (updateCandidateAfterInterviewModel.CandidateDTO.ID == null)            {                return NotFound("Candidate not found");            }            if (updateCandidateAfterInterviewModel.CandidateDTO.StatusID == null)            {                return NotFound("Status not found");            }            if (updateCandidateAfterInterviewModel.interviewDTO.InterviewStatusID == null)            {                return NotFound("Interview not found");            }            if (updateCandidateAfterInterviewModel.feedbackDTO.StageChangedID == null)            {                return NotFound("Stage not found");            }
            _teacher.UpdateCandidateAfterInterview(updateCandidateAfterInterviewModel.CandidateDTO,                updateCandidateAfterInterviewModel.interviewDTO,                (int)updateCandidateAfterInterviewModel.CourseID,                updateCandidateAfterInterviewModel.feedbackDTO);            return Ok();        }

        [Authorize(Roles = "CandidateTMP")]
        [HttpPut("{candidateID}/fill-the-form")]
        public IActionResult UpdateCandidateUponFormFilling(CandidateFormModel candidate)        {
            if (new CandidateCRUD().SelectByID((int)candidate.CandidateDTO.ID).ID == null)
            {
                return NotFound();
            }
            if (candidate.CandidatePersonalInfoDTO.MaritalStatus == null || candidate.CandidatePersonalInfoDTO.ITExperience == null ||
                candidate.CandidatePersonalInfoDTO.Education == null || candidate.CandidatePersonalInfoDTO.Expectations == null || 
                candidate.CandidatePersonalInfoDTO.WorkPlace == null || candidate.CandidatePersonalInfoDTO.InfoSourse == null ||
                candidate.CandidatePersonalInfoDTO.Hobbies == null)
            {
                return BadRequest("Fields missing");
            }
            _tmpCandidate.UpdateCandidateInfo(candidate.CandidateDTO, candidate.CandidatePersonalInfoDTO);

            return Ok();
        }
    }
}


