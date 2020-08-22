using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using DevEduInterviewSystem.API.Token;
using System.Threading.Tasks.Dataflow;
using DevEduInterviewSystem.DAL.DTO;
using DevEduInterviewSystem.DAL.StoredProcedures.CRUD;
using DevEduInterviewSystem.DAL.StoredProcedures.Query.User;

namespace DevEduInterviewSystem.API.Controllers
{
    public class AccountController : Controller
    {
        [HttpPost("/token")]
        public IActionResult Token(string username, string password)
        {
            var identity = GetIdentity(username, password);
            if (identity == null)
            {
                return BadRequest(new { errorText = "Invalid username or password." });
            }

            var now = DateTime.UtcNow;

            var jwt = new JwtSecurityToken(
                    issuer: AuthenticationOptions.ISSUER,
                    audience: AuthenticationOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthenticationOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthenticationOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt
            };

            return Json(response);
        }
        
        [HttpGet("/token")]

        public IActionResult GetRole(string username, string password)
        {
            // Запрос к базе: существует ли пользователь с таким логином и паролем

            UserDTO authorizingUser = new UserDTO();
            UserCRUD user = new UserCRUD();
            List<UserDTO> users = user.SelectAll(); // возвращает список юзер дтошек
            foreach (UserDTO u in users)
            {
                if (u.Login == username && u.Password == password)
                {
                    authorizingUser = u;
                }
            }
            Person person = new Person(authorizingUser.Login, authorizingUser.Password);

            // Выбор роли пользователя
            SelectUserRoleByUserID select = new SelectUserRoleByUserID();  
            List<UserRoleDTO> personRoles = select.SelectUserRoleByUser((int)authorizingUser.ID); // возвращает список user_role
            List<string> roles = new List<string>();
            foreach (UserRoleDTO ur in personRoles)
            {

                if (u.Login == username && u.Password == password)
                {
                    authorizingUser = u;
                }
            }


            return OkObjectResult;
        }


        private ClaimsIdentity GetIdentity(string username, string password)
        {
            

            if (person != null)
            {
                if (personRoles.Count > 1)
                {
                    RoleDTO chosenRole = new RoleDTO();
                    RoleCRUD role = new RoleCRUD();
                    // TO DO: как опрокинуть выбор роли при авторизации на фронт?? 
                    // Как захардкодить роли?
                    person.Role = (role.SelectByID((int)chosenRole.ID)).TypeOfRole;
                }
                var claims = new List<Claim>
                { new Claim(ClaimsIdentity.DefaultNameClaimType, person.Login),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, person.Role)
                };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                                                                      ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }
            return null;
        }
    }
}
