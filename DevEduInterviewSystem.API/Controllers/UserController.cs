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

        [HttpPost("users")]
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

        [HttpDelete("users")]
        public IActionResult DeleteUser(int? userID)
        {
            if (userID == null || userID != null && new UserCRUD().SelectByID((int)userID) == null)
            {
                return new NotFoundObjectResult("User not found");
            }

            _admin.DeleteUser((int)userID);
            return new OkResult();
        }

        [HttpPut("users/deleted")]
        public IActionResult RestoreUser(int? userID)
        {
            if (userID == null || userID != null && new AllDeletedUsers().SelectDeletedUserByID((int)userID) == null)
            {
                return new NotFoundObjectResult("User not found");
            }

            _admin.RestoreUser((int)userID);

            return new OkResult();
        }

        [HttpPut("users")]
        public IActionResult UpdateUser(UserDTO user)
        {
            if (user.IsDeleted == true || user.ID == null || new UserCRUD().SelectByID((int)user.ID) == null)
            {
                return new NotFoundObjectResult("User not found");
            }

            _admin.UpdateUser(user);

            return new OkResult();
        }

        [HttpGet("users")]
        public IActionResult GetAllUsersWithRoles()
        {
            List<UsersWithRoleDTO> users = _admin.ShowAllUsersWithRoles();

            return new JsonResult(users);
        }

        [HttpGet("users/deleted")]
        public IActionResult GetAllDeletedUsers()
        {
            _admin.ShowDeletedUsers();

            return new OkResult();
        }

    }
}
