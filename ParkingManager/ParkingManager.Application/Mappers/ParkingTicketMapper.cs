using ParkingManager.Application.DTO;
using ParkingManager.Domain.Entities;

namespace ParkingManager.Application.Mappers
{
    public static class ParkingTicketMapper
    {
        public static ParkingTicketDTO ToDTO(ParkingTicket parkingTicket)
        {
            if (parkingTicket == null) return null;

            return new ParkingTicketDTO
            {
                IssueAt = parkingTicket.IssueAt,
                ExitedAt = parkingTicket.ExitedAt,
                Cost = parkingTicket.Cost,
                ParkingSpaceId = parkingTicket.ParkingSpaceId,
                VehicleId = parkingTicket.VehicleId
            };
        }

        public static ParkingTicket ToEntity(ParkingTicketDTO parkingTicketDTO)
        {
            if (parkingTicketDTO == null) return null;

            return new ParkingTicket
            {
                IssueAt = parkingTicketDTO.IssueAt,
                ExitedAt = parkingTicketDTO.ExitedAt,
                Cost = parkingTicketDTO.Cost,
                ParkingSpaceId = parkingTicketDTO.ParkingSpaceId,
                VehicleId = parkingTicketDTO.VehicleId
            };
        }
    }

}
