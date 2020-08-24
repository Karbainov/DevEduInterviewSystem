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

namespace DevEduInterviewSystem.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StageController : Controller
    {
        private AdminRoleLogic _admin = new AdminRoleLogic();

        [HttpPost("Stage")]
        public IActionResult AddStage(StageDTO stage) //Почему нет update
        {
            if (stage.Name == null)
            {
                return BadRequest("Name field missing");
            }
            _admin.AddStage(stage);
            return new OkResult();
        }
    }
}