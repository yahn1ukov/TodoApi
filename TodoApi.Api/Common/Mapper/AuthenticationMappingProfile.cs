using AutoMapper;
using TodoApi.Api.Contracts.Authentication;
using TodoApi.Application.Authentication.Commands;
using TodoApi.Application.Authentication.Common;

namespace TodoApi.Api.Common.Mapper;

public class AuthenticationMappingProfile : Profile
{
    public AuthenticationMappingProfile()
    {
        CreateMap<LoginRequest, LoginCommand>();
        CreateMap<LoginResult, LoginResponse>();
    }
}