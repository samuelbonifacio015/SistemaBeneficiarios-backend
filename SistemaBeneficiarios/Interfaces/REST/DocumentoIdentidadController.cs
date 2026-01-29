using MediatR;
using Microsoft.AspNetCore.Mvc;
using SistemaBeneficiarios.Domain.Model.Queries;
using SistemaBeneficiarios.Interfaces.REST.Resources;
using SistemaBeneficiarios.Interfaces.REST.Transform;

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
    /// <response code="200">Lista de documentos de identidad obtenida exitosamente.</response>
    /// <returns>Lista de documentos de identidad.</returns>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var entities = await _mediator.Send(new GetDocumentoIdentidadQuery());

        var resources = entities.Select(entity => 
            DocumentoIdentidadResourceFromEntityAssembler.ToResourceFromEntity(entity)
        );

        return Ok(resources);
    }
}