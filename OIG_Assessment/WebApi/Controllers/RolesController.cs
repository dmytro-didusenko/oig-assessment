using Application.Role.Commands.Create;
using Application.Role.Commands.Update;
using Domain.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RolesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Add Role with permissions
        /// </summary>
        /// <param name="role"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateRoleDto role, CancellationToken cancellationToken)
        {
            var command = new CreateRoleCommand()
            {
                Name = role.Name,
                OrganizationId = role.OrganizationId,
                RolePermissions = role.Permissions
            };

            var id = await _mediator.Send(command, cancellationToken);
            return Ok(id);
        }

        /// <summary>
        /// Update Role entity
        /// </summary>
        /// <param name="role"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdateRoleDto role, CancellationToken cancellationToken)
        {
            try
            {
                var command = new UpdateRoleCommand()
                {
                    Id = role.Id,
                    Name = role.Name,
                    OrganizationId = role.OrganizationId,
                    RolePermissions = role.RolePermissions
                };

                var id = await _mediator.Send(command, cancellationToken);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
