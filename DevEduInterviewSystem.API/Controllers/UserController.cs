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

        [HttpDelete("delete-user/{userID}")]
        public IActionResult DeleteUser(int userID)
        {
            if ((int)userID == null || (int)userID != null && new UserCRUD().SelectByID((int)userID) == null)
            {
                return new NotFoundObjectResult("User not found");
            }

            _admin.DeleteUser((int)userID);
            return new OkResult();
        }

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

        [HttpGet("all-users-with-role")]
        public IActionResult GetAllUsersWithRoles()
        {
            List<UsersWithRoleDTO> users = _admin.ShowAllUsersWithRoles();

            return new OkObjectResult(users);
        }

        [HttpGet("all-deleted-users")]
        public IActionResult GetAllDeletedUsers()
        {
            _admin.ShowDeletedUsers();

            return new OkResult();
        }
        // TODO: метод для тестов в постман, потом можно его наверно убрать
        [HttpGet("all-users")]
        public IActionResult GetAllUsers()
        {
            UserCRUD users = new UserCRUD();
            List<UserDTO> allUsers = users.SelectAll();

            return new OkObjectResult(allUsers);
        }
    }
}
