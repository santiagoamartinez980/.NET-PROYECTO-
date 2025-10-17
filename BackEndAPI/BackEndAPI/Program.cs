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
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<MappingProfile>());


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CadenaDeConnexion"))
);

#region Services

builder.Services.AddScoped<IAdminComponetes, ComponenteServices>();
builder.Services.AddScoped<IComponentes, ComponenteServices>();
builder.Services.AddScoped<IConsultaComponentes, ComponenteServices>();
builder.Services.AddScoped<IComponentesCompleto, ComponenteServices>();

builder.Services.AddScoped<IEnsamblaje, EnsamblajeServices>();
builder.Services.AddScoped<IUsuario, UsuarioServices>();

#endregion


builder.Services.AddControllers();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

builder.Services.AddCors();
app.UseCors(options =>
{
    options.WithOrigins("http://localhost:4200")
           .AllowAnyMethod()
           .AllowAnyHeader();
});

app.UseAuthorization();

app.Run();

