using ParkingManager.Domain.Entities;

namespace ParkingManager.Application.Contracts
{
    public interface IParkingTicketService
    {
        Task<IReadOnlyList<ParkingTicket>> GetAllTickets();
        Task<ParkingTicket> GetTicketById(int id);
        Task Create(ParkingTicket ticket);
        Task Remove(int id);
    }
}
