using System.ComponentModel.DataAnnotations;


namespace ParkingManager.DataAccess.Entities
{
    public class ParkingLot : BaseEntity
    {

        [Required]
        public string Name { get; set; }

        [Required]
        public string Location { get; set; }


    }
}
