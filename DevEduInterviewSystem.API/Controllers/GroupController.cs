using DevEduInterviewSystem.BLL;
using DevEduInterviewSystem.DAL.DTO;
using DevEduInterviewSystem.DAL.StoredProcedures.CRUD;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevEduInterviewSystem.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GroupController : Controller
    {
        private TeacherRoleLogic _teacher = new TeacherRoleLogic();
        private ManagerRoleLogic _manager = new ManagerRoleLogic();

        [HttpGet("all-groups")]
        public IActionResult GetAllGroup()
        {
            GroupCRUD groupCRUD = new GroupCRUD();
            List<GroupDTO> groups = groupCRUD.SelectAll();
            return new OkObjectResult(groups);
        }
        [HttpPost("add-group")]
        public IActionResult AddGroup(GroupDTO groupDTO)
        {
            if (new GroupCRUD().SelectByID((int)groupDTO.CourseID) == null)
            {
                return new NotFoundObjectResult("Group not found");
            }
            if (groupDTO.Name == null)
            {
                return BadRequest("Name field missing");
            }
            _manager.CreateGroup(groupDTO);
            return new OkResult();
        }
        [HttpPut("update-group")]
        public IActionResult UpdateGroup(GroupDTO groupDTO)
        {
            if (new GroupCRUD().SelectByID((int)groupDTO.CourseID) == null)
            {
                return new NotFoundObjectResult("Group not found");
            }
            _manager.UpdateGroup(groupDTO);
            return new OkResult();
        }

    }
    
}
