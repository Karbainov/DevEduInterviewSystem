using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        [Authorize(Roles = "Manager")]
        [Authorize(Roles = "Teacher")]
        [Authorize(Roles = "Phone Operator")]
        [HttpGet("Interviews")]
        public IActionResult GetInterviews(int? userID, DateTime? startDateTime, 
            DateTime? finishDateTime, DateTime? dateTime) 
        {
            if (new UserCRUD().SelectByID((int)userID) == null && userID != null)
            {
                return new NotFoundObjectResult("User not found");
            }

            List<InterviewDTO> interviews = _teacherRoleLogic.GetInterviews(userID, startDateTime, finishDateTime, dateTime);

            return new JsonResult(interviews);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("Interviews")]
        public IActionResult ChangeInterviewsLimit(int? number) 
        {
            if (number == null)
            {
                return BadRequest();
            }

            _admin.ChangeNumberOfInterviewsInOnePeriod((int)number);

            return new OkResult();
        }
    }
}
