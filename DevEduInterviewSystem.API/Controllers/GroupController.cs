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
            if (new CourseCRUD().SelectByID((int)groupDTO.CourseID) == null)
            {
                return new NotFoundObjectResult("Course not found");
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
            if (groupDTO.Name == null)
            {
                return BadRequest("Name field missing");
            }
            if (new GroupCRUD().SelectByID((int)groupDTO.ID) == null)
            {
                return new NotFoundObjectResult("Group not found");
            }
            if (new CourseCRUD().SelectByID((int)groupDTO.ID) == null)
            {
                return new NotFoundObjectResult("Course not found");
            }
            _manager.UpdateGroup(groupDTO);
            return new OkResult();
        }

        [HttpDelete("delete-group/{groupID}")]
        public IActionResult DeleteGroup(int groupID)
        {
            if (new GroupCRUD().SelectByID(groupID) == null)
            {
                return new NotFoundObjectResult("Group not found");
            }
            _manager.DeleteGroup(groupID);
            return new OkResult();
        }

    }
    
}
