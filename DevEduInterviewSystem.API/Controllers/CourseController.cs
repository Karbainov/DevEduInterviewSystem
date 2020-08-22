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
    public class CourseController : Controller
    {
        private AdminRoleLogic _admin = new AdminRoleLogic();

        [HttpPost("Course")]
        public IActionResult AddCourse(CourseDTO course)
        {
            if (course.Name == null)
            {
                return BadRequest("Name field missing");
            }
            _admin.AddCourse(course);
            return new OkResult();
        }
    }
}