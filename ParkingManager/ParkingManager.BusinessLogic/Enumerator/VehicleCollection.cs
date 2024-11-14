using System.Collections;
using System.Collections.Generic;
using ParkingManager.DataAccess.Entities;

namespace ParkingManager.BusinessLogic.Enumerator
{
    public class VehicleCollection : IEnumerable<Vehicle>
    {
        private List<Vehicle> _vehicles = new List<Vehicle>();

        public void AddVehicle(Vehicle vehicle)
        {
            _vehicles.Add(vehicle);
        }

        public IEnumerator<Vehicle> GetEnumerator()
        {
            return new VehicleEnumerator(_vehicles);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
