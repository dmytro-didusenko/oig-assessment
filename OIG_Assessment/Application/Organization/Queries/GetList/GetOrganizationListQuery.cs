using Application.Organization.Dtos;
using MediatR;

namespace Application.Organization.Queries.GetList
{
    public class GetOrganizationListQuery : IRequest<IEnumerable<OrganizationDto>>
    {
    }
}
