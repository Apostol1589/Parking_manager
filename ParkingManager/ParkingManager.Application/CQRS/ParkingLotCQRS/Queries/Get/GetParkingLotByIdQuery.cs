using ParkingManager.Application.CQRS.Core;
using ParkingManager.Domain.Entities;

namespace ParkingManager.Application.CQRS.ParkingLotCQRS.Queries.Get
{
    public class GetParkingLotByIdQuery : IQuery<ParkingLot?>
    {
        public int Id { get; }

        public GetParkingLotByIdQuery(int id)
        {
            Id = id;
        }
    }
}
