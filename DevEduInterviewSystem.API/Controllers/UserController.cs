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
        private PhoneOperatorRoleLogic _phoneOperator = new PhoneOperatorRoleLogic();
        private TeacherRoleLogic _teacher = new TeacherRoleLogic();
        private ManagerRoleLogic _manager = new ManagerRoleLogic();
        private AdminRoleLogic _admin = new AdminRoleLogic();

        [Authorize(Roles = "Admin")]
        [HttpPost("add-user")]
        public IActionResult AddUser(UserInputModel user)
        {
            if (new RoleCRUD().SelectByID((int)user.RoleID) == null)
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
                return new OkResult();
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
            if ((int)userID <= 0 ||  new UserCRUD().SelectByID((int)userID) == null)
            {
                return new NotFoundObjectResult("User not found");
            }

            _admin.DeleteUser((int)userID);
            return new OkResult();
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("deleted-users")]
        public IActionResult RestoreUser(int? userID)
        {
            if (userID == null || userID != null && new AllDeletedUsers().SelectDeletedUserByID((int)userID) == null)
            {
                return new NotFoundObjectResult("User not found");
            }

            _admin.RestoreUser((int)userID);

            return new OkResult();
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("update-user")]
        public IActionResult UpdateUser(UserDTO user)
        {
            if (user.IsDeleted == true || user.ID == null || new UserCRUD().SelectByID((int)user.ID) == null)
            {
                return new NotFoundObjectResult("User not found");
            }

            _admin.UpdateUser(user);

            return new OkResult();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("all-users-with-role")]
        public IActionResult GetAllUsersWithRoles()
        {
            List<UsersWithRoleDTO> users = _admin.ShowAllUsersWithRoles();

            return new OkObjectResult(users);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("all-deleted-users")]
        public IActionResult GetAllDeletedUsers()
        {
            _admin.ShowDeletedUsers();

            return new OkResult();
        }
        
        [HttpGet("all-users")]
        public IActionResult GetAllUsers()
        {
            List<UserDTO> allUsers = new UserCRUD().SelectAll();

            return new OkObjectResult(allUsers);
        }
    }
}
