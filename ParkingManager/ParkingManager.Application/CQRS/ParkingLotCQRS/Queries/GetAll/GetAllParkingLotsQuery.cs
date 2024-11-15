using ParkingManager.Application.CQRS.Core;
using ParkingManager.Domain.Entities;

namespace ParkingManager.Application.CQRS.ParkingLotCQRS.Queries.GetAll
{
    public class GetAllParkingLotsQuery : IQuery<IReadOnlyList<ParkingLot>>
    {
    }
}
