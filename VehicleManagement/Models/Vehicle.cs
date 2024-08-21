using System.ComponentModel.DataAnnotations;

namespace VehicleManagement.Models
{
    public class Vehicle
    {
        
        public int Id { get; set; }
        public string Regno { get; set; }

        public string Model { get; set; }

        public DateTime Mfgdate { get; set; }
    }
}
