using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevEduInterviewSystem.API.Models.Input;
using DevEduInterviewSystem.BLL;
using DevEduInterviewSystem.DAL.DTO;
using DevEduInterviewSystem.DAL.DTO.QuereDTO;
using DevEduInterviewSystem.DAL.StoredProcedures.CRUD;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevEduInterviewSystem.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OneTimePasswordController : Controller
    {
        private ManagerRoleLogic _manager = new ManagerRoleLogic();

        [Authorize(Roles = "Manager")]
        [HttpGet("{candidateID}/one-time-password")]
        public IActionResult AddOneTimePassword(int candidateID)
        {
            string password = null;
            if (new CandidateCRUD().SelectByID(candidateID) == null)
            {
                return NotFound();
            }
            password = _manager.GetOneTimePassword();

            List<OneTimePasswordDTO> passwords = new OneTimePasswordCRUD().SelectAll();
            foreach (OneTimePasswordDTO i in passwords)
            {
                if (i.OneTimePassword == password)
                {
                    return BadRequest(new { errorText = "Same OneTimePassword already exists" });
                }
                if (i.CandidateID == candidateID)
                {
                    return BadRequest(new { errorText = "This candidate already has a password" });
                }
            }

            OneTimePasswordDTO otp = new OneTimePasswordDTO();
            otp.CandidateID = candidateID;
            otp.OneTimePassword = password;
            otp.DateOfPasswordIssue = DateTime.UtcNow;
            _manager.AddOneTimePassword(otp);
            return Ok();
        }
    }
}
