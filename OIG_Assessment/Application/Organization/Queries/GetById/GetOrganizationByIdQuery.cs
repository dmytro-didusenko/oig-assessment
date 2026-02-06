using Application.Organization.Dtos;
using MediatR;

namespace Application.Organization.Queries.GetById
{
    public class GetOrganizationByIdQuery : IRequest<OrganizationDto>
    {
        public uint Id { get; set; }
    }
}
