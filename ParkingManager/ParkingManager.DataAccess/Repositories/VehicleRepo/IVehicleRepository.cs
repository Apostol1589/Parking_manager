﻿using ParkingManager.DataAccess.Entities;
using System.Collections.ObjectModel;

namespace ParkingManager.DataAccess.Repositories.VehicleRepo
{
    public interface IVehicleRepository : IRepository<Vehicle>
    {
        public Task<ReadOnlyCollection<Vehicle>> Get();
        public Task<Vehicle?> Get(int id);
        public Task<ReadOnlyCollection<Vehicle>> Get(Func<Vehicle, bool> predicate);
        public Task Create(Vehicle entity);
        public Task Update(Vehicle entity);
        public Task Delete(int id);
    }
}
