﻿using System;
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
        private AdminRoleLogic _admin = new AdminRoleLogic();        private PhoneOperatorRoleLogic _phoneOperator = new PhoneOperatorRoleLogic();

        [Authorize(Roles = "Manager, Phone Operator")]
        [HttpGet]
        public IActionResult CreateInterview(InterviewsInputModel interview) 
        {
            if( new UserCRUD().SelectByID((int)interview.UserID).ID == null)
            {
                return new NotFoundObjectResult("User not found");
            }
            if (new CandidateCRUD().SelectByID((int)interview.InterviewDTO.CandidateID).ID == null)
            {
                return new NotFoundObjectResult("Candidate not found");
            }
            if (new InterviewStatusCRUD().SelectByID((int)interview.InterviewDTO.InterviewStatusID).ID == null)
            {
                return new NotFoundObjectResult("Interview Status not found");
            }
            if ((interview.InterviewDTO.Attempt != null &&
                interview.InterviewDTO.DateTimeInterview != null))
            {
                _phoneOperator.ScheduleInterview(interview.InterviewDTO, (int)interview.UserID, (int)interview.StageID, interview.FeedbackDTO);
                    return Ok();
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
