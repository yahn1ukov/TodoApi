using MediatR;
using TodoApi.Application.Authentication.Common;
using TodoApi.Application.Common.Exception.Errors;
using TodoApi.Application.Common.Interfaces.Authentication;
using TodoApi.Domain.Entities;
using TodoApi.Domain.Repositories;

namespace TodoApi.Application.Authentication.Commands;

public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResult>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IPasswordHashGenerator _passwordHashGenerator;

    public LoginCommandHandler(
        IUserRepository userRepository,
        IJwtTokenGenerator jwtTokenGenerator,
        IPasswordHashGenerator passwordHashGenerator
    )
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
        _passwordHashGenerator = passwordHashGenerator;
    }

    public async Task<LoginResult> Handle(LoginCommand command, CancellationToken cancellationToken)
    {
        if(await _userRepository.GetByUsername(command.Username) is not User user)
        {
            _passwordHashGenerator.Generate(command.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var newUser = new User
            {
                Username = command.Username,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            await _userRepository.Create(newUser);

            return new LoginResult(_jwtTokenGenerator.Generate(newUser));
        }

        if(!(_passwordHashGenerator.Verify(command.Password, user.PasswordHash, user.PasswordSalt)))
        {
            throw new UserInvalidPasswordException();
        }

        return new LoginResult(_jwtTokenGenerator.Generate(user));
    }
}