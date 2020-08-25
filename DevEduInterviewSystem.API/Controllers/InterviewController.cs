using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevEduInterviewSystem.API.Models.Input;
using DevEduInterviewSystem.BLL;
using DevEduInterviewSystem.DAL.DTO;
using DevEduInterviewSystem.DAL.StoredProcedures.CRUD;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevEduInterviewSystem.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InterviewController : Controller
    {
        private PhoneOperatorRoleLogic _phoneOperator = new PhoneOperatorRoleLogic();
        private TeacherRoleLogic _teacherRoleLogic = new TeacherRoleLogic();
        private ManagerRoleLogic _manager = new ManagerRoleLogic();
        private AdminRoleLogic _admin = new AdminRoleLogic();

        [Authorize(Roles = "Manager, Teacher, Phone Operator")]
        [HttpGet]
        public IActionResult GetInterviews(InterviewsInputModel interview) 
        {

            if (new UserCRUD().SelectByID((int)interview.UserID) == null && interview.UserID != null)
            {
                return new NotFoundObjectResult("User not found");
            }

            List<InterviewDTO> interviews = _teacherRoleLogic.GetInterviews(interview.UserID, interview.StartDateTime, 
                interview.FinishDateTime, interview.DateTimeInterview);

            return Ok(interviews);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("limit")]
        public IActionResult ChangeInterviewsLimit(int number) 
        {
            _admin.ChangeNumberOfInterviewsInOnePeriod(number);

            return new OkResult();
        }
    }
}
