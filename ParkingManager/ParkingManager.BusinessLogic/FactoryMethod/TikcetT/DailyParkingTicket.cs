namespace ParkingManager.BusinessLogic.FactoryMethod.TikcetT
{
    public class DailyParkingTicket : IParkingTicket
    {
        public DateTime IssueAt { get; set; } = DateTime.Now;
        public DateTime? ExitedAt { get; set; }
        private decimal DailyRate => 20m;

        public decimal CalculateCost()
        {
            return ((ExitedAt ?? DateTime.Now) - IssueAt).Days * DailyRate;
        }
    }
}
