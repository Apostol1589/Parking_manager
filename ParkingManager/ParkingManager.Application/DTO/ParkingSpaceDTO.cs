using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ParkingManager.Application.DTO
{
    public class ParkingSpaceDTO
    {
        [Required]
        public string SpaceNumber { get; set; }

        [ForeignKey(nameof(ParkingLot))]
        public int ParkingLotId { get; set; }
        public ParkingLotDTO ParkingLot { get; set; } = null!;

    }
}
