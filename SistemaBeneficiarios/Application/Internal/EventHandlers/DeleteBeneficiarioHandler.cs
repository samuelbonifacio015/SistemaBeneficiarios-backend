using MediatR;
using SistemaBeneficiarios.Domain.Model.Commands;
using SistemaBeneficiarios.Domain.Repositories;

namespace SistemaBeneficiarios.Application.Internal.EventHandlers;

/// <summary>
/// Handler para el evento de DeleteBeneficiario
/// Procesa la solicitud <see cref="DeleteBeneficiarioCommand"/>.
/// </summary>
public class DeleteBeneficiarioHandler : IRequestHandler<DeleteBeneficiarioCommand, bool>
{
    private readonly IBeneficiarioRepository _repository;

    public DeleteBeneficiarioHandler(IBeneficiarioRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Lógica para eliminar el beneficiario especificado (en este caso por ID)
    /// </summary>
    /// <param name="request">El comando de eliminación que contiene el ID del beneficiario.</param>
    /// <param name="cancellationToken">Token de cancelación para la operación asíncrona.</param>
    public async Task<bool> Handle(DeleteBeneficiarioCommand request, CancellationToken cancellationToken)
    {
        return await _repository.DeleteAsync(request.Id);
    }
}