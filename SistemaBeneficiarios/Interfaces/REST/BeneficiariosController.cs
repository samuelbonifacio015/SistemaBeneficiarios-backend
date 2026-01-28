using MediatR;
using Microsoft.AspNetCore.Mvc;
using SistemaBeneficiarios.Domain.Model.Commands;
using SistemaBeneficiarios.Domain.Model.Queries;
using SistemaBeneficiarios.Interfaces.REST.Resources;
using SistemaBeneficiarios.Interfaces.REST.Transform;

namespace SistemaBeneficiarios.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class BeneficiariosController : ControllerBase
{
    private readonly IMediator _mediator;

    public BeneficiariosController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
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
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _mediator.Send(new DeleteBeneficiarioCommand(id));
        if (!result) return NotFound();
        return NoContent();
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var entities = await _mediator.Send(new GetBeneficiariosQuery());
            
        var resources = entities.Select(entity => 
            BeneficiarioResourceFromEntityAssembler.ToResourceFromEntity(entity)
        );

        return Ok(resources);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var entity = await _mediator.Send(new GetBeneficiariosByIdQuery(id));
            
        if (entity == null) return NotFound();

        var resource = BeneficiarioResourceFromEntityAssembler.ToResourceFromEntity(entity);
            
        return Ok(resource);
    }
}