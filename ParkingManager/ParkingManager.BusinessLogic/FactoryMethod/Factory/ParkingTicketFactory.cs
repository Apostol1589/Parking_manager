using Microsoft.Extensions.Logging;
using ParkingManager.BusinessLogic.FactoryMethod.TikcetT;

namespace ParkingManager.BusinessLogic.FactoryMethod.Factory
{
    public abstract class ParkingTicketFactory
    {
        

        public abstract IParkingTicket CreateTicket(DateTime? issueAt = null);

        protected void ValidateIssueTime(DateTime issueAt)
        {
            if (issueAt > DateTime.Now)
            {
                throw new ArgumentException("Issue time cannot be in the future.");
            }
        }

        protected decimal ApplyDiscount(decimal cost, decimal discountRate)
        {
            return cost * (1 - discountRate);
        }

    }
}
