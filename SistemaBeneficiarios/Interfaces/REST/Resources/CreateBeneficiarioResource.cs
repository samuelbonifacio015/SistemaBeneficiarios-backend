namespace SistemaBeneficiarios.Interfaces.REST.Resources;

public record CreateBeneficiarioResource(
    string Nombres,
    string Apellidos,
    int DocumentoIdentidadId,
    string NumeroDocumento,
    DateTime FechaNacimiento,
    char Sexo
);