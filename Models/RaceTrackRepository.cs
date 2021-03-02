using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RaceTrack.Models
{
    public class RaceTrackRepository : IRaceTrackRepository
    {
        private readonly AppDbContext context;

        public RaceTrackRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Vehicle Add(Vehicle vehicle)
        {
            context.Vehicles.Add(vehicle);
            context.SaveChanges();
            return vehicle;
        }

        public void Remove(int id)
        {
            Vehicle vehicle = context.Vehicles.Find(id);
            if (vehicle != null)
            {
                context.Vehicles.Remove(vehicle);
                context.SaveChanges();
            }
        }

        public IEnumerable<Vehicle> GetAllVehicles()
        {
            return context.Vehicles;
        }

        public int GetVehicleCount()
        {
            return GetAllVehicles().Count<Vehicle>();
        }
     }
}