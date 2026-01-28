using SistemaBeneficiarios.Domain.Model.Aggregates;

namespace SistemaBeneficiarios.Domain.Repositories;

/// <summary>
/// Repositorio para operaciones de DocumentoIdentidad
/// </summary>
/// <remarks> Solo queries de Lectura </remarks>
public interface IDocumentoIdentidadRepository
{
    Task<DocumentoIdentidad?> GetByIdAsync(int id);
    Task<IEnumerable<DocumentoIdentidad>> GetAllAsync(bool SoloActivos);
}