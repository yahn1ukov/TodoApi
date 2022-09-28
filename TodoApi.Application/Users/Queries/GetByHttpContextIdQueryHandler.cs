using MediatR;
using TodoApi.Application.Common.Exception.Errors;
using TodoApi.Application.Users.Common;
using TodoApi.Domain.Entities;
using TodoApi.Domain.Repositories;

namespace TodoApi.Application.Users.Queries;

public class GetByHttpContextIdQueryHandler : IRequestHandler<GetByHttpContextIdQuery, GetUserResult>
{
    private readonly IUserRepository _userRepository;

    public GetByHttpContextIdQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<GetUserResult> Handle(GetByHttpContextIdQuery query, CancellationToken cancellationToken)
    {
        if (await _userRepository.GetByHttpContextId() is not User user)
        {
            throw new UserNotFoundException();
        }

        return new GetUserResult(user.Username);
    }
}