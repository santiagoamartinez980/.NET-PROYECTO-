using BackEndAPI.Data;
using BackEndAPI.Models;
using AutoMapper;
using BackEndAPI.Services.Contrato.Componentes;
using BackEndAPI.Services.Contrato.EnsamblajeService;
using BackEndAPI.Services.Contrato.Usuarios;
using BackEndAPI.Services.Implementacion;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BackEndAPI.Mappings;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CadenaDeConnexion"))
);

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddScoped<IAdminComponetes, ComponenteServices>();
builder.Services.AddScoped<IComponentes, ComponenteServices>();
builder.Services.AddScoped<IConsultaComponentes, ComponenteServices>();


builder.Services.AddScoped<IComponentesCompleto, ComponenteServices>();

builder.Services.AddScoped<IEnsamblaje, EnsamblajeServices>();

builder.Services.AddScoped<IUsuario, UsuarioServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
