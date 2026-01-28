using SistemaBeneficiarios.Domain.Model.Aggregates;

namespace SistemaBeneficiarios.Domain.Repositories;

/// <summary>
/// Repositorio para operaciones de lectura de Documento de Identidad
/// </summary>
public interface IDocumentoIdentidadRepository
{
    /// <summary>
    /// Obtiene un documento de identidad por su ID.
    /// </summary>
    /// <param name="id">ID del documento.</param>
    /// <returns>La entidad documento o null.</returns>
    Task<DocumentoIdentidad?> GetByIdAsync(int id);

    /// <summary>
    /// Obtiene todos los documentos de identidad.
    /// </summary>
    /// <param name="SoloActivos">Filtro para obtener solo los activos.</param>
    /// <returns>Colección de documentos de identidad.</returns>
    Task<IEnumerable<DocumentoIdentidad>> GetAllAsync(bool SoloActivos);
}