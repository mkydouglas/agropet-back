using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace Agropet.Application.Common.Services;

public class JWTService
{
    public JWTService()
    {
        
    }

    public string CreateToken(List<Claim> claims)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("Agropet-JWT-Key")!));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var handler = new JsonWebTokenHandler();

        var token = handler.CreateToken(new SecurityTokenDescriptor
        {
            Issuer = Environment.GetEnvironmentVariable("Agropet-JWT-Issuer"),
            Audience = Environment.GetEnvironmentVariable("Agropet-JWT-Audience"),
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddHours(24),
            SigningCredentials = creds
        });

        return token;
    }
}
