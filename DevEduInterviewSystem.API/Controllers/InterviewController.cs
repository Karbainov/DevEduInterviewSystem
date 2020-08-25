using System;
using System.Collections.Generic;
using DevEduInterviewSystem.API.Models.Input;
using DevEduInterviewSystem.BLL;
using DevEduInterviewSystem.DAL.DTO;
using DevEduInterviewSystem.DAL.StoredProcedures.CRUD;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevEduInterviewSystem.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InterviewController : Controller
    {
        private TeacherRoleLogic _teacherRoleLogic = new TeacherRoleLogic();
        private AdminRoleLogic _admin = new AdminRoleLogic();

        [Authorize(Roles = "Manager, Teacher, Phone Operator")]
        [HttpGet]
        public IActionResult GetInterviews(InterviewsInputModel interview) 
        {
            if( new UserCRUD().SelectByID((int)interviewsInputModel.UserID) == null)
            {
                return new NotFoundObjectResult("User not found");
            }
            if (new CandidateCRUD().SelectByID((int)interviewsInputModel.InterviewDTO.CandidateID) == null)
            {
                return new NotFoundObjectResult("Candidate not found");
            }
            if (new InterviewStatusCRUD().SelectByID((int)interviewsInputModel.InterviewDTO.InterviewStatusID) == null)
            {
                return new NotFoundObjectResult("Interview Status not found");
            }
            if ((interviewsInputModel.InterviewDTO.Attempt != null &&
                interviewsInputModel.InterviewDTO.DateTimeInterview != null))
            {
                _phoneOperator.ScheduleInterview(interviewsInputModel.InterviewDTO, (int)interviewsInputModel.UserID, (int)interviewsInputModel.StageID, interviewsInputModel.FeedbackDTO);
                    return new OkResult();
            }
            else
            {
                return BadRequest("Fields missing");
            }
        }



        [Authorize(Roles = "Teacher, Manager, PhoneOperator")]
        [HttpGet("Interviews")]

        public IActionResult GetInterviews(int? userID, DateTime? startDateTime, DateTime? finishDateTime, DateTime? dateTime) 
        {
            if (userID != null && new UserCRUD().SelectByID((int)userID) == null)
            {
                return NotFound("User not found");
            }
         
            List<InterviewDTO> interviews = _teacherRoleLogic.GetInterviews(userID, startDateTime, finishDateTime, dateTime);

            return Ok(interviews);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("limit")]
        public IActionResult ChangeInterviewsLimit(int number) 
        {
            _admin.ChangeNumberOfInterviewsInOnePeriod(number);

            return Ok();
        }
    }
}
