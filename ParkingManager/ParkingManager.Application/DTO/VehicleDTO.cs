using System.ComponentModel.DataAnnotations;


namespace ParkingManager.Application.DTO
{
    public class VehicleDTO
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
