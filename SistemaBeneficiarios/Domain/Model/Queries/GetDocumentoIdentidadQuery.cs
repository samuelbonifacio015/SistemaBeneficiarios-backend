using MediatR;
using SistemaBeneficiarios.Domain.Model.Aggregates;

namespace SistemaBeneficiarios.Domain.Model.Queries;

/// <summary>
/// Query para obtener solo los documentos de identidad activos
/// </summary>
public record GetDocumentoIdentidadQuery : IRequest<IEnumerable<DocumentoIdentidad>>
{
    public bool SoloActivos { get; set; } = true;
}