using MediatR;
using SistemaBeneficiarios.Domain.Model.Aggregates;
using SistemaBeneficiarios.Domain.Model.Queries;
using SistemaBeneficiarios.Domain.Repositories;

namespace SistemaBeneficiarios.Application.Internal.EventHandlers;

public class GetDocumentosIdentidadHandler : IRequestHandler<GetDocumentoIdentidadQuery, IEnumerable<DocumentoIdentidad>>
{
    private readonly IDocumentoIdentidadRepository _repository;

    public GetDocumentosIdentidadHandler(IDocumentoIdentidadRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<DocumentoIdentidad>> Handle(GetDocumentoIdentidadQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetAllAsync(request.SoloActivos);
    }
}