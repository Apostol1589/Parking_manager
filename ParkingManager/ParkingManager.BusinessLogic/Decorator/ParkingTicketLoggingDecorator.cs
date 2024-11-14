using Microsoft.Extensions.Logging;
using ParkingManager.BusinessLogic.Contracts;
using ParkingManager.DataAccess.Entities;

namespace ParkingManager.BusinessLogic.Decorator
{
    public class ParkingTicketLoggingDecorator : ParkingTicketServiceDecorator
    {
        private readonly ILogger<ParkingTicketLoggingDecorator> _logger;

        public ParkingTicketLoggingDecorator(IParkingTicketService innerService, ILogger<ParkingTicketLoggingDecorator> logger)
            : base(innerService)
        {
            _logger = logger;
        }

        public override async Task<IReadOnlyList<ParkingTicket>> GetAllTickets()
        {
            _logger.LogInformation("Getting all tickets...");
            var tickets = await _innerService.GetAllTickets();
            _logger.LogInformation("Successfully retrieved all tickets.");
            return tickets;
        }

        public override async Task<ParkingTicket> GetTicketById(int id)
        {
            _logger.LogInformation($"Getting ticket by ID: {id}");
            var ticket = await _innerService.GetTicketById(id);
            _logger.LogInformation($"Successfully retrieved ticket with ID: {id}");
            return ticket;
        }

        public override async Task Create(ParkingTicket ticket)
        {
            _logger.LogInformation($"Creating ticket with vehicle ID: {ticket.VehicleId}");
            await _innerService.Create(ticket);
            _logger.LogInformation($"Successfully created ticket for vehicle ID: {ticket.VehicleId}");
        }

        public override async Task Remove(int id)
        {
            _logger.LogInformation($"Removing ticket with ID: {id}");
            await _innerService.Remove(id);
            _logger.LogInformation($"Successfully removed ticket with ID: {id}");
        }
    }
}
