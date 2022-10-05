namespace TodoApi.Application.Todos.Common;

public record GetTodoResult(Guid Id, string Text, bool IsEdited, DateTime CreatedAt);
