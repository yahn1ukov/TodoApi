using MediatR;
using TodoApi.Application.Todos.Common;

namespace TodoApi.Application.Todos.Queries;

public record GetAllTodoByHttpContextIdQuery() : IRequest<ICollection<GetTodoResult>>;