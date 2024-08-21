using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace VehicleManagement
{
    public class JwtTokenManager : IJwtTokenManager
    {
        private readonly IConfiguration _configuration;
        public JwtTokenManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Authenticate(string username, string password)
        {

            var key = _configuration.GetValue<string>("Jwt:Key");
            var keybytes = Encoding.UTF8.GetBytes(key);
            var tokenhandler = new JwtSecurityTokenHandler();

            var tokendescriptor = new SecurityTokenDescriptor {

                Issuer = "localhost",
                Audience = "localhost",
                Subject = new ClaimsIdentity(new Claim[]{

                    new Claim(ClaimTypes.NameIdentifier, username),
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(keybytes),
                    SecurityAlgorithms.HmacSha256Signature)



            };

            var token = tokenhandler.CreateToken(tokendescriptor);
            return tokenhandler.WriteToken(token);

               
               
        }
    }
}
