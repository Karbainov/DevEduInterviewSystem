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
            if (new CandidateCRUD().SelectByID(candidateID).ID == null)
            {
                return NotFound();
            }
            string password = _manager.GetOneTimePassword();

            List<OneTimePasswordDTO> passwords = new OneTimePasswordCRUD().SelectAll();
            foreach (OneTimePasswordDTO i in passwords)
            {
                if (i.OneTimePassword == password)
                {
                    return BadRequest("Same OneTimePassword already exists" );
                }
                if (i.CandidateID == candidateID)
                {
                    return BadRequest("This candidate already has a password" );
                }
            }

            OneTimePasswordDTO oneTimePassword = new OneTimePasswordDTO();
            oneTimePassword.CandidateID = candidateID;
            oneTimePassword.OneTimePassword = password;
            oneTimePassword.DateOfPasswordIssue = DateTime.UtcNow;
            new OneTimePasswordCRUD().Add(oneTimePassword);
            return Ok(password);
        }
    }
}
