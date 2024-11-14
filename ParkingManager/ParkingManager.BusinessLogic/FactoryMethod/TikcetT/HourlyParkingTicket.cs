namespace ParkingManager.BusinessLogic.FactoryMethod.TikcetT
{
    public class HourlyParkingTicket : IParkingTicket
    {
        public DateTime IssueAt { get; set; } = DateTime.Now;
        public DateTime? ExitedAt { get; set; }
        private decimal HourlyRate => 5m;

        public decimal CalculateCost()
        {
            return ((ExitedAt ?? DateTime.Now) - IssueAt).Hours * HourlyRate;
        }
    }
}
