using ParkingManager.Application.CQRS.Core;
using ParkingManager.Application.CQRS.VehicleCQRS.Queries.Get;
using ParkingManager.Domain.Contracts;
using ParkingManager.Domain.Entities;


namespace ParkingManager.Application.CQRS.VehicleCQRS.Queries.GetAll
{
    public class GetAllVehiclesQueryHandler : IQueryHandler<GetAllVehiclesQuery, IReadOnlyCollection<Vehicle>>
    {
        private readonly IVehicleRepository _repository;

        public GetAllVehiclesQueryHandler(IVehicleRepository repository)
        {
            _repository = repository;
        }

        public async Task<IReadOnlyCollection<Vehicle>> Handle(GetAllVehiclesQuery query, CancellationToken cancellationToken)
        {
            return await _repository.Get();
        }
    }

}
