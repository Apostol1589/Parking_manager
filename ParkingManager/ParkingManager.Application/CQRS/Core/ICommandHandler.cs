namespace ParkingManager.Application.CQRS.Core
{
    public interface ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        Task Handle(TCommand command, CancellationToken cancellationToken);
    }

    public interface ICommandHandler<TCommand, TResponce>
        where TCommand : ICommand<TResponce>
    {
        Task<TResponce> Handle(TCommand command, CancellationToken cancellationToken);
    }
}
