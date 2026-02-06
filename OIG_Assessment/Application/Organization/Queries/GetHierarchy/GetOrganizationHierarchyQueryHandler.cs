using Application.Dtos.OrganizationTree;
using Application.Extensions;
using Application.Moq;
using MediatR;

namespace Application.Organization.Queries.GetHierarchy
{
    public class GetOrganizationHierarchyQueryHandler : IRequestHandler<GetOrganizationHierarchyQuery, IEnumerable<OrganizationNode>>
    {
        public Task<IEnumerable<OrganizationNode>> Handle(GetOrganizationHierarchyQuery request, CancellationToken cancellationToken)
        {
            var roots = TestData.Organizations.BuildOrganizationTree();
            return Task.FromResult<IEnumerable<OrganizationNode>>(roots);
        }
    }
}
