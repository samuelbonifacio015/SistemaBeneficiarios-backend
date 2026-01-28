using SistemaBeneficiarios.Domain.Model.Commands;
using SistemaBeneficiarios.Interfaces.REST.Resources;

namespace SistemaBeneficiarios.Interfaces.REST.Transform;

public static class UpdateBeneficiarioCommandFromResourceAssembler
{
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