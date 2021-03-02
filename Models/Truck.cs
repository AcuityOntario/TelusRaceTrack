using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RaceTrack.Models
{
    public class Truck : Vehicle
    {
        [Required]
        [Range(0, 5, ErrorMessage ="Not lifted more than 5 inches")]
        [Display(Name = "Truck Lift Height")]
        public int LiftHeight { get; set; }
        public override bool AllowOnTrack(int currentNumberOnTrack)
        {
            if(!TowStrap || LiftHeight > 5)
            {
                return false;
            }

            if(TowStrap && LiftHeight > 5)
            {
                return false;
            }

            return base.AllowOnTrack(currentNumberOnTrack);
        }
    }
}