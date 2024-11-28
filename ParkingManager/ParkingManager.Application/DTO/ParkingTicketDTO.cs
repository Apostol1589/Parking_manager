using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkingManager.Application.DTO
{
    public class ParkingTicketDTO
    {
        [Required]
        public DateTime IssueAt { get; set; } = DateTime.Now;

        [Required]
        public DateTime? ExitedAt { get; set; }

        [Required]
        public decimal Cost { get; set; }

        [ForeignKey(nameof(ParkingSpace))]
        public int ParkingSpaceId { get; set; }
        public ParkingSpaceDTO ParkingSpace { get; set; } = null!;

        [ForeignKey(nameof(Vehicle))]
        public int VehicleId { get; set; }
        public VehicleDTO Vehicle { get; set; } = null!;

    }
}
