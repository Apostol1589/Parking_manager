using ParkingManager.Domain.Contracts;
using ParkingManager.Infrastructure.Data;
using ParkingManager.Applic.DTO;
using ParkingManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
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

        public async Task Create(VehicleDTO dto)
        {
            var entity = VehicleMapper.ToEntity(dto);
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

        public async Task<ReadOnlyCollection<VehicleDTO>> Get()
        {
            var vehicles = await _context.Vehicles.ToListAsync();
            var vehicleDTOs = vehicles.Select(VehicleMapper.ToDTO).ToList();
            return vehicleDTOs.AsReadOnly();
        }

        public async Task<VehicleDTO?> Get(int id)
        {
            var entity = await _context.Vehicles.FirstOrDefaultAsync(e => e.Id == id);
            return entity != null ? VehicleMapper.ToDTO(entity) : null;
        }

        public async Task<ReadOnlyCollection<VehicleDTO>> Get(Func<Vehicle, bool> predicate)
        {
            var vehicles = _context.Vehicles.Where(predicate).ToList();
            var vehicleDTOs = vehicles.Select(VehicleMapper.ToDTO).ToList();
            return await Task.FromResult(vehicleDTOs.AsReadOnly());
        }

        public async Task Update(VehicleDTO dto)
        {
            var entity = await _context.Vehicles.FirstOrDefaultAsync(e => e.Id == dto.Id);
            if (entity != null)
            {
                entity.LicencePlate = dto.LicencePlate;
                entity.Mark = dto.Mark;
                entity.Model = dto.Model;
                entity.Color = dto.Color;

                await _context.SaveChangesAsync();
            }
        }
    }
}
