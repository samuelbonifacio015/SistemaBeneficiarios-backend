using System.Reflection;
using MediatR;
using SistemaBeneficiarios.Application.Internal.CommandServices;
using SistemaBeneficiarios.Application.Internal.DomainServices;
using SistemaBeneficiarios.Application.Internal.QueryServices;
using SistemaBeneficiarios.Domain.Repositories;
using SistemaBeneficiarios.Domain.Services;
using SistemaBeneficiarios.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.AddScoped<IBeneficiarioDomainService, BeneficiarioDomainService>();

builder.Services.AddScoped<IBeneficiarioCommandService, BeneficiarioCommandService>();
builder.Services.AddScoped<IBeneficiarioQueryService, BeneficiarioQueryService>();

builder.Services.AddScoped<IBeneficiarioRepository, BeneficiarioRepository>();
builder.Services.AddScoped<IDocumentoIdentidadRepository, DocumentoIdentidadRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();