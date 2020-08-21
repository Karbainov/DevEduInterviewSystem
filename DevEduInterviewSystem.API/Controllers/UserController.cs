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
    public class UserController : Controller
    {
        private PhoneOperatorRoleLogic _phoneOperator = new PhoneOperatorRoleLogic();
        private TeacherRoleLogic _teacher = new TeacherRoleLogic();
        private ManagerRoleLogic _manager = new ManagerRoleLogic();
        private AdminRoleLogic _admin = new AdminRoleLogic();

        [HttpPost("Users")]
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

        [HttpDelete("Users")]
        public IActionResult DeleteUser(int? userID)
        {
            if (userID == null || userID != null && new UserCRUD().SelectByID((int)userID) == null)
            {
                return new NotFoundObjectResult("User not found");
            }

            _admin.DeleteUser((int)userID);
            return new OkResult();
        }

        [HttpGet("Users")]
        public IActionResult GetAllUsersWithRoles()
        {
            _admin.ShowAllUsersWithRoles();

            return new OkResult();
        }

        [HttpGet("Users")]
        public IActionResult GetAllDeletedUsers()
        {
            _admin.ShowDeletedUsers();

            return new OkResult();
        }

    }
}
