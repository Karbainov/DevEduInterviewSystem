using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevEduInterviewSystem.API.Models.Input;
using DevEduInterviewSystem.BLL;
using DevEduInterviewSystem.DAL.DTO;
using DevEduInterviewSystem.DAL.DTO.QuereDTO;
using DevEduInterviewSystem.DAL.StoredProcedures.CRUD;
using DevEduInterviewSystem.DAL.StoredProcedures.Query;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevEduInterviewSystem.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private AdminRoleLogic _admin = new AdminRoleLogic();

        [Authorize(Roles = "Admin")]
        [HttpPost("add-user")]
        public IActionResult AddUser(UserInputModel user)
        {
            if (new RoleCRUD().SelectByID((int)user.RoleID).ID == null)
            {
                return new NotFoundObjectResult("Role not found");
            }
            if ((user.UserDTO.FirstName != null
                && user.UserDTO.LastName != null)
                && user.UserDTO.Password != null
                && user.RoleID != null)
            {
                user.UserDTO.IsDeleted = false;
                _admin.AddNewUser(user.UserDTO, (int)user.RoleID);
                return Ok();
            }
            else
            {
                return BadRequest("Fields missing");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{userID}/delete-user")]
        public IActionResult DeleteUser(int userID)
        {
            if ((int)userID <= 0 ||  new UserCRUD().SelectByID((int)userID).ID == null)
            {
                return NotFound("User not found");
            }

            _admin.DeleteUser((int)userID);
            return  Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("deleted-users")]
        public IActionResult RestoreUser(int? userID)
        {
            if (userID == null || userID != null && new AllDeletedUsers().SelectDeletedUserByID((int)userID).ID == null)
            {
                return NotFound("User not found");
            }

            _admin.RestoreUser((int)userID);

            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("update-user")]
        public IActionResult UpdateUser(UserDTO user)
        {
            if (new UserCRUD().SelectByID((int)user.ID).ID == null)
            {
                return NotFound("User not found");
            }

            _admin.UpdateUser(user);

            return  Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("all-users-with-role")]
        public IActionResult GetAllUsersWithRoles()
        {
            List<UsersWithRoleDTO> users = _admin.ShowAllUsersWithRoles();

            return  Ok(users);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("all-deleted-users")]
        public IActionResult GetAllDeletedUsers()
        {
            _admin.ShowDeletedUsers();

            return  Ok();
        }
        
        [HttpGet("all-users")]
        public IActionResult GetAllUsers()
        {
            List<UserDTO> allUsers = new UserCRUD().SelectAll();

            return Ok(allUsers);
        }
    }
}
