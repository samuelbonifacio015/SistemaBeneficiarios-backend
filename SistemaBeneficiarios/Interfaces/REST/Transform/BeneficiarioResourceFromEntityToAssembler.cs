using SistemaBeneficiarios.Domain.Model.Aggregates;
using SistemaBeneficiarios.Interfaces.REST.Resources;

namespace SistemaBeneficiarios.Interfaces.REST.Transform;

/// <summary>
/// Ensamblador para transformar entidades de Beneficiario a Recursos (DTOs).
/// </summary>
public static class BeneficiarioResourceFromEntityAssembler
{
    /// <summary>
    /// Convierte una entidad <see cref="Beneficiario"/> en un <see cref="BeneficiarioResource"/>.
    /// </summary>
    /// <param name="entity">La entidad beneficiario.</param>
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