using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevEduInterviewSystem.BLL;
using DevEduInterviewSystem.DAL.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevEduInterviewSystem.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CandidateController : Controller
    {
        private PhoneOperatorRoleLogic _phoneOperator = new PhoneOperatorRoleLogic();
        private TeacherRoleLogic _teacher = new TeacherRoleLogic();
        private ManagerRoleLogic _manager = new ManagerRoleLogic();
        [HttpPost]  // manager and  phone operator
        public IActionResult AddCandidate(CandidateDTO candidateDTO, int? courseID)  
        {
            if((candidateDTO.FirstName != null || candidateDTO.LastName != null ) &&
                candidateDTO.Phone != null &&
                candidateDTO.CityID != null &&
                courseID != null)
            {
                _phoneOperator.AddCandidate(candidateDTO, (int)courseID);
                return Ok();
            }
            else
            {
                return BadRequest("Fields missing");
            }
        }


       
    }
}

