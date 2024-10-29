using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkingManager.DataAccess.Entities
{
    public class ParkingTicket : BaseEntity
    {
        [Required]
        public DateTime IssueAt { get; set; } = DateTime.Now;

        [Required]
        public DateTime? ExitedAt { get; set; }

        [Required]
        public decimal Cost { get; set; }

        [ForeignKey(nameof(ParkingSpace))]
        public int ParkingSpaceId { get; set; }
        public ParkingSpace ParkingSpace { get; set; } = null!;

        [ForeignKey(nameof(Vehicle))]
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; } = null!;

    }
}
