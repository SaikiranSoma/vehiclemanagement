using System.Text.Json;

namespace VehicleManagement.Models
{
    public class ErrorMessages
    {
        public int StatusCode { get; set; }

        public string Message { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
