using Microsoft.Extensions.Logging;
using ParkingManager.BusinessLogic.Contracts;
using ParkingManager.BusinessLogic.FactoryMethod.Factory;
using ParkingManager.BusinessLogic.FactoryMethod.TikcetT;

namespace ParkingManager.BusinessLogic.FactoryMethod.FactoryService
{
    public class FactoryTicketService : IFactoryTicketService
    {
        private readonly ILogger<FactoryTicketService> _logger;

        public FactoryTicketService(ILogger<FactoryTicketService> logger)
        {
            _logger = logger;
        }

        public IParkingTicket CreateDailyTicket(DateTime? issueAt = null)
        {
            var factory = new DailyTicketFactory();
            var ticket = factory.CreateTicket(issueAt);
            _logger.LogInformation("Daily ticket created with issue time {IssueAt}.", ticket.IssueAt);
            return ticket;
        }

        public IParkingTicket CreateHourlyTicket(DateTime? issueAt = null)
        {
            var factory = new HourlyTicketFactory();
            var ticket = factory.CreateTicket(issueAt);
            _logger.LogInformation("Hourly ticket created with issue time {IssueAt}.", ticket.IssueAt);
            return ticket;
        }
    }
}
