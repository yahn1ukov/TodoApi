using AutoMapper;
using TodoApi.Api.Contracts.User;
using TodoApi.Application.Users.Common;

namespace TodoApi.Api.Common.Mapper;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<GetUserResult, GetUserResponse>();
    }
}