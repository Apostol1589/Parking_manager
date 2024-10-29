using System.ComponentModel.DataAnnotations;


namespace ParkingManager.DataAccess.Entities
{
    public class Vehicle : BaseEntity
    {

        [Required]
        public string LicencePlate { get; set; }

        [Required]
        public string Mark { get; set; }

        [Required]
        public string Model { get; set; }

        public string Color { get; set; }
    }
}
