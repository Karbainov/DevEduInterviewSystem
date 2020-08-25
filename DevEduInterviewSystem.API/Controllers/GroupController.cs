using DevEduInterviewSystem.API.Models.Input;
using DevEduInterviewSystem.BLL;
using DevEduInterviewSystem.DAL.DTO;
using DevEduInterviewSystem.DAL.StoredProcedures.CRUD;
using Microsoft.AspNetCore.Authorization;
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
        private AdminRoleLogic _admin = new AdminRoleLogic();

        [Authorize(Roles = "Manager, Teacher")]
        [HttpGet("all-groups")]
        public IActionResult GetAllGroup()
        {
            GroupCRUD groupCRUD = new GroupCRUD();
            List<GroupDTO> groups = groupCRUD.SelectAll();
            return new OkObjectResult(groups);
        }


        [Authorize(Roles = "Manager")]
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


        [Authorize(Roles = "Manager")]
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

        [Authorize(Roles = "Manager")]
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
        // TODO: Возможно логично дописать в роль показ всех ранее удаленных групп.

        [Authorize(Roles = "Manager")]
        [HttpPut("update-group-by-candidateID")]
        public IActionResult UpdateGroupByCandidate(GroupCandidateDTO groupCandidateDTO)
        {
            int? groupID = groupCandidateDTO.GroupID;
            int? candidateID = groupCandidateDTO.CandidateID;
            if (new CandidateCRUD().SelectByID((int)candidateID).ID == null)
            {
                return new NotFoundObjectResult("candidate not found");
            }
            if (new GroupCRUD().SelectByID((int)groupID).ID == null)
            {
                return new NotFoundObjectResult("group not found");
            }
            _manager.UpdateGroupByCandidate(groupCandidateDTO);

            return Ok();
        }



        [HttpPut("add-candidate")]
        public IActionResult AddCandidateToGroup(GroupInputModel groupModel)
        {
            if( new CandidateCRUD().SelectByID(groupModel.CandidateID).FirstName == null)
            {
                return NotFound("candidate not found");
            }

            if(new GroupCRUD().SelectByID(groupModel.GroupID).Name == null)
            {
                return NotFound("group not found");
            }

            if (new StageCRUD().SelectByID(groupModel.StageID).Name == null)
            {
                return NotFound("Stage not found");
            }


            if (new CourseCRUD().SelectByID(groupModel.CourseID).Name == null)
            {
                return NotFound("Course not found");
            }

            _manager.AddCandidateToGroup(groupModel.CandidateID,groupModel.GroupID,groupModel.StageID, groupModel.feedbackDTO);

            return Ok();
        }

        //[Authorize(Roles = "Admin, Manager")]
        //[HttpGet("all-deleted-groups")]
        //public IActionResult GetAllDeletedGroups()
        //{
           
        //}
    }
    
}
