
using Microsoft.EntityFrameworkCore;
using ParkingManager.Infrastructure.Data;
using ParkingManager.Domain.Entities;
using System.Collections.ObjectModel;

namespace ParkingManager.Infrastructure.Repositories.VehicleRepo
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly AppDbContext _context;

        public VehicleRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Create(Vehicle entity)
        {
            await _context.Vehicles.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _context.Vehicles.FirstOrDefaultAsync(e => e.Id == id);
            if (entity != null)
            {
                _context.Vehicles.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<ReadOnlyCollection<Vehicle>> Get()
        {
            var vehicles = await _context.Vehicles.ToListAsync();
            return vehicles.AsReadOnly();
        }

        public async Task<Vehicle?> Get(int id)
        {
            return await _context.Vehicles.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<ReadOnlyCollection<Vehicle>> Get(Func<Vehicle, bool> predicate)
        {
            var vehicles = _context.Vehicles.Where(predicate).ToList();
            return await Task.FromResult(vehicles.AsReadOnly());
        }

        public async Task Update(Vehicle entity)
        {
            var existingEntity = await _context.Vehicles.FirstOrDefaultAsync(e => e.Id == entity.Id);
            if (existingEntity != null)
            {
                existingEntity.LicencePlate = entity.LicencePlate;
                existingEntity.Mark = entity.Mark;
                existingEntity.Model = entity.Model;
                existingEntity.Color = entity.Color;

                await _context.SaveChangesAsync();
            }
        }
    }


}
