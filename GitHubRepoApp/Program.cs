using GitHubRepoApp.Application.Mappings;
using GitHubRepoApp.Application.UseCases;
using GitHubRepoApp.Domain.Interfaces;
using GitHubRepoApp.Infrastructure;
using GitHubRepoApp.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;

var builder = WebApplication.CreateBuilder(args);

// Configuração de logging com Serilog
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

builder.Host.UseSerilog();

// Configuração de serviços

builder.Services.AddHttpClient();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuração do banco de dados PostgreSQL
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));



// Configuração de dependências e AutoMapper
builder.Services.AddScoped<IGitHubService, GitHubService>();
builder.Services.AddScoped<SyncRepositoriesUseCase>();
builder.Services.AddScoped<GetRepositoriesUseCase>();
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddInfrastructure();



var app = builder.Build();

// Configuração do middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
