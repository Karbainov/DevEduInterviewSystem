using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevEduInterviewSystem.API.Models.Input;
using DevEduInterviewSystem.BLL;
using DevEduInterviewSystem.DAL.DTO;
using DevEduInterviewSystem.DAL.DTO.QueryDTO;
using DevEduInterviewSystem.DAL.StoredProcedures;
using DevEduInterviewSystem.DAL.StoredProcedures.CRUD;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevEduInterviewSystem.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TaskController : Controller
    {
        private ManagerRoleLogic _manager = new ManagerRoleLogic();

        [Authorize(Roles = "Manager, Teacher, PhoneOperator")]
        [HttpPost]
        public IActionResult AddTask(TaskDTO task)
        {
            if (task.CandidateID == null)
            {
                return BadRequest("Candidate field missing");
            }
            if (task.Message == null)
            {
                return BadRequest("Message field missing");
            }
            if (new CandidateCRUD().SelectByID((int)task.CandidateID).ID == null)
            {
                return NotFound();
            }
            if( new UserCRUD().SelectByID((int)task.UserID).ID == null)
            {
                return NotFound();
            }
            _manager.AddTask(task);
            return Ok();
        }
        [Authorize(Roles = "Manager, Teacher, PhoneOperator")]
        [HttpPut]
        public IActionResult UpdateTask(TaskDTO task)
        {
            if(new TaskCRUD().SelectByID((int)task.ID).ID == null)
            {
                return NotFound();
            }
            if (new CandidateCRUD().SelectByID((int)task.CandidateID).ID == null)
            {
                return NotFound();
            }
            _manager.UpdateTask(task);
            return Ok();
        }
        [Authorize(Roles = "Manager, Teacher, PhoneOperator")]
        [HttpGet("{userID}")]
        public IActionResult GetTasks(int userID)
        {
            if (new UserCRUD().SelectByID(userID).ID == null)
            {
                return NotFound();
            }
      
            return Ok(_manager.SelectAllTasksByUser(userID));
        }

    }
}



   

        
        

        

    