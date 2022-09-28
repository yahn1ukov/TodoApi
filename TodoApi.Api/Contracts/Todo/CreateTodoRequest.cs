using System.ComponentModel.DataAnnotations;

namespace TodoApi.Api.Contracts.Todo;

public record CreateTodoRequest
(
    [Required(ErrorMessage = "Text is a required field")]
    [MinLength(1, ErrorMessage = "Text must be at least 1 character")]
    [MaxLength(50, ErrorMessage = "Text must be at most 50 characters")]
    string Text
);