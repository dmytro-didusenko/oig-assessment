using Application.Dtos.OrganizationTree;
using Application.Organization.Dtos;

namespace Application.Extensions
{
    public static class OrganizationExtensions
    {
        public static IEnumerable<OrganizationDto> GetOrganizationChildren(this IEnumerable<OrganizationDto> organizations, uint parentId)
        {
            if (organizations is null) 
                throw new ArgumentNullException(nameof(organizations));

            var childrenByParent = organizations
                .GroupBy(o => o.ParentId.Value)
                .ToDictionary(k => k.Key, v => v.ToList());

            var result = new List<OrganizationDto>();

            void GetDescendants(uint currentParentId)
            {
                if (!childrenByParent.TryGetValue(currentParentId, out var children))
                    return;

                foreach (var child in children)
                {
                    result.Add(child);
                    GetDescendants(child.Id);
                }
            }

            GetDescendants(parentId);
            return result;
        }

        public static IEnumerable<OrganizationNode> BuildOrganizationTree(this List<OrganizationDto> organizations)
        {
            if (organizations is null) 
                throw new ArgumentNullException(nameof(organizations));

            var nodesById = organizations.ToDictionary(
                o => o.Id,
                o => new OrganizationNode
                {
                    Id = o.Id,
                    Name = o.Name,
                    ParentId = o.ParentId
                });

            var roots = new List<OrganizationNode>();

            foreach (var node in nodesById.Values)
            {
                if (node.ParentId is null)
                {
                    roots.Add(node);
                    continue;
                }

                if (!nodesById.TryGetValue(node.ParentId.Value, out var parent))
                {
                    roots.Add(node);
                    continue;
                }

                parent.Children.Add(node);
            }

            return roots;
        }
    }
}
