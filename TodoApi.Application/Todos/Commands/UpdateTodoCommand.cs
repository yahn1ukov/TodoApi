using MediatR;
using TodoApi.Application.Todos.Common;

namespace TodoApi.Application.Todos.Commands;

public record UpdateTodoCommand(Guid TodoId, string Text) : IRequest<bool>;