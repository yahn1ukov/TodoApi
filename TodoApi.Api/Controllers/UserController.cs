using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Api.Contracts.User;
using TodoApi.Application.Users.Queries;

namespace TodoApi.Api.Controllers;

[Authorize(Roles = "USER")]
[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public UserController(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetByHttpContextId()
    {
        var query = new GetByHttpContextIdQuery();

        var result = await _mediator.Send(query);

        return Ok(_mapper.Map<GetUserResponse>(result));
    }
}