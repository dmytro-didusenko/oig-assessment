using Application.Dtos.OrganizationTree;
using MediatR;

namespace Application.Organization.Queries.GetHierarchy
{
    public class GetOrganizationHierarchyQuery : IRequest<IEnumerable<OrganizationNode>>
    {
    }
}
