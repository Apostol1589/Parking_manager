using ParkingManager.BusinessLogic.Adapters;
using ParkingManager.BusinessLogic.Contracts;
using ParkingManager.DataAccess.Entities;
using ParkingManager.DataAccess.Repositories.ParkingTicketRepo;
using System;

namespace ParkingManager.BusinessLogic.Services
{
    public class ParkingTicketService : IParkingTicketService
    {
        private readonly IParkingTicketRepository _parkingTicketRepository;
        private readonly IParkingSpaceService _parkingSpaceService;
        private readonly IVehicleService _vehicleService;
        private readonly IParkingLotService _parkingLotService;
        private readonly ITaxCalculationAdapter _taxCalculationAdapter;

        public ParkingTicketService(IParkingTicketRepository parkingTicketRepository, IParkingSpaceService parkingSpaceService, 
            IVehicleService vehicleService, IParkingLotService parkingLotService, ITaxCalculationAdapter taxCalculationAdapter)
        {
            _parkingTicketRepository = parkingTicketRepository;
            _parkingSpaceService = parkingSpaceService;
            _vehicleService = vehicleService;
            _parkingLotService = parkingLotService;
            _taxCalculationAdapter = taxCalculationAdapter;
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

            var parkingSpace = await _parkingSpaceService.GetSpaceById(ticket.ParkingSpaceId);
            if (parkingSpace == null)
            {
                throw new KeyNotFoundException($"No parking space found with ID {ticket.ParkingSpaceId}.");
            }

            var parkingLot = await _parkingLotService.GetLotById(parkingSpace.ParkingLotId);
            if (parkingLot == null)
            {
                throw new KeyNotFoundException($"No parking lot found with ID {parkingSpace.ParkingLotId}.");
            }

            var vehicle = await _vehicleService.GetVehicleById(ticket.VehicleId);
            if (vehicle == null)
            {
                throw new KeyNotFoundException($"No vehicle found with ID {ticket.VehicleId}.");
            }

            decimal tax = _taxCalculationAdapter.CalculateTax(vehicle, parkingLot);

            
            ticket.Cost += tax;

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
