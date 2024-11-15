using ParkingManager.Application.CQRS.Core;
using ParkingManager.Domain.Entities;
using ParkingManager.Infrastructure.Repositories.ParkingLotRepo;

namespace ParkingManager.Application.CQRS.ParkingLotCQRS.Queries.Get
{
    public class GetParkingLotByIdQueryHandler : IQueryHandler<GetParkingLotByIdQuery, ParkingLot?>
    {
        private readonly IParkingLotRepository _repository;

        public GetParkingLotByIdQueryHandler(IParkingLotRepository repository)
        {
            _repository = repository;
        }

        public async Task<ParkingLot?> Handle(GetParkingLotByIdQuery query, CancellationToken cancellationToken)
        {
            return await _repository.Get(query.Id);
        }
    }
}
