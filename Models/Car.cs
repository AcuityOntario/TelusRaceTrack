using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RaceTrack.Models
{
    public class Car : Vehicle
    {
        [Required]
        [Range(0, 84, ErrorMessage = "Tire wear must be less than 85%")]
        [Display(Name = "Car Tire Wear")]
        public int TireWear { get; set; }
        public override bool AllowOnTrack(int currentNumberOnTrack)
        {
            if (!TowStrap || TireWear >= 85)
            {
                return false;
            }

            if (TowStrap && TireWear >= 85)
            {
                return false;
            }

            return base.AllowOnTrack(currentNumberOnTrack);
        }
    }
}