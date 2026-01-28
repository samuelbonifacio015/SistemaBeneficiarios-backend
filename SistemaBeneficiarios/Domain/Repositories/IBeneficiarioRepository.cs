using SistemaBeneficiarios.Domain.Model.Aggregates;
using SistemaBeneficiarios.Domain.Model.Commands;

namespace SistemaBeneficiarios.Domain.Repositories;

/// <summary>
/// Repositorio para operaciones de lectura del Beneficiario
/// </summary>
public interface IBeneficiarioRepository
{
    /// <summary>
    /// Crea un nuevo registro de beneficiario.
    /// </summary>
    /// <param name="command">Datos de creación.</param>
    /// <returns>El ID generado.</returns>
    Task <int> CreateAsync(CreateBeneficiarioCommand command);

    /// <summary>
    /// Actualiza un registro existente.
    /// </summary>
    /// <param name="command">Datos de actualización.</param>
    /// <returns>True si la operación fue exitosa.</returns>
    Task <bool> UpdateAsync(UpdateBeneficiarioCommand command);

    /// <summary>
    /// Elimina un registro por ID.
    /// </summary>
    /// <param name="id">ID del registro a eliminar.</param>
    /// <returns>True si la operación fue exitosa.</returns>
    Task <bool> DeleteAsync(int id);
    
    /// <summary>
    /// Obtiene un beneficiario por ID.
    /// </summary>
    /// <param name="id">ID del beneficiario.</param>
    /// <returns>La entidad encontrada o null.</returns>
    Task<Beneficiario?> GetByIdAsync(int id);

    /// <summary>
    /// Obtiene todos los beneficiarios.
    /// </summary>
    /// <returns>Lista completa de beneficiarios.</returns>
    Task<IEnumerable<Beneficiario>> GetAllAsync();
}