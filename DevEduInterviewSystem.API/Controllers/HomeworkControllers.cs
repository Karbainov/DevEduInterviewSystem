using DevEduInterviewSystem.API.Models.Input;
using DevEduInterviewSystem.BLL;
using DevEduInterviewSystem.DAL.DTO;
using DevEduInterviewSystem.DAL.StoredProcedures.CRUD;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevEduInterviewSystem.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HomeworkControllers : Controller
    {
        private TeacherRoleLogic _teacher = new TeacherRoleLogic();
        private ManagerRoleLogic _manager = new ManagerRoleLogic();

        [HttpPut("update-homework-after-done")]
        public IActionResult UpdateHomeworkAfterDoneHomework(HomeworkInputModel homeworkInputModel)
        {
            if (new HomeworkCRUD().SelectByID((int)new HomeworkDTO().ID) == null)
            {
                return new NotFoundObjectResult("Homework not found");
            }
            if (new CandidateCRUD().SelectByID((int)homeworkInputModel.CandidateDTO.ID) == null)
            {
                return new NotFoundObjectResult("Candidate not found");
            }
            if (new HomeworkStatusDTO().ID == 1 || new TestStatusDTO().ID == 1)
            {
                return BadRequest("Homework don't done");
            }
            _teacher.UpdateHomeworkAfterDoneHomework(homeworkInputModel.CandidateDTO,
                (int)homeworkInputModel.HomeworkStatusID, (int)homeworkInputModel.TestStatusID, 
                homeworkInputModel.FeedbackDTO);   

            return new OkResult();
        }
    }
}
