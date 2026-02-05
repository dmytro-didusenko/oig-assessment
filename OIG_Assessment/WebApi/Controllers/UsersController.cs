using Application.User.Commands.Create;
using Application.User.Commands.Update;
using Application.User.Dtos;
using Application.User.Queries;
using Domain.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Add User
        /// </summary>
        /// <param name="user"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateUserDto user, CancellationToken cancellationToken = default)
        {
            var command = new CreateUserCommand() 
            { 
                Name = user.Name,
                Email = user.Email,
                OrganizationId = user.OrganizationId
            };
            
            return Ok(await _mediator.Send(command, cancellationToken));
        }

        /// <summary>
        /// Get User by Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetById(uint id, CancellationToken cancellationToken = default)
        {
            var user = await _mediator.Send(new GetUserByIdQuery(id), cancellationToken);
            return user is null ? NotFound() : Ok(user);
        }

        /// <summary>
        /// Get User list
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> List(CancellationToken cancellationToken = default)
        {
            return Ok(await _mediator.Send(new UsersListQuery(), cancellationToken));
        }

        /// <summary>
        /// Update User entity
        /// </summary>
        /// <param name="user"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdateUserDto user, CancellationToken cancellationToken = default)
        {
            var command = new UpdateUserCommand()
            {
                Id = user.Id,
                Name = user.Name,
                OrganizationId = user.OrganizationId
            };

            return Ok(await _mediator.Send(command, cancellationToken));
        }
    }
}
