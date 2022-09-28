using MediatR;
using TodoApi.Application.Common.Exception.Errors;
using TodoApi.Domain.Entities;
using TodoApi.Domain.Repositories;

namespace TodoApi.Application.Todos.Commands;

public class DeleteTodoCommandHandler : IRequestHandler<DeleteTodoCommand, bool>
{
    private readonly ITodoRepository _todoRepository;

    public DeleteTodoCommandHandler(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;   
    }

    public async Task<bool> Handle(DeleteTodoCommand command, CancellationToken cancellationToken)
    {
        if(await _todoRepository.GetById(command.TodoId) is not Todo todo)
        {
            throw new TodoNotFoundException();
        }

        await _todoRepository.Delete(todo);

        return true;
    }
}