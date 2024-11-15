using System.ComponentModel.DataAnnotations;


namespace ParkingManager.Domain.Entities
{
    public class ParkingLot : BaseEntity
    {

        [Required]
        public string Name { get; set; }

        [Required]
        public string Location { get; set; }


    }
}
