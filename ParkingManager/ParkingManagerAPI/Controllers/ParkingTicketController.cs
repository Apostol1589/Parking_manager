using Microsoft.AspNetCore.Mvc;
using ParkingManager.BusinessLogic.Contracts;
using ParkingManager.DataAccess.Entities;

namespace ParkingManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingTicketController : ControllerBase
    {
        private readonly IParkingTicketService _parkingTicketService;

        public ParkingTicketController(IParkingTicketService parkingTicketService)
        {
            _parkingTicketService = parkingTicketService;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ParkingTicket>>> GetAllTickets()
        {
            var tickets = await _parkingTicketService.GetAllTickets();
            return Ok(tickets);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ParkingTicket>> GetTicketById(int id)
        {
            try
            {
                var ticket = await _parkingTicketService.GetTicketById(id);
                return Ok(ticket);
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
        public async Task<IActionResult> Create( DateTime issueDate, string issueTime, DateTime? exitDate, string exitTime,
            decimal cost, int parkingSpaceId, int vehicleId)
        {
            if (string.IsNullOrWhiteSpace(issueTime) || (exitDate.HasValue && string.IsNullOrWhiteSpace(exitTime)))
            {
                return BadRequest("Both date and time must be provided for IssueAt and, if specified, ExitedAt.");
            }

            if (!TimeSpan.TryParse(issueTime, out TimeSpan parsedIssueTime))
            {
                return BadRequest("Issue time must be in the correct format (hh:mm).");
            }

            TimeSpan? parsedExitTime = null;
            if (exitDate.HasValue)
            {
                if (!TimeSpan.TryParse(exitTime, out TimeSpan tempExitTime))
                {
                    return BadRequest("Exit time must be in the correct format (hh:mm).");
                }
                parsedExitTime = tempExitTime;
            }

            var ticket = new ParkingTicket
            {
                IssueAt = issueDate.Add(parsedIssueTime),
                ExitedAt = exitDate.HasValue && parsedExitTime.HasValue ? exitDate.Value.Add(parsedExitTime.Value) : null,
                Cost = cost,
                ParkingSpaceId = parkingSpaceId,
                VehicleId = vehicleId
            };
            try
            {
                await _parkingTicketService.Create(ticket);
                return CreatedAtAction(nameof(GetTicketById), new { id = ticket.Id }, ticket);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                await _parkingTicketService.Remove(id);
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
