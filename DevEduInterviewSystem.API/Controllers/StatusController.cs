using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevEduInterviewSystem.API.Models.Input;
using DevEduInterviewSystem.BLL;
using DevEduInterviewSystem.DAL.DTO;
using DevEduInterviewSystem.DAL.StoredProcedures.CRUD;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace DevEduInterviewSystem.API.Controllers
{
    
    [Route("[controller]")]
    [ApiController]
    public class StatusController : Controller
    {
        private AdminRoleLogic _admin = new AdminRoleLogic();

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult AddStatus(StatusDTO status)
        {
            if (status.Name == null)
            {
                return BadRequest("Name field missing");
            }
            _admin.AddStatus(status);
            return new OkResult();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("all")]
        public IActionResult GetAllStatus()
        {
            List<StatusDTO> status = new StatusCRUD().SelectAll();
            return new ObjectResult(status);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("delete/{statusID}")]
        public IActionResult DeleteStage(int statusID)
        {
            if (new StatusCRUD().SelectByID(statusID) == null)
            {
                return new NotFoundObjectResult("Status not found");
            }
            _admin.DeleteStatus(statusID);
            return Ok();
        }
    }
}