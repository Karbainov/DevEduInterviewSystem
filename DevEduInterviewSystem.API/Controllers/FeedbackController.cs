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

        [HttpGet("all")]
        public IActionResult GetAllFeedbacks()
        {
            List<FeedbackDTO> listFeedback = new List<FeedbackDTO>();
            listFeedback = _manager.GetAllFeedbacks();
            return  Ok(listFeedback);
        }

        [HttpGet("all-by-user/{userID}")]
        public IActionResult GetAllFeedbacksByUser(int userID)
        {
            if (new UserCRUD().SelectByID(userID).ID == null)
            {
                return NotFound("User not found");
            }
            List<AllFeedbackByUserDTO> listFeedback = new List<AllFeedbackByUserDTO>();
            listFeedback = _manager.GetAllFeedbacksByUser(userID);
            return Ok(listFeedback);
        }

        [HttpGet("all-by-candidate/{candidateID}")]
        public IActionResult AllFeedbacksByCandidate(int candidateID)
        {
            if(new CandidateCRUD().SelectByID(candidateID).ID == null )
            {
                return NotFound("Candidate not found");
            }
            List<AllFeedbackByCandidateDTO> listFeedback = new List<AllFeedbackByCandidateDTO>();
            listFeedback = _manager.GetAllFeedbacksByCandidate(candidateID);
            return new OkObjectResult(listFeedback);
        }


        [HttpPost]
        public IActionResult CreateFeedback(FeedbackDTO feedbackDTO)
        {

            if (new StageChangedCRUD().SelectByID((int)feedbackDTO.StageChangedID).ID == null)
            {
                return  NotFound("StageChangedID not found");
            }
            if (new UserCRUD().SelectByID((int)feedbackDTO.UserID).ID == null)
            {
                return  NotFound("User not found");
            }
            if (feedbackDTO.Message != null)
            {
                feedbackDTO.TimeFeedback = DateTime.Now;
                _teacher.AddFeedback(feedbackDTO);
                return  Ok();
            }
            else
            {
                return BadRequest("Field Message missing");
            }
        }

        [HttpPut]
        public IActionResult ChangeFeedback(FeedbackInputModel feedbackInputModel)
        {
            if(new FeedbackCRUD().SelectByID((int)feedbackInputModel.feedbackDTO.ID) == null)
            {
                return NotFound("Feedback not found");
            }
            if (new StageChangedCRUD().SelectByID((int)feedbackInputModel.feedbackDTO.StageChangedID).ID == null)
            {
                return NotFound("StageChangedID not found");
            }
            if (feedbackInputModel.feedbackDTO.Message != null)
            {
                feedbackInputModel.feedbackDTO.TimeFeedback = DateTime.Now;
                _teacher.UpdateFeedback(feedbackInputModel.feedbackDTO);
                return  Ok();
            }
            else
            {
                return BadRequest("Field Message missing");
            }      
        }
    }
}
