using Microsoft.AspNetCore.Mvc;
using ParkingManager.BusinessLogic.Contracts;
using ParkingManager.BusinessLogic.Services;
using ParkingManager.DataAccess.Entities;

namespace ParkingManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingSpaceController : ControllerBase
    {
        private readonly IParkingSpaceService _parkingPlaceService;
        private readonly IParkingLotService _parkingLotService;
        public ParkingSpaceController(IParkingSpaceService parkingPlaceService, IParkingLotService parkingLotService)
        {
            _parkingPlaceService = parkingPlaceService;
            _parkingLotService = parkingLotService;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ParkingSpace>>> GetAllPlaces()
        {
            var parkingSpaces = await _parkingPlaceService.GetAllSpaces();
            return Ok(parkingSpaces);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ParkingSpace>> GetPlaceById(int id)
        {
            try
            {
                var parkingSpace = await _parkingPlaceService.GetSpaceById(id);
                return Ok(parkingSpace);
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
        public async Task<IActionResult> Create(string number, int lotId)
        {
            if (string.IsNullOrWhiteSpace(number))
            {
                return BadRequest("Space number is required.");
            }

            var parkingLot = await _parkingLotService.GetLotById(lotId);
            if (parkingLot == null)
            {
                return BadRequest("Parking lot does not exist.");
            }

            var space = new ParkingSpace
            {
                SpaceNumber = number,
                ParkingLotId = lotId,
                ParkingLot = parkingLot
            };

            try
            {
                await _parkingPlaceService.Create(space);
                return CreatedAtAction(nameof(GetPlaceById), new { id = space.Id }, space);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, string number, int lotId)
        {
            ParkingSpace existingSpace = await _parkingPlaceService.GetSpaceById(id);

            if (existingSpace == null)
            {
                return NotFound("Parking space not found.");
            }

            try
            {
                existingSpace.SpaceNumber = number;
                existingSpace.ParkingLotId = lotId;
                existingSpace.ParkingLot = await _parkingLotService.GetLotById(lotId);

                await _parkingPlaceService.Update(existingSpace);
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

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                await _parkingPlaceService.Remove(id);
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
