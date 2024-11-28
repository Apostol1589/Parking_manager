using ParkingManager.Application.DTO;
using ParkingManager.Domain.Entities;

namespace ParkingManager.Application.Mappers
{
    public static class ParkingLotMapper
    {
        public static ParkingLotDTO ToDTO(ParkingLot parkingLot)
        {
            if (parkingLot == null) return null;

            return new ParkingLotDTO
            {
                Name = parkingLot.Name,
                Location = parkingLot.Location
            };
        }

        public static ParkingLot ToEntity(ParkingLotDTO parkingLotDTO)
        {
            if (parkingLotDTO == null) return null;

            return new ParkingLot
            {
                Name = parkingLotDTO.Name,
                Location = parkingLotDTO.Location
            };
        }
    }

}
