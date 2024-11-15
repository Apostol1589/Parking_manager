using Microsoft.AspNetCore.Mvc;
using ParkingManager.Domain.Contracts;
using ParkingManager.Domain.Entities;

namespace ParkingManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingLotController : ControllerBase
    {
        private readonly IParkingLotService _parkingLotService;

        public ParkingLotController(IParkingLotService parkingLotService)
        {
            _parkingLotService = parkingLotService;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ParkingLot>>> GetAllLots()
        {
            var parkingLots = await _parkingLotService.GetAllLots();
            return Ok(parkingLots);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ParkingLot>> GetLotById(int id)
        {
            try
            {
                var parkingLot = await _parkingLotService.GetLotById(id);
                return Ok(parkingLot);
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
        public async Task<IActionResult> Create(string name, string location)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(location))
            {
                return BadRequest("Parking lot name and location are required.");
            }

            var lot = new ParkingLot
            {
                Name = name,
                Location = location
            };

            try
            {
                await _parkingLotService.Create(lot);
                return CreatedAtAction(nameof(GetLotById), new { id = lot.Id }, lot);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, string name, string location)
        {
            ParkingLot existingLot = await _parkingLotService.GetLotById(id);

            if (existingLot == null)
            {
                return NotFound("Parking lot not found.");
            }

            try
            {
                existingLot.Name = name;
                existingLot.Location = location;

                await _parkingLotService.Update(existingLot);
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
                await _parkingLotService.Remove(id);
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
