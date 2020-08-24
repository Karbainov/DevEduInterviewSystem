using DevEduInterviewSystem.API.Models.Input;
using DevEduInterviewSystem.BLL;
using DevEduInterviewSystem.DAL.DTO;
using DevEduInterviewSystem.DAL.StoredProcedures.CRUD;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevEduInterviewSystem.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HomeworkController : Controller
    {
        private TeacherRoleLogic _teacher = new TeacherRoleLogic();

        [Authorize(Roles = "Teacher")]
        [HttpGet]
        public IActionResult GetAllHomework()
        {
            HomeworkCRUD homework = new HomeworkCRUD();
            List<HomeworkDTO> h = homework.SelectAll();
            return new OkObjectResult(h);
        }

        [Authorize(Roles = "Teacher")]
        [HttpGet("homework-of-candidate/{candidateID}")]
        public IActionResult GetHomeworkOfCandidate(int candidateID)
        {
            HomeworkCRUD homework = new HomeworkCRUD();
            return new OkObjectResult(homework.SelectByID(candidateID));
        }

        [Authorize(Roles = "Teacher")]
        [HttpPut("update-homework-after-done")]
        public IActionResult UpdateHomeworkAfterDoneHomework(HomeworkInputModel homeworkInputModel)
        {
            if (new HomeworkCRUD().SelectByID((int)homeworkInputModel.HomeworkDTO.ID) == null)
            {
                return new NotFoundObjectResult("This homework not found");
            }
            if (new HomeworkStatusCRUD().SelectByID((int)homeworkInputModel.HomeworkDTO.HomeworkStatusID) == null)
            {
                return new NotFoundObjectResult("This status homework not found");
            }
            if (new TestStatusCRUD().SelectByID((int)homeworkInputModel.HomeworkDTO.TestStatusID) == null)
            {
                return new NotFoundObjectResult("This test status not found");
            }
            _teacher.UpdateHomeworkAfterDoneHomework(homeworkInputModel.HomeworkDTO, homeworkInputModel.FeedbackDTO);
            return new OkResult();
        }

    }
}
