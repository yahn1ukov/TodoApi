using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using TodoApi.Application.Common.Interfaces.Authentication;

namespace TodoApi.Infrastructure.Common.Authentication;

public class UserAccessor : IUserAccessor
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserAccessor(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public Guid GetId()
        => Guid.Parse(_httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "");
}