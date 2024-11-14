namespace ParkingManager.BusinessLogic.FactoryMethod.TikcetT
{
    public interface IParkingTicket
    {
        DateTime IssueAt { get; set; }
        DateTime? ExitedAt { get; set; }
        decimal CalculateCost();
    }
}
