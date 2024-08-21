using VehicleManagement.Models;
using VehicleManagement.Data;
namespace VehicleManagement.Repository
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly VehicleDbContext _dbcontext;

        public VehicleRepository(VehicleDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public bool AddVehicle(VehicleDto vehicle)
        {
            if (vehicle != null) 
            {
                var newvehicle = new Vehicle()
                {
                    Regno = vehicle.Regno,
                    Model = vehicle.Model,
                    Mfgdate = vehicle.Mfgdate,
                };
                _dbcontext.Vehicles.Add(newvehicle);
                _dbcontext.SaveChanges();
                return true;
            }
              return false ;
        }

        public IEnumerable<VehicleDto> GetAllVehicles()
        {
            var result=new List<VehicleDto>();
            var outputlist= _dbcontext.Vehicles.ToList();
            foreach (var vehicle in outputlist)
            {
                var newvehcile = new VehicleDto() { 
                Regno=vehicle.Regno,
                Model = vehicle.Model,
                Mfgdate=vehicle.Mfgdate,

                };
                result.Add(newvehcile);
            }
            return result;
        }

        public bool UpdateVehicle(int Id, VehicleDto vehicle)

        {
            var currentvehicle = _dbcontext.Vehicles.FirstOrDefault(x=>x.Id==Id);
            if (currentvehicle != null) 
            {
                currentvehicle.Model = vehicle.Model;
                currentvehicle.Regno = vehicle.Regno;
                currentvehicle .Mfgdate = vehicle.Mfgdate;
                _dbcontext.SaveChanges();
                return true;
            }

            return false;
        }



        public bool DeleteVehicle(int Id)
        {
            var vehicle = _dbcontext.Vehicles.FirstOrDefault(x=>x.Id==Id);
            if(vehicle != null)
            {
                _dbcontext.Remove(vehicle);
                _dbcontext.SaveChanges();
                return true;
            }
            return false;
        }

    }
}
