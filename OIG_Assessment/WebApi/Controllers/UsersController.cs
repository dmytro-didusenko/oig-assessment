using Application.User.Commands.Create;
using Application.User.Commands.Update;
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
        public async Task<ActionResult> Create([FromBody] CreateUserDto user, CancellationToken cancellationToken)
        {
            var command = new CreateUserCommand() 
            { 
                Name = user.Name,
                Email = user.Email,
                OrganizationId = user.OrganizationId
            };
            
            var id = await _mediator.Send(command, cancellationToken);
            return Ok(id);
        }

        /// <summary>
        /// Update User entity
        /// </summary>
        /// <param name="user"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdateUserDto user, CancellationToken cancellationToken)
        {
            var command = new UpdateUserCommand()
            {
                Id = user.Id,
                Name = user.Name,
                OrganizationId = user.OrganizationId
            };

            var id = await _mediator.Send(command, cancellationToken);
            return Ok(id);
        }
    }
}
