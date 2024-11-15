namespace ParkingManager.Application.CQRS.Core
{
    public interface IQueryHandler<TQuery, TResponse>
        where TQuery : IQuery<TResponse>
    {
        Task<TResponse> Handle(TQuery query, CancellationToken cancellationToken);
    }
}
