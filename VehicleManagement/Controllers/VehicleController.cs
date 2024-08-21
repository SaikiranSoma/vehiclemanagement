using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using VehicleManagement.Data;
using VehicleManagement.Models;
using VehicleManagement.Repository;

namespace VehicleManagement.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {

        private readonly IVehicleRepository _vehicleRepository;

        public VehicleController(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        [HttpGet]
        public IActionResult GetAllVechiles()
        {
            var result = _vehicleRepository.GetAllVehicles();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost]
        public IActionResult AddVehicle([FromBody] VehicleDto vehicle)
        {
            var result = _vehicleRepository.AddVehicle(vehicle);
            if (result != null)
            {
                return Ok("Vehicle added sucesfully");
            }
            return BadRequest();
        }


        [HttpPut("{Id}")]
        public IActionResult UpdateVehicle([FromRoute]int Id,[FromBody] VehicleDto vehicle) 
        { 
            var result=_vehicleRepository.UpdateVehicle(Id,vehicle);
            if(result!=null) 
            {
                return Ok("Vehicle Updated succesfully");
            }
            return BadRequest("Vehicle Not Found with id");
        }

        [HttpDelete("{Id}")]
        public IActionResult DeleteVehicle(int Id) 
        {
            var result = _vehicleRepository.DeleteVehicle(Id);
            if (result != null) 
            {
                return Ok("Vehicle Deleted Succesfully");
            }
            return BadRequest();
        }
    }
}
