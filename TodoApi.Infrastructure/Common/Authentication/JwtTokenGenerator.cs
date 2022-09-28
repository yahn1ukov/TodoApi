using System.Text;
using System.Security.Claims;
using TodoApi.Application.Common.Interfaces.Authentication;
using TodoApi.Application.Common.Interfaces.Services;
using TodoApi.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace TodoApi.Infrastructure.Common.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly JwtTokenSettings _jwtTokenSettings;

    public JwtTokenGenerator(IDateTimeProvider dateTimeProvider, IOptions<JwtTokenSettings> jwtTokenSettings)
    {
        _dateTimeProvider = dateTimeProvider;
        _jwtTokenSettings = jwtTokenSettings.Value;
    }

    public string Generate(User user)
    {
        var claims = new[] 
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Role, user.Role.ToString())
        };

        var secretKey = Encoding.UTF8.GetBytes(_jwtTokenSettings.Secret);

        var symmetricSecurityKey = new SymmetricSecurityKey(secretKey);

        var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);

        var token = new JwtSecurityToken
        (
            issuer: _jwtTokenSettings.Issuer,
            audience: _jwtTokenSettings.Audience,
            claims: claims,
            expires: _dateTimeProvider.UtcNow.AddHours(_jwtTokenSettings.ExpiryMinutes),
            signingCredentials: signingCredentials
        );

        var tokenHandler = new JwtSecurityTokenHandler();

        return tokenHandler.WriteToken(token);
    }
}