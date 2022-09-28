using AutoMapper;
using TodoApi.Api.Contracts.Todo;
using TodoApi.Application.Todos.Commands;
using TodoApi.Application.Todos.Common;

namespace TodoApi.Api.Common.Mapper;

public class TodoMappingProfile : Profile
{
    public TodoMappingProfile()
    {
       CreateMap<CreateTodoRequest, CreateTodoCommand>();
       CreateMap<GetTodoResult, GetTodoResponse>();
    }
}