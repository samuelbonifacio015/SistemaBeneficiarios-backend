using System.Reflection;
using MediatR;
using SistemaBeneficiarios.Application.Internal.CommandServices;
using SistemaBeneficiarios.Application.Internal.DomainServices;
using System.Reflection;
using SistemaBeneficiarios.Application.Internal.CommandServices;
using SistemaBeneficiarios.Application.Internal.DomainServices;
using SistemaBeneficiarios.Application.Internal.QueryServices;
using SistemaBeneficiarios.Domain.Repositories;
using SistemaBeneficiarios.Domain.Services;
using SistemaBeneficiarios.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Config de Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuración de CORS para permitir peticiones desde cualquier origen
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Registrar MediatR escaneando el ensamblado actual
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

// --- Inyección de Dependencias ---

// Servicios de Dominio
builder.Services.AddScoped<IBeneficiarioDomainService, BeneficiarioDomainService>();

// Servicios de Aplicación (Command y Query Services)
builder.Services.AddScoped<IBeneficiarioCommandService, BeneficiarioCommandService>();
builder.Services.AddScoped<IBeneficiarioQueryService, BeneficiarioQueryService>();

// Repositorios de Infraestructura
builder.Services.AddScoped<IBeneficiarioRepository, BeneficiarioRepository>();
builder.Services.AddScoped<IDocumentoIdentidadRepository, DocumentoIdentidadRepository>();

var app = builder.Build();

// Configurar el pipeline en entorno de desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Habilitar CORS
app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

// Mapear los controladores
app.MapControllers();

app.Run();