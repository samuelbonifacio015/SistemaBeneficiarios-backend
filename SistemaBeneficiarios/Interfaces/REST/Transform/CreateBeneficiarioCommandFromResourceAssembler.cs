using SistemaBeneficiarios.Domain.Model.Commands;
using SistemaBeneficiarios.Interfaces.REST.Resources;

namespace SistemaBeneficiarios.Interfaces.REST.Transform;

public static class CreateBeneficiarioCommandFromResourceAssembler
{
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