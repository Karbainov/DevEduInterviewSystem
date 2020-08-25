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

        [Authorize(Roles = "Manager, Teacher")]
        [HttpGet("all-groups")]
        public IActionResult GetAllGroup()
        {
            GroupCRUD groupCRUD = new GroupCRUD();
            List<GroupDTO> groups = groupCRUD.SelectAll();
            return Ok(groups);
        }


        [Authorize(Roles = "Manager")]
        [HttpPost("add-group")]
        public IActionResult AddGroup(GroupDTO groupDTO)
        {
            if (new CourseCRUD().SelectByID((int)groupDTO.CourseID).ID == null)
            {
                return NotFound("Course not found");
            }
            if (groupDTO.Name == null)
            {
                return BadRequest("Name field missing");
            }
            _manager.CreateGroup(groupDTO);
            return  Ok();
        }


        [Authorize(Roles = "Manager")]
        [HttpPut("update-group")]
        public IActionResult UpdateGroup(GroupDTO groupDTO)
        {
            if (groupDTO.Name == null)
            {
                return BadRequest("Name field missing");
            }
            if (new GroupCRUD().SelectByID((int)groupDTO.ID).ID == null)
            {
                return NotFound("Group not found");
            }
            if (new CourseCRUD().SelectByID((int)groupDTO.ID).ID == null)
            {
                return NotFound("Course not found");
            }
            _manager.UpdateGroup(groupDTO);
            return Ok();
        }

        [Authorize(Roles = "Manager")]
        [HttpDelete("delete-group/{groupID}")]
        public IActionResult DeleteGroup(int groupID)
        {
            if (new GroupCRUD().SelectByID(groupID) == null)
            {
                return NotFound("Group not found");
            }
            _manager.DeleteGroup(groupID);
            return Ok();
        }
        

        [Authorize(Roles = "Manager")]
        [HttpPut("update-group-by-candidateID")]
        public IActionResult UpdateGroupByCandidate(GroupCandidateDTO groupCandidateDTO)
        {
            int? groupID = groupCandidateDTO.GroupID;
            int? candidateID = groupCandidateDTO.CandidateID;
            if (new CandidateCRUD().SelectByID((int)candidateID).ID == null)
            {
                return NotFound("Candidate not found");
            }
            if (new GroupCRUD().SelectByID((int)groupID).ID == null)
            {
                return  NotFound("Group not found");
            }
            _manager.UpdateGroupByCandidate(groupCandidateDTO);

            return Ok();
        }

        [Authorize(Roles = "Manager")]
        [HttpPut("add-candidate")]
        public IActionResult AddCandidateToGroup(GroupInputModel groupModel)
        {
            if( new CandidateCRUD().SelectByID(groupModel.CandidateID).ID == null)
            {
                return NotFound("Candidate not found");
            }

            if(new GroupCRUD().SelectByID(groupModel.GroupID).ID == null)
            {
                return NotFound("Group not found");
            }

            if (new StageCRUD().SelectByID(groupModel.StageID).ID == null)
            {
                return NotFound("Stage not found");
            }

            if (new CourseCRUD().SelectByID(groupModel.CourseID).ID == null)
            {
                return NotFound("Course not found");
            }

            _manager.AddCandidateToGroup(groupModel.CandidateID,groupModel.GroupID,groupModel.StageID, groupModel.feedbackDTO);

            return Ok();
        }

    }
    
}
