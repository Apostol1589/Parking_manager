using Microsoft.Extensions.Logging;
using ParkingManager.BusinessLogic.FactoryMethod.TikcetT;

namespace ParkingManager.BusinessLogic.FactoryMethod.Factory
{

    public class DailyTicketFactory : ParkingTicketFactory
    {
        public DailyTicketFactory() { }

        public override IParkingTicket CreateTicket(DateTime? issueAt = null)
        {
            DateTime validIssueAt = issueAt ?? DateTime.Now;
            ValidateIssueTime(validIssueAt);
            return new DailyParkingTicket { IssueAt = validIssueAt };
        }
    }
}
