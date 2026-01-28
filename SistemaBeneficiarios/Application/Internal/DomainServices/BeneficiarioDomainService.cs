using SistemaBeneficiarios.Domain.Model.Aggregates;
using SistemaBeneficiarios.Domain.Services;

namespace SistemaBeneficiarios.Application.Internal.DomainServices;

public class BeneficiarioDomainService : IBeneficiarioDomainService
{
    public void ValidarDocumento(string numeroDocumento, DocumentoIdentidad configuracion)
    {
        if (string.IsNullOrWhiteSpace(numeroDocumento))
            throw new ArgumentException("El número de documento es obligatorio.");
            
        if (numeroDocumento.Length != configuracion.Longitud)
            throw new ArgumentException($"El documento debe tener {configuracion.Longitud} caracteres.");
                
        if (configuracion.SoloNumeros && !numeroDocumento.All(char.IsDigit))
            throw new ArgumentException("El documento solo debe contener números.");
    }
}