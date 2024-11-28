using ParkingManager.Application.DTO;
using ParkingManager.Domain.Entities;

namespace ParkingManager.Application.Mappers
{
    public static class VehicleMapper
    {
        public static VehicleDTO ToDTO(Vehicle vehicle)
        {
            if (vehicle == null) return null;

            return new VehicleDTO
            {
                LicencePlate = vehicle.LicencePlate,
                Mark = vehicle.Mark,
                Model = vehicle.Model,
                Color = vehicle.Color
            };
        }

        public static Vehicle ToEntity(VehicleDTO vehicleDTO)
        {
            if (vehicleDTO == null) return null;

            return new Vehicle
            {
                LicencePlate = vehicleDTO.LicencePlate,
                Mark = vehicleDTO.Mark,
                Model = vehicleDTO.Model,
                Color = vehicleDTO.Color
            };
        }
    }

}
