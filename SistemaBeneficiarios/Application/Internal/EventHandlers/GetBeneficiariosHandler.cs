using MediatR;
using SistemaBeneficiarios.Domain.Model.Aggregates;
using SistemaBeneficiarios.Domain.Model.Queries;
using SistemaBeneficiarios.Domain.Repositories;

namespace SistemaBeneficiarios.Application.Internal.EventHandlers;

/// <summary>
/// Handler para obtener a todos los beneficiciarios
/// </summary>
public class GetBeneficiariosHandler : IRequestHandler<GetBeneficiariosQuery, IEnumerable<Beneficiario>>
{
    private readonly IBeneficiarioRepository _repository;

    public GetBeneficiariosHandler(IBeneficiarioRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Recupera la lista completa de beneficiarios del repositorio.
    /// </summary>
    /// <param name="request">La solicitud de consulta.</param>
    /// <param name="cancellationToken">Token de cancelación.</param>
    /// <returns>A todos los beneficiarios</returns>
    public async Task<IEnumerable<Beneficiario>> Handle(GetBeneficiariosQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetAllAsync();
    }
}