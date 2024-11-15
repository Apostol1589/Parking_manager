
using ParkingManager.Domain.Contracts;
using ParkingManager.Domain.Entities;
using ParkingManager.Infrastructure.Repositories.ParkingLotRepo;

namespace ParkingManager.Application.Services
{
    public class ParkingLotService : IParkingLotService
    {
        private readonly IParkingLotRepository _parkingLotRepository;

        public ParkingLotService(IParkingLotRepository parkingLotRepository)
        {
            _parkingLotRepository = parkingLotRepository;
        }

        public async Task<IReadOnlyList<ParkingLot>> GetAllLots()
        {
            return await _parkingLotRepository.Get();
        }

        public async Task<ParkingLot> GetLotById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Parking lot ID must be a positive integer.", nameof(id));
            }

            var lot = await _parkingLotRepository.Get(id);
            if (lot == null)
            {
                throw new KeyNotFoundException($"No parking lot found with ID {id}.");
            }

            return lot;
        }

        public async Task Create(ParkingLot lot)
        {
            if (lot == null)
            {
                throw new ArgumentNullException(nameof(lot), "Parking lot cannot be null.");
            }

            if (string.IsNullOrWhiteSpace(lot.Location) || string.IsNullOrWhiteSpace(lot.Name))
            {
                throw new ArgumentException("Parking lot details (Location and Name) must be provided.");
            }

            await _parkingLotRepository.Create(lot);
        }

        public async Task Update(ParkingLot lot)
        {
            if (lot == null)
            {
                throw new ArgumentNullException(nameof(lot), "Parking lot cannot be null.");
            }

            if (lot.Id <= 0)
            {
                throw new ArgumentException("Parking lot ID must be a positive integer.", nameof(lot.Id));
            }

            if (string.IsNullOrWhiteSpace(lot.Location) || string.IsNullOrWhiteSpace(lot.Name))
            {
                throw new ArgumentException("Parking lot details (Location and Name) must be provided.");
            }

            await _parkingLotRepository.Update(lot);
        }

        public async Task Remove(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Parking lot ID must be a positive integer.", nameof(id));
            }

            var lot = await _parkingLotRepository.Get(id);
            if (lot == null)
            {
                throw new KeyNotFoundException($"No parking lot found with ID {id}.");
            }

            await _parkingLotRepository.Delete(id);
        }
    }

}
