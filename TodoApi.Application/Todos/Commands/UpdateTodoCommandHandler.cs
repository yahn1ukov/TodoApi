using MediatR;
using TodoApi.Application.Common.Exception.Errors;
using TodoApi.Domain.Entities;
using TodoApi.Domain.Repositories;

namespace TodoApi.Application.Todos.Commands;

public class UpdateTodoCommandHandler : IRequestHandler<UpdateTodoCommand, bool>
{
    private readonly ITodoRepository _todoRepository;

    public UpdateTodoCommandHandler(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public async Task<bool> Handle(UpdateTodoCommand command, CancellationToken cancellationToken)
    {
        if (await _todoRepository.GetById(command.TodoId) is not Todo todo)
        {
            throw new TodoNotFoundException();
        }

        todo.Text = command.Text;
        todo.IsEdited = true;

        await _todoRepository.Update(todo);

        return true;
    }
}
