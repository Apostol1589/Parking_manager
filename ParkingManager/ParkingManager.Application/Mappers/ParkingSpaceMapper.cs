using ParkingManager.Application.DTO;
using ParkingManager.Domain.Entities;

namespace ParkingManager.Application.Mappers
{
    public static class ParkingSpaceMapper
    {
        public static ParkingSpaceDTO ToDTO(ParkingSpace parkingSpace)
        {
            if (parkingSpace == null) return null;

            return new ParkingSpaceDTO
            {
                SpaceNumber = parkingSpace.SpaceNumber,
                ParkingLotId = parkingSpace.ParkingLotId
            };
        }

        public static ParkingSpace ToEntity(ParkingSpaceDTO parkingSpaceDTO)
        {
            if (parkingSpaceDTO == null) return null;

            return new ParkingSpace
            {
                SpaceNumber = parkingSpaceDTO.SpaceNumber,
                ParkingLotId = parkingSpaceDTO.ParkingLotId
            };
        }
    }

}
