using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using YourTurnFriend.Domain.Contracts.Services.Security;
using YourTurnFriend.Domain.Entities.User;
using YourTurnFriend.Infra.ExternalServices.Security.Configurations;
using YourTurnFriend.Infra.ExternalServices.Security.Exceptions;

namespace YourTurnFriend.Infra.ExternalServices.Security;

public sealed class TokenService(IConfiguration _configuration) : ITokenService
{
    public Task<string> GenerateTokenAsync(User user, CancellationToken cancellationToken = default)
    {
        var enviroment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

        var securityConfiguration = _configuration.GetSection("Security").Get<SecurityConfiguration>() 
                                        ?? throw new SecurityConfigurationException();

        var tokenHandler = new JwtSecurityTokenHandler();

        var key = Encoding.ASCII.GetBytes(securityConfiguration.Key);

        var symmetricKey = new SymmetricSecurityKey(key);

        var credential = new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha256Signature);

        var secret = new SecurityTokenDescriptor
        {
            Subject = GenerateClaims(user),
            SigningCredentials = credential,
            Expires = enviroment == "Development" 
                        ? DateTime.UtcNow.AddHours(2) 
                        : DateTime.UtcNow.AddDays(30)
        };

        var securityToken = tokenHandler.CreateToken(secret);

        return Task.FromResult(tokenHandler.WriteToken(securityToken));
    }

    private static ClaimsIdentity GenerateClaims(User user)
    {
        var claimsIdentity = new ClaimsIdentity();

        claimsIdentity.AddClaim(new Claim("UserId", user.Username));

        foreach (var role in user.Roles)
        {
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, role.Name));
        }

        return claimsIdentity;
    }
}