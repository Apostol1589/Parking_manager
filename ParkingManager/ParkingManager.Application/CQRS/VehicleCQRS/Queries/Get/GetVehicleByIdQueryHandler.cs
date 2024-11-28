using ParkingManager.Application.CQRS.Core;
using ParkingManager.Domain.Contracts;


namespace ParkingManager.Application.CQRS.VehicleCQRS.Queries.Get
{
    public class GetVehicleByIdQueryHandler : IQueryHandler<GetVehicleByIdQuery, ParkingManager.Domain.Entities.Vehicle?>
    {
        private readonly IVehicleRepository _repository;

        public GetVehicleByIdQueryHandler(IVehicleRepository repository)
        {
            _repository = repository;
        }

        public async Task<ParkingManager.Domain.Entities.Vehicle?> Handle(GetVehicleByIdQuery query, CancellationToken cancellationToken)
        {
            return await _repository.Get(query.Id);
        }
    }

}
