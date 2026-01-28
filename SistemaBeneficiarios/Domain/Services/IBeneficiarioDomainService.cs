using SistemaBeneficiarios.Domain.Model.Aggregates;

namespace SistemaBeneficiarios.Domain.Services;

public interface IBeneficiarioDomainService
{
    void ValidarDocumento(string numeroDocumento, DocumentoIdentidad configuracion);
}