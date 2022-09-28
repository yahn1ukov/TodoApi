using MediatR;
using TodoApi.Application.Authentication.Common;

namespace TodoApi.Application.Authentication.Commands;

public record LoginCommand(string Username, string Password) : IRequest<LoginResult>;