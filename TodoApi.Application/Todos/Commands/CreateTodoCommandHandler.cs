using MediatR;
using TodoApi.Application.Common.Exception.Errors;
using TodoApi.Domain.Entities;
using TodoApi.Domain.Repositories;

namespace TodoApi.Application.Todos.Commands;

public class CreateTodoCommandHandler : IRequestHandler<CreateTodoCommand, bool>
{
    private readonly IUserRepository _userRepository;
    private readonly ITodoRepository _todoRepository;

    public CreateTodoCommandHandler(IUserRepository userRepository, ITodoRepository todoRepository)
    {
        _userRepository = userRepository;
        _todoRepository = todoRepository;
    }

    public async Task<bool> Handle(CreateTodoCommand command, CancellationToken cancellationToken)
    {
        if (await _userRepository.GetByHttpContextId() is not User user)
        {
            throw new UserNotFoundException();
        }

        var todo = new Todo
        {
            Text = command.Text,
            UserId = user.Id
        };

        await _todoRepository.Create(todo);

        return true;
    }
}
