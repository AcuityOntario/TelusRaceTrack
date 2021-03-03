using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RaceTrack.Models;
using RaceTrack.ViewModels;

namespace RaceTrack.Controllers
{
    public class AddVehicleController : Controller
    {
        private readonly AppDbContext dbContext = new AppDbContext();
        private RaceTrackRepository _raceTrackRepository;

        [HttpGet]
        public ActionResult AddVehicle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddVehicle(AddVehicleViewModel model)
        {
            if(ModelState.IsValid)
            {
                _raceTrackRepository = new RaceTrackRepository(dbContext);

                if (model.Vehicle.VehicleType == VehicleType.Truck)
                {
                    Truck newTruck = new Truck
                    {
                        TowStrap = model.Vehicle.TowStrap,
                        LiftHeight = model.TruckLiftHeight,
                        VehicleType = model.Vehicle.VehicleType
                    };

                    if(newTruck.AllowOnTrack(_raceTrackRepository.GetVehicleCount()))
                    {
                        _raceTrackRepository.Add(newTruck);
                    }
                    else
                    {
                        ModelState.AddModelError("", "Not allowed");
                    }
                }

                if (model.Vehicle.VehicleType == VehicleType.Car)
                {
                    Car newCar = new Car
                    {
                        TowStrap = model.Vehicle.TowStrap,
                        TireWear = model.CarTireWear,
                        VehicleType = model.Vehicle.VehicleType
                    };

                    if (newCar.AllowOnTrack(_raceTrackRepository.GetVehicleCount()))
                    {
                        _raceTrackRepository.Add(newCar);
                    }
                    else
                    {
                        ModelState.AddModelError("", "Not allowed");
                    }
                }
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
