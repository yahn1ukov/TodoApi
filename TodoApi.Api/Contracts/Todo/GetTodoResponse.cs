namespace TodoApi.Api.Contracts.Todo;

public record GetTodoResponse(Guid Id, string Text, bool IsEdited, DateTime CreatedAt);
