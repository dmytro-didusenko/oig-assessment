using Application.Mapper;
using Application.Organization.Queries.GetHierarchy;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Web.Components;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddAutoMapper(config =>
{
    config.AddProfile<MapperProfile>();
});

var configuration = builder.Configuration;
var organizationDbConnection = configuration.GetConnectionString("OrganizationDbConnection");

builder.Services.AddDbContext<OrganizationDbContext>((options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("OrganizationDbConnection"))));

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssemblyContaining<GetOrganizationHierarchyQuery>());

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
