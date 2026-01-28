using SistemaBeneficiarios.Domain.Model.Aggregates;
using SistemaBeneficiarios.Domain.Model.Commands;

namespace SistemaBeneficiarios.Domain.Services;

public interface IBeneficiarioCommandService
{
    Task<int> HandleCreateAsync(CreateBeneficiarioCommand command);
    Task<bool> HandleUpdateAsync(UpdateBeneficiarioCommand command);
    Task<bool> HandleDeleteAsync(int id);
}