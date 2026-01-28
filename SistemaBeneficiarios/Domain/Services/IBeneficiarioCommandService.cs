using SistemaBeneficiarios.Domain.Model.Aggregates;
using SistemaBeneficiarios.Domain.Model.Commands;

namespace SistemaBeneficiarios.Domain.Services;

/// <summary>
/// Interfaz de CommandService para los Beneficiarios
/// Define las operaciones de escritura (CREATE, UPDATE, DELETE).
/// </summary>
public interface IBeneficiarioCommandService
{
    /// <summary>
    /// Maneja la creación de un nuevo beneficiario.
    /// </summary>
    /// <param name="command">Datos del beneficiario a crear.</param>
    /// <returns>ID del beneficiario creado.</returns>
    Task<int> HandleCreateAsync(CreateBeneficiarioCommand command);

    /// <summary>
    /// Maneja la actualización de un beneficiario.
    /// </summary>
    /// <param name="command">Datos actualizados del beneficiario.</param>
    /// <returns>True si la actualización fue exitosa.</returns>
    Task<bool> HandleUpdateAsync(UpdateBeneficiarioCommand command);

    /// <summary>
    /// Maneja la eliminación de un beneficiario.
    /// </summary>
    /// <param name="id">ID del beneficiario a eliminar.</param>
    /// <returns>True si se eliminó correctamente.</returns>
    Task<bool> HandleDeleteAsync(int id);
}