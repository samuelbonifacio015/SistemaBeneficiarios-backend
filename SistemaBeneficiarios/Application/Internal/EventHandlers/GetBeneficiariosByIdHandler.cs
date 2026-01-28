using MediatR;
using SistemaBeneficiarios.Domain.Model.Aggregates;
using SistemaBeneficiarios.Domain.Model.Queries;
using SistemaBeneficiarios.Domain.Repositories;

namespace SistemaBeneficiarios.Application.Internal.EventHandlers;

/// <summary>
/// Handler para obtener a un beneficiario por ID
/// </summary>
public class GetBeneficiariosByIdHandler : IRequestHandler<GetBeneficiariosByIdQuery, Beneficiario>
{
    private readonly IBeneficiarioRepository _repository;

    public GetBeneficiariosByIdHandler(IBeneficiarioRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Procesa la solicitud para recuperar un beneficiario específico.
    /// </summary>
    /// <param name="request">La query que contiene el ID del beneficiario.</param>
    /// <param name="cancellationToken">Token de cancelación.</param>
    /// <returns>La entidad del beneficiario encontrado.</returns>
    public async Task<Beneficiario> Handle(GetBeneficiariosByIdQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetByIdAsync(request.Id);
    }
}