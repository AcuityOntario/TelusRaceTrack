using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RaceTrack.Models
{
    public class AppDbContext : DbContext
    {
         public DbSet<Vehicle> Vehicles { get; set; }
    }
}