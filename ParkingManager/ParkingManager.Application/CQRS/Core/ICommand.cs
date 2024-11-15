namespace ParkingManager.Application.CQRS.Core
{
    public interface ICommand : IBaseCommand
    {
    }

    public interface ICommand<TResponce> : IBaseCommand
    {
    }

    public interface IBaseCommand
    {
    }
}
