using SistemaBeneficiarios.Domain.Model.Commands;
using SistemaBeneficiarios.Interfaces.REST.Resources;

namespace SistemaBeneficiarios.Interfaces.REST.Transform;

/// <summary>
/// Ensamblador para convertir recursos de creación (REST) a comandos de dominio.
/// </summary>
public static class CreateBeneficiarioCommandFromResourceAssembler
{
    /// <summary>
    /// Transforma un <see cref="CreateBeneficiarioResource"/> en un <see cref="CreateBeneficiarioCommand"/>.
    /// </summary>
    /// <param name="resource">El recurso con los datos de entrada.</param>
    /// <returns>El comando listo para ser procesado por el dominio.</returns>
    public static CreateBeneficiarioCommand ToCommandFromResource(CreateBeneficiarioResource resource)
    {
        return new CreateBeneficiarioCommand
        {
            Nombres = resource.Nombres,
            Apellidos = resource.Apellidos,
            DocumentoIdentidadId = resource.DocumentoIdentidadId,
            NumeroDocumento = resource.NumeroDocumento,
            FechaNacimiento = resource.FechaNacimiento,
            Sexo = resource.Sexo
        };
    }
}