using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Api.Contracts.Todo;
using TodoApi.Application.Todos.Commands;
using TodoApi.Application.Todos.Queries;

namespace TodoApi.Api.Controllers;

[Authorize(Roles = "USER")]
[ApiController]
[Route("api/todo")]
public class TodoController: ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public TodoController(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateTodoRequest request)
    {
        var command = _mapper.Map<CreateTodoCommand>(request); 
        
        var result = await _mediator.Send(command);

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllTodoByHttpContextIdQuery();

        var result = await _mediator.Send(query);

        return Ok
        (
            result
                .Select(r => _mapper.Map<GetTodoResponse>(r))
                .ToList()
        );
    }

    [HttpGet("desc")]
    public async Task<IActionResult> GetAllDescByDesc()
    {
        var query = new GetAllTodoByHttpContextIdQuery();

        var result = await _mediator.Send(query);

        return Ok
        (
            result
                .Select(r => _mapper.Map<GetTodoResponse>(r))
                .Reverse()
                .ToList()
        );
    }

    [HttpGet]
    public async Task<IActionResult> GetAllBySearch(string search)
    {
        var query = new GetAllTodoByHttpContextIdQuery();

        var result = await _mediator.Send(query);

        return Ok
        (
            result
                .Where(r => r.Text.Contains(search))
                .Select(r => _mapper.Map<GetTodoResponse>(r))
                .ToList()
        );
    }

    [HttpPatch("{todoId}")]
    public async Task<IActionResult> Update(Guid todoId, UpdateTodoRequest request)
    {
        var command = new UpdateTodoCommand(todoId, request.Text);

        var result = await _mediator.Send(command);

        return Ok(result);
    }

    [HttpDelete("{todoId}")]
    public async Task<IActionResult> Delete(Guid todoId)
    {
        var command = new DeleteTodoCommand(todoId);

        var result = await _mediator.Send(command);

        return Ok(result);
    }
}