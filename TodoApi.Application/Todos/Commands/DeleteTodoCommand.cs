using MediatR;

namespace TodoApi.Application.Todos.Commands;

public record DeleteTodoCommand(Guid TodoId) : IRequest<bool>;