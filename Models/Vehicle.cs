using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RaceTrack.Models
{
    public class Vehicle
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Tow Strap")]
        [Range(typeof(bool), "true", "true", ErrorMessage = "Must be True")]
        public bool TowStrap { get; set; }

        [Display(Name = "Vehicle Type")]
        public VehicleType VehicleType { get; set; }

        public int TrackLimit { get => 5; }

        public virtual bool AllowOnTrack(int currentNumberOnTrack)
        {
            return currentNumberOnTrack < TrackLimit;
        }
    }
}