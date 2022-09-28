namespace TodoApi.Application.Todos.Common;

public record GetTodoResult(Guid Id, string Text, DateTimeOffset CreatedAt);