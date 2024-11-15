using Microsoft.Extensions.DependencyInjection;
using ParkingManager.Application.CQRS.Core;

namespace ParkingManager.Application.Mediator
{
    public class Mediator : IMediator
    {
        private readonly IServiceProvider _serviceProvider;

        public Mediator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TResponse> Send<TResponse>(IQuery<TResponse> query, CancellationToken cancellationToken = default)
        {
            var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResponse));
            var handler = (IQueryHandler<IQuery<TResponse>, TResponse>)_serviceProvider.GetRequiredService(handlerType);

            return await handler.Handle(query, cancellationToken);
        }

        public async Task Send(ICommand command, CancellationToken cancellationToken = default)
        {
            var handlerType = typeof(ICommandHandler<>).MakeGenericType(command.GetType());
            var handler = (ICommandHandler<ICommand>)_serviceProvider.GetRequiredService(handlerType);

            await handler.Handle(command, cancellationToken);
        }
    }
}
