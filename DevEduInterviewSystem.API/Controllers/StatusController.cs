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
    public class StatusController : Controller
    {
        private AdminRoleLogic _admin = new AdminRoleLogic();

        [HttpPost("Status")]
        public IActionResult AddStatus(StatusDTO status)
        {
            if (status.Name == null)
            {
                return BadRequest("Name field missing");
            }
            _admin.AddStatus(status);
            return new OkResult();
        }

    }
}