using Microsoft.EntityFrameworkCore;
using ParkingManager.DataAccess.Entities;

namespace ParkingManager.DataAccess.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> context) 
            : base(context) { }
        
        public DbSet<ParkingLot> ParkingLots { get; set; }
        public DbSet<ParkingSpace> ParkingSpaces { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<ParkingTicket> ParkingTickets { get; set; }
    }
}
