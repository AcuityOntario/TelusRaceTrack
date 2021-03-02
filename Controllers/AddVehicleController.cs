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
        public ActionResult Index()
        {
            return View("AddVehicle");
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
                        ModelState.AddModelError("", "Track Full");
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
                        ModelState.AddModelError("", "Track Full");
                    }
                }
            }

            return View("home");
        }

        //// GET: AddVehicle
        //public ActionResult Index()
        //{
        //    return View(db.Vehicles.ToList());
        //}

        //// GET: AddVehicle/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Vehicle vehicle = db.Vehicles.Find(id);
        //    if (vehicle == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(vehicle);
        //}

        //// GET: AddVehicle/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: AddVehicle/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,TowStrap,VehicleType")] Vehicle vehicle)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Vehicles.Add(vehicle);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(vehicle);
        //}

        //// GET: AddVehicle/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Vehicle vehicle = db.Vehicles.Find(id);
        //    if (vehicle == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(vehicle);
        //}

        //// POST: AddVehicle/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,TowStrap,VehicleType")] Vehicle vehicle)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(vehicle).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(vehicle);
        //}

        //// GET: AddVehicle/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Vehicle vehicle = db.Vehicles.Find(id);
        //    if (vehicle == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(vehicle);
        //}

        //// POST: AddVehicle/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Vehicle vehicle = db.Vehicles.Find(id);
        //    db.Vehicles.Remove(vehicle);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
