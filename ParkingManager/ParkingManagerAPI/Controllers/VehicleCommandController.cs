using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkingManager.BusinessLogic.Contracts;
using ParkingManager.DataAccess.Entities;

namespace ParkingManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleCommandController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;

        public VehicleCommandController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        // GET: api/vehicle
        [HttpGet]
        public async Task<IActionResult> GetAllVehicles()
        {
            var vehicles = await _vehicleService.GetAllVehicles();
            return Ok(vehicles);
        }

        // GET: api/vehicle/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicleById(int id)
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

        // POST: api/vehicle
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Vehicle vehicle)
        {
            if (vehicle == null || string.IsNullOrWhiteSpace(vehicle.LicencePlate) ||
                string.IsNullOrWhiteSpace(vehicle.Mark) || string.IsNullOrWhiteSpace(vehicle.Model))
            {
                return BadRequest("Licence plate, mark, and model are required.");
            }

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

        // PUT: api/vehicle/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Vehicle vehicle)
        {
            if (vehicle == null || id != vehicle.Id)
            {
                return BadRequest("Vehicle data is incorrect.");
            }

            try
            {
                await _vehicleService.Update(vehicle);
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

        // DELETE: api/vehicle/{id}
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
