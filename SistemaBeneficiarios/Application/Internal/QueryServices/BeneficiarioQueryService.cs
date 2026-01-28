using SistemaBeneficiarios.Domain.Model.Aggregates;
using SistemaBeneficiarios.Domain.Repositories;
using SistemaBeneficiarios.Domain.Services;

namespace SistemaBeneficiarios.Application.Internal.QueryServices;

public class BeneficiarioQueryService : IBeneficiarioQueryService
{
    private readonly IBeneficiarioRepository _beneficiarioRepository;
    private readonly IDocumentoIdentidadRepository _documentoRepository;

    public BeneficiarioQueryService(
        IBeneficiarioRepository beneficiarioRepository, 
        IDocumentoIdentidadRepository documentoRepository)
    {
        _beneficiarioRepository = beneficiarioRepository;
        _documentoRepository = documentoRepository;
    }

    public async Task<IEnumerable<Beneficiario>> GetAllAsync()
    {
        return await _beneficiarioRepository.GetAllAsync();
    }

    public async Task<Beneficiario?> GetByIdAsync(int id)
    {
        return await _beneficiarioRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<DocumentoIdentidad>> GetDocumentosAsync(bool soloActivos)
    {
        return await _documentoRepository.GetAllAsync(soloActivos);
    }
}