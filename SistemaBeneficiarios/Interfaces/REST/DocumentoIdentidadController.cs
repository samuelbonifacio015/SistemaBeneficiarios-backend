using MediatR;
using Microsoft.AspNetCore.Mvc;
using SistemaBeneficiarios.Domain.Model.Queries;
using SistemaBeneficiarios.Interfaces.REST.Resources;

namespace SistemaBeneficiarios.Interfaces.REST;

/// <summary>
/// Controlador REST para gestionar tipos de Documento de Identidad.
/// </summary>
[ApiController]
[Route("api/v1/[controller]")]
public class DocumentoIdentidadController : ControllerBase
{
    private readonly IMediator _mediator;

    public DocumentoIdentidadController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    /// <summary>
    /// Obtiene todos los tipos de documento de identidad activos.
    /// </summary>
    /// <returns>Lista de documentos de identidad.</returns>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetDocumentoIdentidadQuery { SoloActivos = true };
        var entities = await _mediator.Send(query);

        var resources = entities.Select(d => new DocumentoIdentidadResource(
            d.Id, d.Nombre, d.Abreviatura, d.Longitud, d.SoloNumeros
        ));

        return Ok(resources);
    }
}