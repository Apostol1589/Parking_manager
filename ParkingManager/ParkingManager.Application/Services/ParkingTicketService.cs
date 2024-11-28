
using ParkingManager.Domain.Contracts;
using ParkingManager.Domain.Entities;


namespace ParkingManager.Application.Services
{
    public class ParkingTicketService : IParkingTicketService
    {
        private readonly IParkingTicketRepository _parkingTicketRepository;
        private readonly IParkingSpaceRepository _parkingSpaceRepository;
        private readonly IVehicleRepository _vehicleRepository;

        public ParkingTicketService(IParkingTicketRepository parkingTicketRepository, IParkingSpaceRepository parkingSpaceRepository, 
            IVehicleRepository vehicleRepository)
        {
            _parkingTicketRepository = parkingTicketRepository;
            _parkingSpaceRepository = parkingSpaceRepository;
            _vehicleRepository = vehicleRepository;
        }

        public async Task<IReadOnlyList<ParkingTicket>> GetAllTickets()
        {
            return await _parkingTicketRepository.Get();
        }

        public async Task<ParkingTicket> GetTicketById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Parking ticket ID must be a positive integer.", nameof(id));
            }

            var ticket = await _parkingTicketRepository.Get(id);
            if (ticket == null)
            {
                throw new KeyNotFoundException($"No parking ticket found with ID {id}.");
            }

            return ticket;
        }

        public async Task Create(ParkingTicket ticket)
        {
            if (ticket == null)
            {
                throw new ArgumentNullException(nameof(ticket), "Parking ticket cannot be null.");
            }

            if (ticket.IssueAt == DateTime.MinValue)
            {
                throw new ArgumentException("Issue date and time must be provided.", nameof(ticket.IssueAt));
            }

            var parkingSpace = await _parkingSpaceRepository.Get(ticket.ParkingSpaceId);
            if (parkingSpace == null)
            {
                throw new KeyNotFoundException($"No parking space found with ID {ticket.ParkingSpaceId}.");
            }

            var vehicle = await _vehicleRepository.Get(ticket.VehicleId);
            if (vehicle == null)
            {
                throw new KeyNotFoundException($"No vehicle found with ID {ticket.VehicleId}.");
            }

            await _parkingTicketRepository.Create(ticket);
        }

        public async Task Remove(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Parking ticket ID must be a positive integer.", nameof(id));
            }

            var ticket = await _parkingTicketRepository.Get(id);
            if (ticket == null)
            {
                throw new KeyNotFoundException($"No parking ticket found with ID {id}.");
            }

            await _parkingTicketRepository.Delete(id);
        }
    }

}
