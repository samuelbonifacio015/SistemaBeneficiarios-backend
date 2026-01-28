using SistemaBeneficiarios.Domain.Model.Aggregates;

namespace SistemaBeneficiarios.Domain.Services;

/// <summary>
/// Interfaz de DomainService para validaciones de Beneficiarios.
/// </summary>
public interface IBeneficiarioDomainService
{
    /// <summary>
    /// Valida el número de documento según las reglas del tipo de documento.
    /// </summary>
    /// <param name="numeroDocumento">Número de documento a validar.</param>
    /// <param name="configuracion">Configuración del tipo de documento.</param>
    void ValidarDocumento(string numeroDocumento, DocumentoIdentidad configuracion);
}