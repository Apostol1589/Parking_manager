using ParkingManager.Domain.Contracts;
using ParkingManager.Domain.Entities;
using ParkingManager.Infrastructure.Repositories.ParkingSpaceRepo;

namespace ParkingManager.Application.Services
{
    public class ParkingSpaceService : IParkingSpaceService
    {
        private readonly IParkingSpaceRepository _parkingSpaceRepository;

        public ParkingSpaceService(IParkingSpaceRepository parkingSpaceRepository)
        {
            _parkingSpaceRepository = parkingSpaceRepository;
        }

        public async Task<IReadOnlyList<ParkingSpace>> GetAllSpaces()
        {
            return await _parkingSpaceRepository.Get();
        }

        public async Task<ParkingSpace> GetSpaceById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Parking space ID must be a positive integer.", nameof(id));
            }

            var space = await _parkingSpaceRepository.Get(id);
            if (space == null)
            {
                throw new KeyNotFoundException($"No parking space found with ID {id}.");
            }

            return space;
        }

        public async Task Create(ParkingSpace space)
        {
            if (space == null)
            {
                throw new ArgumentNullException(nameof(space), "Parking space cannot be null.");
            }

            if (string.IsNullOrWhiteSpace(space.SpaceNumber.ToString()) || space.ParkingLotId <= 0)
            {
                throw new ArgumentException("Parking space details (SpaceNumber and ParkingLotId) must be provided.");
            }

            await _parkingSpaceRepository.Create(space);
        }

        public async Task Update(ParkingSpace space)
        {
            if (space == null)
            {
                throw new ArgumentNullException(nameof(space), "Parking space cannot be null.");
            }

            if (space.Id <= 0)
            {
                throw new ArgumentException("Parking space ID must be a positive integer.", nameof(space.Id));
            }

            if (string.IsNullOrWhiteSpace(space.SpaceNumber.ToString()) || space.ParkingLotId <= 0)
            {
                throw new ArgumentException("Parking space details (SpaceNumber and ParkingLotId) must be provided.");
            }

            await _parkingSpaceRepository.Update(space);
        }

        public async Task Remove(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Parking space ID must be a positive integer.", nameof(id));
            }

            var space = await _parkingSpaceRepository.Get(id);
            if (space == null)
            {
                throw new KeyNotFoundException($"No parking space found with ID {id}.");
            }

            await _parkingSpaceRepository.Delete(id);
        }
    }

}
