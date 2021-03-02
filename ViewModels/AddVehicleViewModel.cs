using RaceTrack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RaceTrack.ViewModels
{
    public class AddVehicleViewModel
    {
        public Vehicle Vehicle { get; set; }

        public int TruckLiftHeight { get; set; }

        public int CarTireWear { get; set; }
    }
}