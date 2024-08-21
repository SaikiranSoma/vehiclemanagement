namespace VehicleManagement
{
    public interface IJwtTokenManager
    {
        public string Authenticate(string username,string password);
    }
}
