using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevEduInterviewSystem.API.Models.Input;
using DevEduInterviewSystem.BLL;
using DevEduInterviewSystem.DAL.StoredProcedures.CRUD;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevEduInterviewSystem.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FeedbackController : Controller
    {
        private PhoneOperatorRoleLogic _phoneOperator = new PhoneOperatorRoleLogic();
        private TeacherRoleLogic _teacher = new TeacherRoleLogic();
        private ManagerRoleLogic _manager = new ManagerRoleLogic();

        [HttpPost]
        public IActionResult CreateFeedback(FeedbackInputModel feedbackInputModel)
        {
            if (new UserCRUD().SelectByID((int)feedbackInputModel.feedbackDTO.UserID) == null)
            {
                return new NotFoundObjectResult("User not found");
            }
            if (new StageChangedCRUD().SelectByID((int)feedbackInputModel.feedbackDTO.StageChangedID) == null)
            {
                return new NotFoundObjectResult("StageChangedID not found");
            }
            if (feedbackInputModel.feedbackDTO.StageChangedID > 0 &&
               feedbackInputModel.feedbackDTO.UserID > 0 &&
               feedbackInputModel.feedbackDTO.Message != null)
            {
                feedbackInputModel.feedbackDTO.TimeFeedback = DateTime.Now;
                _teacher.AddFeedback(feedbackInputModel.feedbackDTO);
                return new OkResult();
            }
            else
            {
                return BadRequest("Field meesing");
            }
        }

        //[HttpGet]
        //public IActionResult GetAllFeedback
    }
}
