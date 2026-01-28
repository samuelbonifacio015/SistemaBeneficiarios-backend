using SistemaBeneficiarios.Domain.Model.Commands;
using SistemaBeneficiarios.Interfaces.REST.Resources;

namespace SistemaBeneficiarios.Interfaces.REST.Transform;

/// <summary>
/// Ensamblador para convertir recursos de actualización (REST) a comandos de dominio.
/// </summary>
public static class UpdateBeneficiarioCommandFromResourceAssembler
{
    /// <summary>
    /// Transforma un <see cref="UpdateBeneficiarioResource"/> en un <see cref="UpdateBeneficiarioCommand"/>.
    /// </summary>
    /// <param name="resource">El recurso con los datos actualizados.</param>
    /// <returns>El comando de actualización listo para el dominio.</returns>
    public static UpdateBeneficiarioCommand ToCommandFromResource(UpdateBeneficiarioResource resource)
    {
        return new UpdateBeneficiarioCommand
        {
            Id = resource.Id,
            Nombres = resource.Nombres,
            Apellidos = resource.Apellidos,
            DocumentoIdentidadId = resource.DocumentoIdentidadId,
            NumeroDocumento = resource.NumeroDocumento,
            FechaNacimiento = resource.FechaNacimiento,
            Sexo = resource.Sexo
        };
    }
}