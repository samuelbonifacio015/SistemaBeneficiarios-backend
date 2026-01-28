using MediatR;
using SistemaBeneficiarios.Domain.Model.Commands;
using SistemaBeneficiarios.Domain.Repositories;
using SistemaBeneficiarios.Domain.Services;

namespace SistemaBeneficiarios.Application.Internal.EventHandlers;

/// <summary>
/// Handler para el evento de CrearBeneficiario
/// </summary>
public class CreateBeneficiarioHandler : IRequestHandler<CreateBeneficiarioCommand, int>
{
    private readonly IBeneficiarioCommandService _service;

    public CreateBeneficiarioHandler(IBeneficiarioCommandService service)
    {
        _service = service;
    }

    public async Task<int> Handle(CreateBeneficiarioCommand request, CancellationToken cancellationToken)
    {
        return await _service.HandleCreateAsync(request);
    }
}