using ParkingManager.Application.CQRS.Core;
using ParkingManager.Domain.Entities;

namespace ParkingManager.Application.CQRS.VehicleCQRS.Queries.Get
{
    public class GetVehicleByIdQuery : IQuery<Vehicle?>
    {
        public int Id { get; }

        public GetVehicleByIdQuery(int id)
        {
            Id = id;
        }
    }

    public class GetAllVehiclesQuery : IQuery<IReadOnlyCollection<Vehicle>>
    {
    }
}
