using Microsoft.AspNetCore.Mvc;
using ParkingManager.BusinessLogic.Contracts;
using ParkingManager.DataAccess.Entities;

namespace ParkingManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Vehicle>>> GetAllVehicles()
        {
            var vehicles = await _vehicleService.GetAllVehicles();
            return Ok(vehicles);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Vehicle>> GetVehicleById(int id)
        {
            try
            {
                var vehicle = await _vehicleService.GetVehicleById(id);
                return Ok(vehicle);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(string licencePlate, string mark, string model, string color)
        {
            if (string.IsNullOrWhiteSpace(licencePlate) || string.IsNullOrWhiteSpace(mark) || string.IsNullOrWhiteSpace(model))
            {
                return BadRequest("Licence plate, mark, and model are required.");
            }

            var vehicle = new Vehicle
            {
                LicencePlate = licencePlate,
                Mark = mark,
                Model = model,
                Color = color
            };

            try
            {
                await _vehicleService.Create(vehicle);
                return CreatedAtAction(nameof(GetVehicleById), new { id = vehicle.Id }, vehicle);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, string licencePlate, string mark, string model, string color)
        {
            Vehicle existingVehicle = await _vehicleService.GetVehicleById(id);

            if (existingVehicle == null)
            {
                return NotFound("Vehicle not found.");
            }

            try
            {
                existingVehicle.LicencePlate = licencePlate;
                existingVehicle.Mark = mark;
                existingVehicle.Model = model;
                existingVehicle.Color = color;

                await _vehicleService.Update(existingVehicle);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                await _vehicleService.Remove(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
