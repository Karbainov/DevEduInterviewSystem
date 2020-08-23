using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevEduInterviewSystem.API.Models.Input;
using DevEduInterviewSystem.BLL;
using DevEduInterviewSystem.DAL.DTO;
using DevEduInterviewSystem.DAL.DTO.QueryDTO;
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

        [HttpGet("all-feedbacks")]
        public IActionResult GetAllFeedbacks()
        {
            List<FeedbackDTO> listFeedback = new List<FeedbackDTO>();
            listFeedback = _manager.GetAllFeedbacks();
            return new OkObjectResult(listFeedback);
        }

        [HttpGet("all-feedbacks-By-User/{userID}")]
        public IActionResult GetAllFeedbacksByUser(int userID)
        {
            List<AllFeedbackByUserDTO> listFeedback = new List<AllFeedbackByUserDTO>();
            listFeedback = _manager.GetAllFeedbacksByUser(userID);
            return new OkObjectResult(listFeedback);
        }


        [HttpPost]
        public IActionResult CreateFeedback(FeedbackDTO feedbackDTO)
        {

            if (new StageChangedCRUD().SelectByID((int)feedbackDTO.StageChangedID) == null)
            {
                return new NotFoundObjectResult("StageChangedID not found");
            }
            if (new UserCRUD().SelectByID((int)feedbackDTO.UserID) == null)
            {
                return  BadRequest("User not found");

            }
            if (feedbackDTO.Message != null)
            {
                feedbackDTO.TimeFeedback = DateTime.Now;
                _teacher.AddFeedback(feedbackDTO);
                return new OkResult();
            }
            else
            {
                return BadRequest("Field missing");
            }
        }

        [HttpPut]
        public IActionResult ChangeFeedback(FeedbackInputModel feedbackInputModel)
        {
            if(new FeedbackCRUD().SelectByID((int)feedbackInputModel.feedbackDTO.ID) == null)
            {
                return new NotFoundObjectResult("Feedback not found");
            }
            if (new StageChangedCRUD().SelectByID((int)feedbackInputModel.feedbackDTO.StageChangedID) == null)
            {
                return new NotFoundObjectResult("StageChangedID not found");
            }
            if (feedbackInputModel.feedbackDTO.Message != null)
            {
                feedbackInputModel.feedbackDTO.TimeFeedback = DateTime.Now;
                _teacher.UpdateFeedback(feedbackInputModel.feedbackDTO);
                return new OkResult();
            }
            else
            {
                return BadRequest("Field missing");
            }      
        }


    }
}
