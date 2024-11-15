using ParkingManager.Application.CQRS.Core;

namespace ParkingManager.Application.Mediator
{
    public interface IMediator
    {
        Task<TResponse> Send<TResponse>(IQuery<TResponse> query, CancellationToken cancellationToken = default);
        Task Send(ICommand command, CancellationToken cancellationToken = default);
    }

}
