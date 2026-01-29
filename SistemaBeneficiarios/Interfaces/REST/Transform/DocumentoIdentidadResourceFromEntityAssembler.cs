using SistemaBeneficiarios.Domain.Model.Aggregates;
using SistemaBeneficiarios.Interfaces.REST.Resources;

namespace SistemaBeneficiarios.Interfaces.REST.Transform;

/// <summary>
/// Ensamblador para transformar entidades de DocumentoIdentidad a Recursos (DTOs).
/// </summary>
public static class DocumentoIdentidadResourceFromEntityAssembler
{
    /// <summary>
    /// Convierte una entidad <see cref="DocumentoIdentidad"/> en un <see cref="DocumentoIdentidadResource"/>.
    /// </summary>
    /// <param name="entity">La entidad DocumentoIdentidad</param>
    public static DocumentoIdentidadResource ToResourceFromEntity(DocumentoIdentidad entity)
    {
        return new DocumentoIdentidadResource(
            entity.Id,
            entity.Nombre,
            entity.Abreviatura,
            entity.Longitud,
            entity.Pais, 
            entity.SoloNumeros,
            entity.Activo
        );
    }
}