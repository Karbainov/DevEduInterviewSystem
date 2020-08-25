using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevEduInterviewSystem.API.Models.Input;
using DevEduInterviewSystem.BLL;
using DevEduInterviewSystem.DAL.DTO;
using DevEduInterviewSystem.DAL.StoredProcedures.CRUD;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevEduInterviewSystem.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CityController : Controller
    {
        private AdminRoleLogic _admin = new AdminRoleLogic();

        [Authorize(Roles = "Admin")]
        [HttpPost("add-city")]
        public IActionResult AddCity(CityDTO city)
        {
            if (city.Name == null)
            {
                return BadRequest("Name field missing");
            }
            _admin.AddCity(city);
            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("delete-city/{cityID}")]
        public IActionResult DeleteCity(int cityID)
        {
            if (new CityCRUD().SelectByID(cityID).ID == null)
            {
                return NotFound("City not found");
            }
            _admin.DeleteCity(new CityCRUD().SelectByID(cityID));
            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("all-city")]
        public IActionResult GetAllCity()
        {
            List<CityDTO> citys = new CityCRUD().SelectAll();
            return Ok(citys);
        }
    }
}
