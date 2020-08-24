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
using System.Globalization;
using DevEduInterviewSystem.API.Models.Input;
using Microsoft.AspNetCore.Authorization;

namespace DevEduInterviewSystem.API.Controllers
{
    public class AccountController : Controller
    {
        [HttpPost("/token{role}")]
        public IActionResult Token(PersonInputModel person)
        {
            UserDTO authorizingUser = new UserDTO();
            UserCRUD user = new UserCRUD();
            List<UserDTO> users = user.SelectAll();
            foreach (UserDTO u in users)
            {
                if (u.Login == person.Username && u.Password == person.Password)
                {
                    authorizingUser = u;
                }
            }

            GetRolesByUserID role = new GetRolesByUserID();
            List<string> roles = role.GetListOfRoles((int)authorizingUser.ID);
            string chosenRole = null;
            foreach (string r in roles)
            {
                if (r == person.Role)
                {
                    chosenRole = r;
                }
            }
            if (chosenRole == null)
            {
                return BadRequest(new { errorText = "Role not found" });
            }

            var claims = new List<Claim>
                { new Claim(ClaimsIdentity.DefaultNameClaimType, person.Username),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, person.Role)
                };
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                                                                  ClaimsIdentity.DefaultRoleClaimType);

            var now = DateTime.UtcNow;

            var jwt = new JwtSecurityToken(
                    issuer: AuthenticationOptions.ISSUER,
                    audience: AuthenticationOptions.AUDIENCE,
                    notBefore: now,
                    claims: claimsIdentity.Claims,
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
        public IActionResult GetRole(PersonInputModel person)
        {
            // Запрос к базе: существует ли пользователь с таким логином и паролем

            UserDTO authorizingUser = new UserDTO();
            UserCRUD user = new UserCRUD();
            List<UserDTO> users = user.SelectAll();
            foreach (UserDTO u in users)
            {
                if (u.Login == person.Username && u.Password == person.Password)
                {
                    authorizingUser = u;
                }
            }
            if (authorizingUser == null)
            {
                return BadRequest(new { errorText = "Invalid username or password." });
            }

            GetRolesByUserID role = new GetRolesByUserID();
            List<string> roles = role.GetListOfRoles((int)authorizingUser.ID);

            return new OkObjectResult(roles);
        }

        // ДЛЯ ПРОВЕРКИ ТОКЕНА, УДАЛИТЬ ДО ЗАЩИТЫ
        [Authorize(Roles = "Manager")]
        [HttpGet("token/a")]

        public string GetA()
        {
            return "AAA";
        }

    }
}
