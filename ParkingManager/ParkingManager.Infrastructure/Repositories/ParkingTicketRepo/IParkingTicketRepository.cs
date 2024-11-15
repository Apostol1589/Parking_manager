using ParkingManager.Domain.Entities;
using System.Collections.ObjectModel;

namespace ParkingManager.Infrastructure.Repositories.ParkingTicketRepo
{
    public interface IParkingTicketRepository : IRepository<ParkingTicket>
    {
        public Task<ReadOnlyCollection<ParkingTicket>> Get();
        public Task<ParkingTicket?> Get(int id);
        public Task<ReadOnlyCollection<ParkingTicket>> Get(Func<ParkingTicket, bool> predicate);
        public Task Create(ParkingTicket entity);
        public Task Update(ParkingTicket entity);
        public Task Delete(int id);
    }
}
