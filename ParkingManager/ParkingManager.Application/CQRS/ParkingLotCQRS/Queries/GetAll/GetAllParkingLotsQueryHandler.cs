using ParkingManager.Application.CQRS.Core;
using ParkingManager.Domain.Contracts;
using ParkingManager.Domain.Entities;


namespace ParkingManager.Application.CQRS.ParkingLotCQRS.Queries.GetAll
{
    public class GetAllParkingLotsQueryHandler : IQueryHandler<GetAllParkingLotsQuery, IReadOnlyList<ParkingLot>>
    {
        private readonly IParkingLotRepository _repository;

        public GetAllParkingLotsQueryHandler(IParkingLotRepository repository)
        {
            _repository = repository;
        }

        public async Task<IReadOnlyList<ParkingLot>> Handle(GetAllParkingLotsQuery query, CancellationToken cancellationToken)
        {
            return await _repository.Get();
        }
    }
}
