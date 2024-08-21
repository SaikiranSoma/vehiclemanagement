using VehicleManagement.Models;
using VehicleManagement.Data;
using System.Collections;

namespace VehicleManagement.Repository
{
    public interface IVehicleRepository
    {
        public IEnumerable<VehicleDto> GetAllVehicles();
        public bool AddVehicle(VehicleDto vehicle);
        public bool UpdateVehicle(int Id, VehicleDto vehicle);
        public bool DeleteVehicle(int Id);


    }
}
