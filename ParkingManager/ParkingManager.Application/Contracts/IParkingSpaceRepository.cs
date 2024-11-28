﻿
using ParkingManager.Domain.Entities;
using System.Collections.ObjectModel;

namespace ParkingManager.Application.Contracts
{
    public interface IParkingSpaceRepository : IRepository<ParkingSpace>
    {
        public Task<ReadOnlyCollection<ParkingSpace>> Get();
        public Task<ParkingSpace?> Get(int id);
        public Task<ReadOnlyCollection<ParkingSpace>> Get(Func<ParkingSpace, bool> predicate);
        public Task Create(ParkingSpace entity);
        public Task Update(ParkingSpace entity);
        public Task Delete(int id);
    }
}