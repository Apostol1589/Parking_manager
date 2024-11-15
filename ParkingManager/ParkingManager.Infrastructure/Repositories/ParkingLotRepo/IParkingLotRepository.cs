using ParkingManager.Domain.Entities;
using System.Collections.ObjectModel;

namespace ParkingManager.Infrastructure.Repositories.ParkingLotRepo
{
    public interface IParkingLotRepository : IRepository<ParkingLot>
    {
        public Task<ReadOnlyCollection<ParkingLot>> Get();
        public Task<ParkingLot?> Get(int id);
        public Task<ReadOnlyCollection<ParkingLot>> Get(Func<ParkingLot, bool> predicate);
        public Task Create(ParkingLot entity);
        public Task Update(ParkingLot entity);
        public Task Delete(int id);
    }
}
