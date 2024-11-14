using Microsoft.Extensions.Logging;
using ParkingManager.DataAccess.Entities;

namespace ParkingManager.BusinessLogic.ChainOfResponsibility.ValidationHandling
{

    public class MarkValidationHandler : Handler<Vehicle>
    {
        public MarkValidationHandler(ILoggerFactory loggerFactory) : base(loggerFactory)
        {
        }

        public override void Handle(Vehicle vehicle)
        {
            if (string.IsNullOrWhiteSpace(vehicle.Mark) || vehicle.Mark.Trim().Length == 0)
            {
                throw new ArgumentException("Mark cannot be empty or contain only spaces.");
            }

            base.Handle(vehicle);
        }
    }
}
