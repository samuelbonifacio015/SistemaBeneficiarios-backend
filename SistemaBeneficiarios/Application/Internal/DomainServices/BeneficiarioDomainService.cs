using SistemaBeneficiarios.Domain.Model.Aggregates;
using SistemaBeneficiarios.Domain.Services;

namespace SistemaBeneficiarios.Application.Internal.DomainServices;

/// <summary>
/// DomainService para Beneficiario.
/// </summary>
public class BeneficiarioDomainService : IBeneficiarioDomainService
{
    /// <summary>
    /// Valida el número de documento de identidad contra la configuración proporcionada.
    /// </summary>
    /// <param name="numeroDocumento">El número de documento a validar.</param>
    /// <param name="configuracion">La configuración del tipo de documento de identidad.</param>
    /// <exception cref="ArgumentException">Se lanza si el documento es nulo/vacío, tiene longitud incorrecta o contiene caracteres no permitidos.</exception>
    /// <remarks>
    /// Verifica:
    /// 1. Que no sea nulo o espacios en blanco.
    /// 2. Que la longitud coincida con la configuración.
    /// 3. Que, si se requiere solo números, todos los caracteres sean dígitos.
    /// </remarks>
    public void ValidarDocumento(string numeroDocumento, DocumentoIdentidad configuracion)
    {
        if (string.IsNullOrWhiteSpace(numeroDocumento))
            throw new ArgumentException("El número de documento es obligatorio.");
            
        // Valida la longitud exacta requerida por el tipo de documento
        if (numeroDocumento.Length != configuracion.Longitud)
            throw new ArgumentException($"El documento debe tener {configuracion.Longitud} caracteres.");
                
        // Valida si el documento contiene solo números
        if (configuracion.SoloNumeros && !numeroDocumento.All(char.IsDigit))
            throw new ArgumentException("El documento solo debe contener números.");
    }
}