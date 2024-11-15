using ParkingManager.Domain.Entities;
namespace ParkingManager.Domain.Contracts
{
    public interface IParkingSpaceService
    {
        Task<IReadOnlyList<ParkingSpace>> GetAllSpaces();
        Task<ParkingSpace> GetSpaceById(int id);
        Task Create(ParkingSpace place);
        Task Update(ParkingSpace place);
        Task Remove(int id);
    }
}
