using MediatR;
using Microsoft.AspNetCore.Mvc;
using SistemaBeneficiarios.Domain.Model.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SistemaBeneficiarios.Domain.Model.Commands;
using SistemaBeneficiarios.Domain.Model.Queries;
using SistemaBeneficiarios.Interfaces.REST.Resources;
using SistemaBeneficiarios.Interfaces.REST.Transform;

namespace SistemaBeneficiarios.Interfaces.REST;

/// <summary>
/// Controlador REST para gestionar la entidad Beneficiarios.
/// Expone endpoints para crear, leer, actualizar y eliminar beneficiarios.
/// </summary>
[ApiController]
[Route("api/v1/[controller]")]
public class BeneficiariosController : ControllerBase
{
    private readonly IMediator _mediator;

    public BeneficiariosController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    /// <summary>
    /// Crea un nuevo beneficiario.
    /// </summary>
    /// <param name="resource">Recurso con los datos del beneficiario a crear.</param>
    /// <returns>Respuesta HTTP con el resultado de la operación.</returns>
    /// <response code="201">Beneficiario creado exitosamente.</response>
    /// <response code="400">Error en los datos proporcionados.</response>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateBeneficiarioResource resource)
    {
        try
        {
            var command = CreateBeneficiarioCommandFromResourceAssembler.ToCommandFromResource(resource);
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id }, new { Id = id });
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }
    
    /// <summary>
    /// Actualiza un beneficiario existente.
    /// </summary>
    /// <param name="id">ID del beneficiario a actualizar.</param>
    /// <param name="resource">Datos nuevos para el beneficiario.</param>
    /// <returns>Resultado de la acción.</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateBeneficiarioResource resource)
    {
        if (id != resource.Id) return BadRequest("El ID de la URL no coincide con el cuerpo.");

        try
        {
            var command = UpdateBeneficiarioCommandFromResourceAssembler.ToCommandFromResource(resource);
            var result = await _mediator.Send(command);
                
            if (!result) return NotFound();
                
            return Ok(new { message = "Actualizado correctamente" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }
    
    /// <summary>
    /// Elimina un beneficiario por su ID.
    /// </summary>
    /// <param name="id">ID del beneficiario.</param>
    /// <returns>No Content si se eliminó, NotFound si no existe.</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _mediator.Send(new DeleteBeneficiarioCommand(id));
        if (!result) return NotFound();
        return NoContent();
    }
    
    /// <summary>
    /// Obtiene todos los beneficiarios.
    /// </summary>
    /// <returns>Lista de beneficiarios.</returns>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var entities = await _mediator.Send(new GetBeneficiariosQuery());
            
        var resources = entities.Select(entity => 
            BeneficiarioResourceFromEntityAssembler.ToResourceFromEntity(entity)
        );

        return Ok(resources);
    }
    
    /// <summary>
    /// Obtiene un beneficiario por su ID.
    /// </summary>
    /// <param name="id">ID del beneficiario.</param>
    /// <returns>El recurso del beneficiario o NotFound.</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var entity = await _mediator.Send(new GetBeneficiariosByIdQuery(id));
            
        if (entity == null) return NotFound();

        var resource = BeneficiarioResourceFromEntityAssembler.ToResourceFromEntity(entity);
            
        return Ok(resource);
    }
}