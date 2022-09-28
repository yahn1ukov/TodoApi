using MediatR;
using TodoApi.Application.Users.Common;

namespace TodoApi.Application.Users.Queries;

public record GetByHttpContextIdQuery() : IRequest<GetUserResult>;