using MediatR;
using SistemaBeneficiarios.Domain.Model.Aggregates;
using SistemaBeneficiarios.Domain.Model.Queries;
using SistemaBeneficiarios.Domain.Repositories;

namespace SistemaBeneficiarios.Application.Internal.EventHandlers;

/// <summary>
/// Handler para obtener los documentos de identidad registrados
/// </summary>
/// <remarks> En este caso se obtendrán los de la semilla generada por SQL Server</remarks>
public class GetDocumentosIdentidadHandler : IRequestHandler<GetDocumentoIdentidadQuery, IEnumerable<DocumentoIdentidad>>
{
    private readonly IDocumentoIdentidadRepository _repository;

    public GetDocumentosIdentidadHandler(IDocumentoIdentidadRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Recupera la lista de documentos activos.
    /// </summary>
    public async Task<IEnumerable<DocumentoIdentidad>> Handle(GetDocumentoIdentidadQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetAllAsync(request.SoloActivos);
    }
}