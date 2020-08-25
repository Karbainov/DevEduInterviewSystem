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

        [Authorize(Roles = "Teacher, Manager")]
        [HttpGet]
        public IActionResult GetAllHomework()
        {
            HomeworkCRUD homework = new HomeworkCRUD();
            List<HomeworkDTO> h = homework.SelectAll();
            return Ok(h);
        }

        [Authorize(Roles = "Teacher, Manager")]
        [HttpGet("homework-of-candidate/{candidateID}")]
        public IActionResult GetHomeworkOfCandidate(int candidateID)
        {
            HomeworkCRUD homework = new HomeworkCRUD();
            return Ok(homework.SelectByID(candidateID));
        }

        [Authorize(Roles = "Teacher")]
        [HttpPut("update-homework-after-done")]
        public IActionResult UpdateHomeworkAfterDoneHomework(HomeworkInputModel homeworkInputModel)
        {
            if (new HomeworkCRUD().SelectByID((int)homeworkInputModel.HomeworkDTO.ID) == null)
            {
                return NotFound("This homework not found");
            }
            if (new HomeworkStatusCRUD().SelectByID((int)homeworkInputModel.HomeworkDTO.HomeworkStatusID) == null)
            {
                return NotFound("This status homework not found");
            }
            if (new TestStatusCRUD().SelectByID((int)homeworkInputModel.HomeworkDTO.TestStatusID) == null)
            {
                return NotFound("This test status not found");
            }
            _teacher.UpdateHomeworkAfterDoneHomework(homeworkInputModel.HomeworkDTO, homeworkInputModel.FeedbackDTO);
            return Ok();
        }

        [Authorize(Roles = "Teacher, Manager")]
        [HttpGet("get-all-overdue-homework")]
        public IActionResult GetAllOverdueHomework()
        {
           return Ok(_teacher.GetAllOverdueHomework());
        }
    }
}
