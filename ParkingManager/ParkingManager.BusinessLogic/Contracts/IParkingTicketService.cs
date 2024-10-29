using ParkingManager.DataAccess.Entities;

namespace ParkingManager.BusinessLogic.Contracts
{
    public interface IParkingTicketService
    {
        Task<IReadOnlyList<ParkingTicket>> GetAllTickets();
        Task<ParkingTicket> GetTicketById(int id);
        Task Create(ParkingTicket ticket);
        Task Remove(int id);
    }
}
