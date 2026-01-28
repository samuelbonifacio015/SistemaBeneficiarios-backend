using SistemaBeneficiarios.Domain.Model.Aggregates;
using SistemaBeneficiarios.Domain.Repositories;
using SistemaBeneficiarios.Domain.Services;

namespace SistemaBeneficiarios.Application.Internal.QueryServices;

/// <summary>
/// QueryService encargado de manejar las consultas de datos de Beneficiarios y Documentos de Identidad
/// </summary>
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

    /// <summary>
    /// Obtiene todos los beneficiarios registrados en el sistema
    /// </summary>
    public async Task<IEnumerable<Beneficiario>> GetAllAsync()
    {
        return await _beneficiarioRepository.GetAllAsync();
    }

    /// <summary>
    /// Busca un beneficiario específico por su ID
    /// </summary>
    /// <param name="id">El identificador único del beneficiario.</param>
    /// <returns>El beneficiario encontrado o null si no existe.</returns>
    public async Task<Beneficiario?> GetByIdAsync(int id)
    {
        return await _beneficiarioRepository.GetByIdAsync(id);
    }

    /// <summary>
    /// Obtiene la lista de tipos de documentos de identidad disponibles
    /// </summary>
    /// <param name="soloActivos">Indica si se deben devolver solo los tipos de documentos activos</param>
    public async Task<IEnumerable<DocumentoIdentidad>> GetDocumentosAsync(bool soloActivos)
    {
        return await _documentoRepository.GetAllAsync(soloActivos);
    }
}