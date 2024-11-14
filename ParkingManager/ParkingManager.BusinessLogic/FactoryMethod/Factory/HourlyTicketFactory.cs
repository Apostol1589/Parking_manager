
using Microsoft.Extensions.Logging;
using ParkingManager.BusinessLogic.FactoryMethod.TikcetT;

namespace ParkingManager.BusinessLogic.FactoryMethod.Factory
{

    public class HourlyTicketFactory : ParkingTicketFactory
    {
        public HourlyTicketFactory() { }

        public override IParkingTicket CreateTicket(DateTime? issueAt = null)
        {
            DateTime validIssueAt = issueAt ?? DateTime.Now;
            ValidateIssueTime(validIssueAt);
            return new HourlyParkingTicket { IssueAt = validIssueAt };
        }
    }
}
