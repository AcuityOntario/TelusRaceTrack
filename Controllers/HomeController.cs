using RaceTrack.Models;
using RaceTrack.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RaceTrack.Controllers
{
    public class HomeController : Controller
    {
        private RaceTrackRepository _raceTrackRepository;

        public ActionResult Index()
        {
            _raceTrackRepository = new RaceTrackRepository(new AppDbContext());
            var vehicles = new VehiclesOnTrackViewModel();
            vehicles.Vehicles = _raceTrackRepository.GetAllVehicles();
            vehicles.VehicleCount = vehicles.Vehicles.Count();
            return View(vehicles);
        }

        [HttpPost]
        public ActionResult Remove(string[] remove)
        {
            _raceTrackRepository = new RaceTrackRepository(new AppDbContext());
            foreach (string vehicleId in remove)
            {
                int id;
                if(Int32.TryParse(vehicleId, out id))
                {
                    _raceTrackRepository.Remove(id);
                }
            }
            return View("Index");
        }
    }
}