using System.ComponentModel.DataAnnotations;

namespace TodoApi.Api.Contracts.Authentication;

public record LoginRequest(
    [Required(ErrorMessage = "Username is a required field")]
    [MinLength(1, ErrorMessage = "Username must be at least 1 character")]
    [MaxLength(12, ErrorMessage = "Username must be at most 12 characters")]
    string Username,

    [Required(ErrorMessage = "Password is a required field")]
    [MinLength(1, ErrorMessage = "Password must be at least 1 character")]
    [MaxLength(20, ErrorMessage = "Password must be at most 20 characters")]
    string Password
);