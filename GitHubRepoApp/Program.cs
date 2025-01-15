using GitHubRepoApp.Application.Mappings;
using GitHubRepoApp.Application.UseCases;
using GitHubRepoApp.Domain.Interfaces;
using GitHubRepoApp.Infrastructure;
using GitHubRepoApp.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;

var builder = WebApplication.CreateBuilder(args);

// Configura��o de logging com Serilog
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

builder.Host.UseSerilog();

// Configura��o de servi�os

builder.Services.AddHttpClient();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configura��o do banco de dados PostgreSQL
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));



// Configura��o de depend�ncias e AutoMapper
builder.Services.AddScoped<IGitHubService, GitHubService>();
builder.Services.AddScoped<SyncRepositoriesUseCase>();
builder.Services.AddScoped<GetRepositoriesUseCase>();
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddInfrastructure();



var app = builder.Build();

// Configura��o do middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
