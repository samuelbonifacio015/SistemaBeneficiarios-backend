namespace SistemaBeneficiarios.Interfaces.REST.Resources;

public record BeneficiarioResource(
    int Id,
    string Nombres,
    string Apellidos,
    string TipoDocumento, 
    string NumeroDocumento,
    DateTime FechaNacimiento,
    char Sexo
);