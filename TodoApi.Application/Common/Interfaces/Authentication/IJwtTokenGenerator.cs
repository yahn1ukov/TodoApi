using TodoApi.Domain.Entities;

namespace TodoApi.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string Generate(User user);
}