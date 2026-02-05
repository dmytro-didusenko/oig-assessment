using Application.Organization.Dtos;
using MediatR;

namespace Application.Organization.Queries
{
    public class GetOrganizationListQuery : IRequest<IEnumerable<OrganizationDto>>
    {
    }
}
