using MediatR;

namespace TodoApi.Application.Todos.Commands;

public record CreateTodoCommand(string Text) : IRequest<bool>;
