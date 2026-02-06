using Application.Organization.Dtos;

namespace Application.Moq
{
    public static class TestData
    {
        public static List<OrganizationDto> Organizations = new List<OrganizationDto>()
        {
            new OrganizationDto { Id = 1, Name = "Organization-1", ParentId = null },
            new OrganizationDto { Id = 2, Name = "Organization-2", ParentId = null },
            new OrganizationDto { Id = 3, Name = "Organization-3", ParentId = 1 },
            new OrganizationDto { Id = 4, Name = "Organization-4", ParentId = null },
            new OrganizationDto { Id = 5, Name = "Organization-5", ParentId = 3 },
            new OrganizationDto { Id = 6, Name = "Organization-6", ParentId = 5 },
            new OrganizationDto { Id = 7, Name = "Organization-7", ParentId = 2 },
            new OrganizationDto { Id = 8, Name = "Organization-8", ParentId = 4 },
            new OrganizationDto { Id = 9, Name = "Organization-9", ParentId = 6 },
            new OrganizationDto { Id = 10, Name = "Organization-10", ParentId = 4 },
            new OrganizationDto { Id = 11, Name = "Organization-11", ParentId = 10 },
            new OrganizationDto { Id = 12, Name = "Organization-12", ParentId = 7 },
            new OrganizationDto { Id = 13, Name = "Organization-13", ParentId = 4 },
            new OrganizationDto { Id = 14, Name = "Organization-14", ParentId = 5 },
            new OrganizationDto { Id = 15, Name = "Organization-15", ParentId = 12 },
            new OrganizationDto { Id = 16, Name = "Organization-16", ParentId = 5 },
            new OrganizationDto { Id = 17, Name = "Organization-17", ParentId = 12 }
        };
    }
}
