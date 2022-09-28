namespace TodoApi.Api.Contracts.Todo;

public record GetTodoResponse(Guid Id, string Text, DateTimeOffset CreatedAt);