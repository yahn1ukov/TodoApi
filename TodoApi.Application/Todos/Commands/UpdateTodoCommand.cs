using MediatR;

namespace TodoApi.Application.Todos.Commands;

public record UpdateTodoCommand(Guid TodoId, string Text) : IRequest<bool>;
