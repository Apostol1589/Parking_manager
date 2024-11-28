using Microsoft.EntityFrameworkCore;
using ParkingManager.Infrastructure.Data;
using ParkingManager.Domain.Entities;
using System.Collections.ObjectModel;
using ParkingManager.Domain.Contracts;

namespace ParkingManager.Infrastructure.Repositories.ParkingTicketRepo
{
    public class ParkingTicketRepository : IParkingTicketRepository
    {
        private readonly AppDbContext _context;

        public ParkingTicketRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Create(ParkingTicket entity)
        {
            await _context.ParkingTickets.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _context.ParkingTickets.FirstOrDefaultAsync(e => e.Id == id);
            if (entity != null)
            {
                _context.ParkingTickets.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<ReadOnlyCollection<ParkingTicket>> Get()
        {
            var parkingTickets = await _context.ParkingTickets.ToListAsync();
            return parkingTickets.AsReadOnly();
        }

        public async Task<ParkingTicket?> Get(int id)
        {
            return await _context.ParkingTickets.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<ReadOnlyCollection<ParkingTicket>> Get(Func<ParkingTicket, bool> predicate)
        {
            var parkingTickets = _context.ParkingTickets.Where(predicate).ToList();
            return await Task.FromResult(parkingTickets.AsReadOnly());
        }

        public async Task Update(ParkingTicket entity)
        {
            var existingEntity = await _context.ParkingTickets.FirstOrDefaultAsync(e => e.Id == entity.Id);
            if (existingEntity != null)
            {
                existingEntity.IssueAt = entity.IssueAt;
                existingEntity.ExitedAt = entity.ExitedAt;
                existingEntity.Cost = entity.Cost;
                existingEntity.ParkingSpaceId = entity.ParkingSpaceId;
                existingEntity.VehicleId = entity.VehicleId;

                await _context.SaveChangesAsync();
            }
        }
    }


}
