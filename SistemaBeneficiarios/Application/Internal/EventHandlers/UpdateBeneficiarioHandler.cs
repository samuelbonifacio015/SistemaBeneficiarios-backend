using MediatR;
using SistemaBeneficiarios.Domain.Model.Commands;
using SistemaBeneficiarios.Domain.Repositories;
using SistemaBeneficiarios.Domain.Services;

namespace SistemaBeneficiarios.Application.Internal.EventHandlers;

/// <summary>
/// Handler para actualizar a un beneficiario (por ID).
/// </summary>
public class UpdateBeneficiarioHandler : IRequestHandler<UpdateBeneficiarioCommand, bool>
{
    private readonly IBeneficiarioRepository _beneficiarioRepository;
    private readonly IDocumentoIdentidadRepository _documentoRepository;
    private readonly IBeneficiarioDomainService _domainService;

    public UpdateBeneficiarioHandler(
        IBeneficiarioRepository beneficiarioRepository,
        IDocumentoIdentidadRepository documentoRepository,
        IBeneficiarioDomainService domainService)
    {
        _beneficiarioRepository = beneficiarioRepository;
        _documentoRepository = documentoRepository;
        _domainService = domainService;
    }

    /// <summary>
    /// Ejecuta la lógica para actualizar la info de un beneficiario
    /// </summary>
    /// <param name="request">El comando con los nuevos datos del beneficiario.</param>
    /// <param name="cancellationToken">Token de cancelación.</param>
    /// <remarks>
    /// Realiza validaciones previas:
    /// 1. Verifica que el tipo de documento exista.
    /// 2. Valida el formato del número de documento usando el servicio de dominio.
    /// </remarks>
    public async Task<bool> Handle(UpdateBeneficiarioCommand request, CancellationToken cancellationToken)
    {
        var documentoConfig = await _documentoRepository.GetByIdAsync(request.DocumentoIdentidadId);

        if (documentoConfig == null)
            throw new KeyNotFoundException("El tipo de documento especificado no existe.");
        
        _domainService.ValidarDocumento(request.NumeroDocumento, documentoConfig);

        return await _beneficiarioRepository.UpdateAsync(request);
    }
}