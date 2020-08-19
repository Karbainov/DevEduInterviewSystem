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
    public class CandidateController : Controller
    {
        private PhoneOperatorRoleLogic _phoneOperator = new PhoneOperatorRoleLogic();
        private TeacherRoleLogic _teacher = new TeacherRoleLogic();
        private ManagerRoleLogic _manager = new ManagerRoleLogic();
        [HttpPost]  // manager and  phone operator
        public IActionResult AddCandidate(AddCandidateInoutModel candidateInoutModel)  
        {
            if( new CityCRUD().SelectByID(candidateInoutModel.CandidateDTO.CityID) == null)
            {
                return new NotFoundObjectResult("City not found");
            }

            if( new CourseCRUD().SelectByID((int)candidateInoutModel.CourseID) == null)
            {
                return new NotFoundObjectResult("Course not found");
            }

            if((candidateInoutModel.CandidateDTO.FirstName != null || candidateInoutModel.CandidateDTO.LastName != null ) &&
                candidateInoutModel.CandidateDTO.Phone != null &&
                candidateInoutModel.CandidateDTO.CityID != null &&
                candidateInoutModel.CourseID != null)
            {
              
                _phoneOperator.AddCandidate(candidateInoutModel.CandidateDTO, (int)candidateInoutModel.CourseID);
                return Ok();
            }
            else
            {
                return BadRequest("Fields missing");
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new AddCandidateInoutModel() { CandidateDTO = new CandidateDTO() { FirstName = "Vasa", LastName = "Pupkin", Phone = "123123454", CityID = 1 }, CourseID = 1 });
            
        }


       
    }
}

