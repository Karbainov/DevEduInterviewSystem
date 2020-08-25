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
    public class CourseController : Controller
    {
        private AdminRoleLogic _admin = new AdminRoleLogic();
        [Authorize(Roles = "Admin")]
        [HttpPost("add")]
        public IActionResult AddCourse(CourseDTO course)
        {
            if (course.Name == null)
            {
                return BadRequest("Name field missing");
            }
            _admin.AddCourse(course);
            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("delete/{courseID}")]
        public IActionResult DeleteCourse(int courseID)
        {
            if (new CourseCRUD().SelectByID(courseID).ID == null)
            {
                return NotFound("Course not found");
            }
            List<Course_CandidateDTO> candidates = new Course_CandidateCRUD().SelectAll();
            foreach (Course_CandidateDTO c in candidates)
            {
                if ((int)c.CourseID == courseID)
                {
                    return BadRequest(new { errorText = "Course is used" });
                }
            }
            List<GroupDTO> group = new GroupCRUD().SelectAll();
            foreach (GroupDTO g in group)
            {
                if ((int)g.CourseID == courseID)
                {
                    return BadRequest(new { errorText = "Course is used" });
                }
            }
            _admin.DeleteCourse(courseID);
            return Ok();
        }
    }
}