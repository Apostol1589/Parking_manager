using Microsoft.AspNetCore.Mvc;
using ParkingManager.BusinessLogic.Builder;
using ParkingManager.BusinessLogic.Contracts;
using ParkingManager.BusinessLogic.Enumerator;
using ParkingManager.DataAccess.Entities;
using System.ComponentModel.DataAnnotations;

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
            try
            {
                var vehicle = new VehicleBuilder()
                    .SetLicencePlate(licencePlate)
                    .SetMark(mark)
                    .SetModel(model)
                    .SetColor(color)
                    .Build();

                await _vehicleService.Create(vehicle);
                return CreatedAtAction(nameof(GetVehicleById), new { id = vehicle.Id }, vehicle);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, string licencePlate, string mark, string model, string color)
        {
            try
            {
                Vehicle existingVehicle = await _vehicleService.GetVehicleById(id);

                if (existingVehicle == null)
                {
                    return NotFound("Vehicle not found.");
                }

                var updatedVehicle = new VehicleBuilder()
                    .SetLicencePlate(licencePlate)
                    .SetMark(mark)
                    .SetModel(model)
                    .SetColor(color)
                    .Build();

                updatedVehicle.Id = existingVehicle.Id;

                await _vehicleService.Update(updatedVehicle);
                return NoContent();
            }
            catch (ValidationException ex)
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

        [HttpGet("iterator")]
        public async Task<IActionResult> Iterator()
        {
            VehicleCollection vehicles = new VehicleCollection();

            var allVehicles = await _vehicleService.GetAllVehicles();

            foreach (var vehicle in allVehicles)
            {
                vehicles.AddVehicle(vehicle);
            }

            var vehicleInfo = new List<string>();

            foreach (var vehicle in vehicles)
            {
                vehicleInfo.Add($"Mark: {vehicle.Mark}, Model: {vehicle.Model}");
            }

            return Ok(vehicleInfo);
        }

    }
}
