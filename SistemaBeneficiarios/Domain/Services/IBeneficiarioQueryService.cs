using SistemaBeneficiarios.Domain.Model.Aggregates;
using SistemaBeneficiarios.Domain.Model.Queries;

namespace SistemaBeneficiarios.Domain.Services;

public interface IBeneficiarioQueryService
{
    Task<IEnumerable<Beneficiario>> GetAllAsync();
    Task<Beneficiario?> GetByIdAsync(int id);
    Task<IEnumerable<DocumentoIdentidad>> GetDocumentosAsync(bool soloActivos);
}