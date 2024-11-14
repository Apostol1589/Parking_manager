using Microsoft.Extensions.Logging;
using ParkingManager.DataAccess.Entities;

namespace ParkingManager.BusinessLogic.ChainOfResponsibility.ValidationHandling
{
    internal class LicencePlateValidationHandler : Handler<Vehicle>
    {
        public LicencePlateValidationHandler(ILoggerFactory loggerFactory) : base(loggerFactory)
        {
        }

        public override void Handle(Vehicle vehicle)
        {
            if (string.IsNullOrWhiteSpace(vehicle.LicencePlate) || vehicle.LicencePlate.Trim().Length == 0)
            {
                throw new ArgumentException("License plate must be 6-8 alphanumeric characters with no spaces.");
            }
            base.Handle(vehicle);
        }
    }
}

