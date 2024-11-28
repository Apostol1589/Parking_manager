﻿using System.ComponentModel.DataAnnotations;


namespace ParkingManager.Application.DTO
{
    public class ParkingLotDTO
    {

        [Required]
        public string Name { get; set; }

        [Required]
        public string Location { get; set; }


    }
}
