using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ParkingManager.DataAccess.Entities
{
    public class ParkingSpace : BaseEntity
    {
        [Required]
        public string SpaceNumber { get; set; }

        [ForeignKey(nameof(ParkingLot))]
        public int ParkingLotId { get; set; }
        public ParkingLot ParkingLot { get; set; } = null!;

    }
}
