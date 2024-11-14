using ParkingManager.DataAccess.Entities;
using System.ComponentModel.DataAnnotations;

namespace ParkingManager.BusinessLogic.Builder
{
    public class VehicleBuilder : IVehicleBuilder
    {
        private string _licencePlate;
        private string _mark;
        private string _model;
        private string _color;

        public IVehicleBuilder SetLicencePlate(string licencePlate)
        {
            _licencePlate = licencePlate;
            return this;
        }

        public IVehicleBuilder SetMark(string mark)
        {
            _mark = mark;
            return this;
        }

        public IVehicleBuilder SetModel(string model)
        {
            _model = model;
            return this;
        }

        public IVehicleBuilder SetColor(string color)
        {
            _color = color;
            return this;
        }

        public Vehicle Build()
        {
            if (string.IsNullOrWhiteSpace(_licencePlate))
                throw new ValidationException("LicencePlate is required.");
            if (string.IsNullOrWhiteSpace(_mark))
                throw new ValidationException("Mark is required.");
            if (string.IsNullOrWhiteSpace(_model))
                throw new ValidationException("Model is required.");

            return new Vehicle
            {
                LicencePlate = _licencePlate,
                Mark = _mark,
                Model = _model,
                Color = _color
            };
        }
    }
}
