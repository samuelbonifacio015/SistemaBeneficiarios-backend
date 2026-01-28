using SistemaBeneficiarios.Domain.Model.Aggregates;
using SistemaBeneficiarios.Domain.Model.Queries;

namespace SistemaBeneficiarios.Domain.Services;

/// <summary>
/// Interfaz de QueryServices para Beneficiarios.
/// Define las operaciones de lectura.
/// </summary>
public interface IBeneficiarioQueryService
{
    /// <summary>
    /// Obtiene todos los beneficiarios.
    /// </summary>
    /// <returns>Todos los beneficiarios.</returns>
    Task<IEnumerable<Beneficiario>> GetAllAsync();

    /// <summary>
    /// Obtiene un beneficiario por su ID.
    /// </summary>
    /// <param name="id">Identificador único.</param>
    /// <returns>El beneficiario encontrado o null.</returns>
    Task<Beneficiario?> GetByIdAsync(int id);

    /// <summary>
    /// Obtiene los documentos de identidad disponibles.
    /// </summary>
    /// <param name="soloActivos">Filtrar solo activos.</param>
    /// <returns>Todos los documentos de identidad (activos)</returns>
    Task<IEnumerable<DocumentoIdentidad>> GetDocumentosAsync(bool soloActivos);
}