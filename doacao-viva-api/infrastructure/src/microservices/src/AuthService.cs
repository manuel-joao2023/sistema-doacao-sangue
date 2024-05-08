using DoacaoViva.Application.Auth;
using DoacaoViva.Domain.Auth;
using DoacaoViva.Domain.helper;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DoacaoViva.Infrastructure.Microservices;
public class AuthService : IAuth {
    private readonly IOptions<JwtAuth> _appSettings;

    public AuthService(IOptions<JwtAuth> options)
    {
        _appSettings = options;
    }
    public string GenerateJwtToken(string emailOrPhone, string role) {

        var credentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.Value.Key)),
            SecurityAlgorithms.HmacSha256
        );

        var claims = new List<Claim> {
             new Claim("email", emailOrPhone),
             new Claim(ClaimTypes.Role, role)
        };
        var token = new JwtSecurityToken(
            _appSettings.Value.Issuer, 
            _appSettings.Value.Audience, 
            claims,
            null,
            DateTime.Now.AddHours(3),
            credentials
        );

        return (new JwtSecurityTokenHandler()).WriteToken(token);
    }

    public string GeneretaHashPassword(string password) {
        return EncryptAndDecrypt.Encrypt(password);
    }
}

