using ParkingManager.DataAccess.Entities;

namespace ParkingManager.BusinessLogic.Contracts
{
    public interface IParkingLotService
    {
        Task<IReadOnlyList<ParkingLot>> GetAllLots();
        Task<ParkingLot> GetLotById(int id);
        Task Create(ParkingLot lot);
        Task Update(ParkingLot lot);
        Task Remove(int id);
    }
}
