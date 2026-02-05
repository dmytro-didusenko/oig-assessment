using Application.Common.Behaviors;
using Application.Mapper;
using Application.User.Commands.Create;
using Application.User.Validators;
using FluentValidation;
using Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(config =>
{
    config.AddProfile<MapperProfile>();
});

var configuration = builder.Configuration;
var organizationDbConnection = configuration.GetConnectionString("OrganizationDbConnection");

builder.Services.AddDbContext<OrganizationDbContext>((options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("OrganizationDbConnection"))));

builder.Services.AddScoped<OrganizationDbContext>();

builder.Services.AddControllers();

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssemblyContaining<CreateUserCommand>());

builder.Services.AddValidatorsFromAssemblyContaining<CreateOrganizationCommandValidator>();
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
        c.RoutePrefix = "swagger";
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
