using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Api.Contracts.Authentication;
using TodoApi.Application.Authentication.Commands;

namespace TodoApi.Api.Controllers;

[ApiController]
[Route("api/authentication")]
public class AuthenticationController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public AuthenticationController(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var command = _mapper.Map<LoginCommand>(request);

        var result = await _mediator.Send(command);

        return Ok(_mapper.Map<LoginResponse>(result));
    }
}