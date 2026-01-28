namespace SistemaBeneficiarios.Interfaces.REST.Resources;

public record UpdateBeneficiarioResource(
    int Id,
    string Nombres,
    string Apellidos,
    int DocumentoIdentidadId,
    string NumeroDocumento,
    DateTime FechaNacimiento,
    char Sexo
);