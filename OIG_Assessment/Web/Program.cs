using Application.Mapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Web.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

//builder.AddLogging();

builder.Services.AddAutoMapper(config =>
{
    config.AddProfile<MapperProfile>();
});

var configuration = builder.Configuration;
var organizationDbConnection = configuration.GetConnectionString("OrganizationDbConnection");

builder.Services.AddDbContext<OrganizationDbContext>((options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("OrganizationDbConnection"))));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
