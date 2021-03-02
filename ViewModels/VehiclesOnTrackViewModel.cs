using RaceTrack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RaceTrack.ViewModels
{
    public class VehiclesOnTrackViewModel
    {
        public IEnumerable<Vehicle> Vehicles { get; set; }

        public int VehicleCount { get; set; }
    }
}