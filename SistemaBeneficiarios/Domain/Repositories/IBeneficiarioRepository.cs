using SistemaBeneficiarios.Domain.Model.Aggregates;
using SistemaBeneficiarios.Domain.Model.Commands;

namespace SistemaBeneficiarios.Domain.Repositories;

/// <summary>
/// Repositorio para operaciones del Beneficiario
/// </summary>
/// <remarks> Task <value> para los commands de Escritura </remarks>
/// <remarks> Task <Beneficiario> para los queries de Lectura </remarks>
public interface IBeneficiarioRepository
{
    Task <int> CreateAsync(CreateBeneficiarioCommand command);
    Task <bool> UpdateAsync(UpdateBeneficiarioCommand command);
    Task <bool> DeleteAsync(int id);
    
    Task<Beneficiario?> GetByIdAsync(int id);
    Task<IEnumerable<Beneficiario>> GetAllAsync();
}