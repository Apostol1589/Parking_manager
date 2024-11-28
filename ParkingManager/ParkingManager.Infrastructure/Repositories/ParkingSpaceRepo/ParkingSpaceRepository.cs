
using Microsoft.EntityFrameworkCore;
using ParkingManager.Infrastructure.Data;
using ParkingManager.Domain.Entities;
using System.Collections.ObjectModel;
using ParkingManager.Domain.Contracts;

namespace ParkingManager.Infrastructure.Repositories.ParkingSpaceRepo
{
    public class ParkingSpaceRepository : IParkingSpaceRepository
    {
        private readonly AppDbContext _context;

        public ParkingSpaceRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Create(ParkingSpace entity)
        {
            await _context.ParkingSpaces.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _context.ParkingSpaces.FirstOrDefaultAsync(e => e.Id == id);
            if (entity != null)
            {
                _context.ParkingSpaces.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<ReadOnlyCollection<ParkingSpace>> Get()
        {
            var parkingSpaces = await _context.ParkingSpaces.ToListAsync();
            return parkingSpaces.AsReadOnly();
        }

        public async Task<ParkingSpace?> Get(int id)
        {
            return await _context.ParkingSpaces.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<ReadOnlyCollection<ParkingSpace>> Get(Func<ParkingSpace, bool> predicate)
        {
            var parkingSpaces = _context.ParkingSpaces.Where(predicate).ToList();
            return await Task.FromResult(parkingSpaces.AsReadOnly());
        }

        public async Task Update(ParkingSpace entity)
        {
            var existingEntity = await _context.ParkingSpaces.FirstOrDefaultAsync(e => e.Id == entity.Id);
            if (existingEntity != null)
            {
                existingEntity.SpaceNumber = entity.SpaceNumber;
                existingEntity.ParkingLotId = entity.ParkingLotId;
                await _context.SaveChangesAsync();
            }
        }
    }


}
