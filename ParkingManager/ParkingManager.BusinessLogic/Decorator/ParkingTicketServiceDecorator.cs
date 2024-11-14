using ParkingManager.BusinessLogic.Contracts;
using ParkingManager.DataAccess.Entities;

namespace ParkingManager.BusinessLogic.Decorator
{
    public abstract class ParkingTicketServiceDecorator : IParkingTicketService
    {
        protected readonly IParkingTicketService _innerService;

        protected ParkingTicketServiceDecorator(IParkingTicketService innerService)
        {
            _innerService = innerService;
        }

        public virtual async Task<IReadOnlyList<ParkingTicket>> GetAllTickets()
        {
            return await _innerService.GetAllTickets();
        }

        public virtual async Task<ParkingTicket> GetTicketById(int id)
        {
            return await _innerService.GetTicketById(id);
        }

        public virtual async Task Create(ParkingTicket ticket)
        {
            await _innerService.Create(ticket);
        }

        public virtual async Task Remove(int id)
        {
            await _innerService.Remove(id);
        }
    }

}
