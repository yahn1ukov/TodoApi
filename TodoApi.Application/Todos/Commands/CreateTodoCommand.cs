using MediatR;
using TodoApi.Application.Todos.Common;

namespace TodoApi.Application.Todos.Commands;

public record CreateTodoCommand(string Text) : IRequest<bool>;