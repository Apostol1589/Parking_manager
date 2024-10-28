using Microsoft.EntityFrameworkCore;
using ParkingManager.DataAccess.Data;
using ParkingManager.DataAccess.Entities;
using System.Collections.ObjectModel;
namespace ParkingManager.DataAccess.Repositories.ParkingLotRepo
{
    public class ParkingLotRepository : IParkingLotRepository
    {
        private readonly AppDbContext _context;

        public ParkingLotRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Create(ParkingLot entity)
        {
            await _context.ParkingLots.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _context.ParkingLots.FirstOrDefaultAsync(e => e.Id == id);
            if (entity != null)
            {
                _context.ParkingLots.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<ReadOnlyCollection<ParkingLot>> Get()
        {
            var parkingLots = await _context.ParkingLots.ToListAsync();
            return parkingLots.AsReadOnly();
        }

        public async Task<ParkingLot?> Get(int id)
        {
            return await _context.ParkingLots.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<ReadOnlyCollection<ParkingLot>> Get(Func<ParkingLot, bool> predicate)
        {
            var parkingLots = _context.ParkingLots.Where(predicate).ToList();
            return await Task.FromResult(parkingLots.AsReadOnly());
        }

        public async Task Update(ParkingLot entity)
        {
            var existingEntity = await _context.ParkingLots.FirstOrDefaultAsync(e => e.Id == entity.Id);
            if (existingEntity != null)
            {
                existingEntity.Location = entity.Location;
                existingEntity.Name = entity.Name;

                await _context.SaveChangesAsync();
            }
        }
    }

}
