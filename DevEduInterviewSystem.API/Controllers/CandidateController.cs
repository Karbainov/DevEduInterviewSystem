using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevEduInterviewSystem.API.Models.Input;
using DevEduInterviewSystem.BLL;
using DevEduInterviewSystem.DAL.DTO;
using DevEduInterviewSystem.DAL.DTO.QuereDTO;
using DevEduInterviewSystem.DAL.StoredProcedures.CRUD;
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
        // Manager and phoneoperator
        [HttpPost]
        public IActionResult GetAllCandidate(CandidateInputModel candidateInputModel)
        {
            if( new CityCRUD().SelectByID(candidateInputModel.CandidateDTO.CityID) == null)
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
                return BadRequest("Fields meesing");
            }
        }
        [HttpGet("k")]
        public IActionResult GetOneTimePassword()
        {
           string password =  _manager.GetOneTimePassword(); 
            return new JsonResult(password);            // ?????????????????????????????????????
        }

        [HttpGet("q")]
        public IActionResult AllInformationAboutCandidate(int candidateID)
        {
            candidateID = 68;
            AllInformationAboutTheCandidateByIDDTO w =_manager.AllInformationAboutCandidate(candidateID);
            return new JsonResult(w);                   // ?????????????????????????????????????
        }

        [HttpPut("qwer")]
        public IActionResult UpdateCandidatePersonalInfo(CandidateInputModel candidateInputModel)
        {
            _manager.UpdateCandidatePersonalInfo(candidateInputModel.CandidateDTO, candidateInputModel.CandidatePersonalInfoDTO);
            return new OkResult();
        }



        [HttpPut("rewq")]
        public IActionResult UpdateCandidate(CandidateInputModel candidateInputModel)
        {
            //if ((candidateInputModel.CandidateDTO.FirstName != null &&
            //     candidateInputModel.CandidateDTO.LastName != null &&
            //     candidateInputModel.CandidateDTO.Phone != null &&
            //     candidateInputModel.CandidateDTO.CityID > 0 &&               
            //     candidateInputModel.CandidateDTO.StageID > 0 &&
            //     candidateInputModel.CandidateDTO.StatusID > 0 &&
            //     candidateInputModel.CandidateDTO.Email != null ))
            //{
            
                _manager.UpdateCandidate(candidateInputModel.CandidateDTO);
                return new OkResult();
            //}
            //else
            //{
            //    return BadRequest("Fields meesing");
            //}
        }

        [HttpPut("update")]
        public IActionResult UpdateCandidateAfterInterview(UpdateCandidateAfterInterviewModel updateCandidateAfterInterviewModel)
        {
            if (updateCandidateAfterInterviewModel.CourseID == null)
            {
                return new NotFoundResult();
            }

            if (updateCandidateAfterInterviewModel.interviewDTO.InterviewStatusID == null)
            {
                return new NotFoundResult();
            }
            if (updateCandidateAfterInterviewModel.CandidateDTO.ID == null)
            {
                return new NotFoundResult();
            }
            if (updateCandidateAfterInterviewModel.CandidateDTO.StatusID == null)
            {
                return new NotFoundResult();
            }
            if (updateCandidateAfterInterviewModel.interviewDTO.InterviewStatusID == null)
            {
                return new NotFoundResult();
            }
            if(updateCandidateAfterInterviewModel.feedbackDTO.StageChangedID == null)
            {
                return new NotFoundResult();
            }
            _teacher.UpdateCandidateAfterInterview(updateCandidateAfterInterviewModel.CandidateDTO,
              updateCandidateAfterInterviewModel.interviewDTO,
              (int)updateCandidateAfterInterviewModel.CourseID,
              updateCandidateAfterInterviewModel.feedbackDTO);

            return new OkResult();

        }
    }
}
