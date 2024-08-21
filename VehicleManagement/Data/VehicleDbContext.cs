using Microsoft.EntityFrameworkCore;
using VehicleManagement.Models;

namespace VehicleManagement.Data
{
    public class VehicleDbContext:DbContext
    {
        public VehicleDbContext(DbContextOptions<VehicleDbContext> options) : base(options) { }
        public DbSet<Vehicle> Vehicles { get; set; }

        
    }
}
