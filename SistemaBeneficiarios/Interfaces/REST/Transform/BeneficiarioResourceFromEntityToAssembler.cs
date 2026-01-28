using SistemaBeneficiarios.Domain.Model.Aggregates;
using SistemaBeneficiarios.Interfaces.REST.Resources;

namespace SistemaBeneficiarios.Interfaces.REST.Transform;

public static class BeneficiarioResourceFromEntityAssembler
{
    public static BeneficiarioResource ToResourceFromEntity(Beneficiario entity)
    {
        return new BeneficiarioResource(
            entity.Id,
            entity.Nombres,
            entity.Apellidos,
            entity.DocumentoIdentidad?.Abreviatura ?? "Desconocido", 
            entity.NumeroDocumento,
            entity.FechaNacimiento,
            entity.Sexo
        );
    }
}