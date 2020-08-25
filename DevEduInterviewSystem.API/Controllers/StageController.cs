using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevEduInterviewSystem.API.Models.Input;
using DevEduInterviewSystem.BLL;
using DevEduInterviewSystem.DAL.DTO;
using DevEduInterviewSystem.DAL.StoredProcedures.CRUD;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevEduInterviewSystem.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StageController : Controller
    {
        private AdminRoleLogic _admin = new AdminRoleLogic();

        [Authorize(Roles = "Admin")]
        [HttpPost("Stage")]
        public IActionResult AddStage(StageDTO stage)
        {
            if (stage.Name == null)
            {
                return BadRequest("Name field missing");
            }
            _admin.AddStage(stage);
            return  Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("all")]
        public IActionResult GetAllStage()
        {
            List<StageDTO> stages = new StageCRUD().SelectAll();
            return  Ok(stages);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("delete/{stageID}")]
        public IActionResult DeleteStage(int stageID)
        {
            if (new StageCRUD().SelectByID(stageID).Name == null)
            {
                return NotFound("Stage not found");
            }
            List<CandidateDTO> candidates = new CandidateCRUD().SelectAll();
            List<StageChangedDTO> stages = new StageChangedCRUD().SelectAll();
            foreach (StageChangedDTO s in stages)
            {
                if ((int)s.StageID == stageID)
                {
                    return BadRequest(new { errorText = "Stage is used" });
                }
            }
            foreach (CandidateDTO c in candidates)
            {
                if ((int)c.StageID == stageID)
                {
                    return BadRequest(new { errorText = "Stage is used" });
                }
            }
            _admin.DeleteStage(stageID);
            return Ok();
        }

    }
}