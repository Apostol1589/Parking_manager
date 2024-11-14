
namespace TaxCalculationSdk
{
    public class TaxCalculationSdk : ITaxCalculationSdk
    {
        public decimal CalculateTax(TaxModel model)
        {
            decimal tax = 0.1m
                         - (model.BlackPlate ? 0.05m : 0)
                         + (model.LicenceCountry != "Ukraine" ? 0.1m : 0)
                         + (model.ParkingLocation != "Kyiv" ? 0.05m : 0);

            return tax;
        }
    }
}
