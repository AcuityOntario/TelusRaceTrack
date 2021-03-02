using System.Collections.Generic;

namespace RaceTrack.Models
{
    public interface IRaceTrackRepository
    {
        Vehicle Add(Vehicle vehicle);
        IEnumerable<Vehicle> GetAllVehicles();
        int GetVehicleCount();
        void Remove(int id);
    }
}