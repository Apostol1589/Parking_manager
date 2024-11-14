using ParkingManager.DataAccess.Entities;
using TaxCalculationSdk;

namespace ParkingManager.BusinessLogic.Adapters
{
    public class TaxCalculationAdapter : ITaxCalculationAdapter
    {
        private readonly ITaxCalculationSdk _sdk;
        public TaxCalculationAdapter(ITaxCalculationSdk sdk)
        {
            _sdk = sdk;
        }

        public decimal CalculateTax(Vehicle vehicle, ParkingLot lot)
        {
            bool isBlackPlate = vehicle.LicencePlate.Contains("D") ||
                    vehicle.LicencePlate.Contains("DP") ||
                    vehicle.LicencePlate.Contains("CDP") ||
                    vehicle.LicencePlate.Contains("S");

            string licenceCountry = vehicle.LicencePlate.Contains("UA") ? "Ukraine" : "Other";

            var taxModel = new TaxModel
            {
                BlackPlate = isBlackPlate,
                LicenceCountry = licenceCountry,
                ParkingLocation = lot.Location
            };

            return _sdk.CalculateTax(taxModel);
        }
    }
}
