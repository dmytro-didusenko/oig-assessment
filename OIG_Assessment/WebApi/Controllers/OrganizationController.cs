using Application.Dtos.OrganizationTree;
using Application.Organization.Commands.Create;
using Application.Organization.Commands.Update;
using Application.Organization.Dtos;
using Application.Organization.Queries.GetById;
using Application.Organization.Queries.GetHierarchy;
using Application.Organization.Queries.GetList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrganizationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Add Organization
        /// </summary>
        /// <param name="organization"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateOrganizationDto organization, CancellationToken cancellationToken = default)
        {
            var command = new CreateOrganizationCommand()
            {
                Name = organization.Name,
                ParentId = organization.ParentId
            };

            return Ok(await _mediator.Send(command, cancellationToken));
        }

        /// <summary>
        /// Get Organization by Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<OrganizationDto>> GetById(uint id, CancellationToken cancellationToken = default)
        {
            var organization = await _mediator.Send(new GetOrganizationByIdQuery { Id = id }, cancellationToken);
            return organization is null ? NotFound() : Ok(organization);
        }

        /// <summary>
        /// Get Organizations list
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("list")]
        public async Task<ActionResult<IEnumerable<OrganizationDto>>> List(CancellationToken cancellationToken = default)
        {
            return Ok(await _mediator.Send(new GetOrganizationListQuery(), cancellationToken));
        }

        /// <summary>
        /// Get Organizations hierarchy list
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("hierarchy")]
        public async Task<ActionResult<IEnumerable<OrganizationNode>>> HierarchyList(CancellationToken cancellationToken = default)
        {
            return Ok(await _mediator.Send(new GetOrganizationHierarchyQuery(), cancellationToken));
        }

        /// <summary>
        /// Update User entity
        /// </summary>
        /// <param name="user"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdateOrganizationDto organization, CancellationToken cancellationToken = default)
        {
            var command = new UpdateOrganizationCommand()
            {
                Id = organization.Id,
                Name = organization.Name,
                ParentId = organization.ParentId
            };

            return Ok(await _mediator.Send(command, cancellationToken));
        }
    }
}
