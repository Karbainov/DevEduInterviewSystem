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
    public class CityController : Controller
    {
        private AdminRoleLogic _admin = new AdminRoleLogic();

        [HttpPost("add-city")]
        public IActionResult AddCity(CityDTO city)
        {
            if (city.Name == null)
            {
                return BadRequest("Name field missing");
            }
            _admin.AddCity(city);
            return new OkResult();
        }

        [HttpDelete("delete-city/{cityID}")]
        public IActionResult DeleteCity(int cityID)
        {
            if (new CityCRUD().SelectByID(cityID) == null)
            {
                return new NotFoundObjectResult("City not found");
            }
            _admin.DeleteCity(new CityCRUD().SelectByID(cityID));
            return new OkResult();
        }

        [HttpGet("all-city")]
        public IActionResult GetAllCity()
        {
            CityCRUD cityCRUD = new CityCRUD();
            List<CityDTO> citys = cityCRUD.SelectAll();
            return new ObjectResult(citys);
        }
    }
}
