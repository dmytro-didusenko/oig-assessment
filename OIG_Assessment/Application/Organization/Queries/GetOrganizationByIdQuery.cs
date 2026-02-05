using Application.Organization.Dtos;
using MediatR;

namespace Application.Organization.Queries
{
    public class GetOrganizationByIdQuery(uint id) : IRequest<OrganizationDto>
    {
        public uint Id { get; set; } = id;
    }
}
