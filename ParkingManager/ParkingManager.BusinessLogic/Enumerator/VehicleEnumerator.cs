using System.Collections;
using ParkingManager.DataAccess.Entities;

namespace ParkingManager.BusinessLogic.Enumerator
{
    public class VehicleEnumerator : IEnumerator<Vehicle>
    {
        private readonly List<Vehicle> _vehicles;
        private int _position = -1;

        public VehicleEnumerator(List<Vehicle> vehicles)
        {
            _vehicles = vehicles;
        }

        public Vehicle Current => _vehicles[_position];

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            _position++;
            return _position < _vehicles.Count;
        }

        public void Reset()
        {
            _position = -1;
        }

        public void Dispose()
        {
        }
    }
}
