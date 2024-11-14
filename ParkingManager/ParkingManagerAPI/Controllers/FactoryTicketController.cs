using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkingManager.BusinessLogic.FactoryMethod.FactoryService;
using ParkingManager.BusinessLogic.FactoryMethod.TikcetT;

namespace ParkingManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FactoryTicketController : ControllerBase
    {
        private readonly IFactoryTicketService _ticketService;
        private readonly ILogger<ParkingTicketController> _logger;

        public FactoryTicketController(IFactoryTicketService ticketService, ILogger<ParkingTicketController> logger)
        {
            _ticketService = ticketService;
            _logger = logger;
        }

        [HttpPost("daily")]
        public ActionResult<IParkingTicket> CreateDailyTicket(DateTime? issueAt = null)
        {
            try
            {
                var ticket = _ticketService.CreateDailyTicket(issueAt);
                return Ok(ticket);
            }
            catch (ArgumentException ex)
            {
                _logger.LogError("Error creating daily ticket: {Message}", ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("hourly")]
        public ActionResult<IParkingTicket> CreateHourlyTicket(DateTime? issueAt = null)
        {
            try
            {
                var ticket = _ticketService.CreateHourlyTicket(issueAt);
                return Ok(ticket);
            }
            catch (ArgumentException ex)
            {
                _logger.LogError("Error creating hourly ticket: {Message}", ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
