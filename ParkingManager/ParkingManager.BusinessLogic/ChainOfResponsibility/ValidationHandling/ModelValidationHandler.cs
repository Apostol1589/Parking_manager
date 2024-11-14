using Microsoft.Extensions.Logging;
using ParkingManager.DataAccess.Entities;

namespace ParkingManager.BusinessLogic.ChainOfResponsibility.ValidationHandling
{
    public class ModelValidationHandler : Handler<Vehicle>
    {
        public ModelValidationHandler(ILoggerFactory loggerFactory) : base(loggerFactory)
        {
        }

        public override void Handle(Vehicle vehicle)
        {
            if (string.IsNullOrWhiteSpace(vehicle.Model) || vehicle.Model.Trim().Length == 0)
            {
                throw new ArgumentException("Model cannot be empty or contain only spaces.");
            }

            base.Handle(vehicle);
        }
    }
}
