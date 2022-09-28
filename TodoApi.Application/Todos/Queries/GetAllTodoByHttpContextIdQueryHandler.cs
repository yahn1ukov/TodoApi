using MediatR;
using TodoApi.Application.Todos.Common;
using TodoApi.Domain.Repositories;

namespace TodoApi.Application.Todos.Queries;

public class GetAllTodoByHttpContextIdQueryHandler : IRequestHandler<GetAllTodoByHttpContextIdQuery, ICollection<GetTodoResult>>
{
    private readonly ITodoRepository _todoRepository;

    public GetAllTodoByHttpContextIdQueryHandler(ITodoRepository todoRepository)
    {
       _todoRepository = todoRepository; 
    }

    public async Task<ICollection<GetTodoResult>> Handle(GetAllTodoByHttpContextIdQuery query, CancellationToken cancellationToken)
    {
        var todo = await _todoRepository.GetAllByHttpContextId();
        
        return todo
            .Select(t => new GetTodoResult(t.Id, t.Text, t.CreatedAt))
            .ToList();
    }
}