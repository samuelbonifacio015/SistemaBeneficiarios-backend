namespace SistemaBeneficiarios.Interfaces.REST.Resources;

/// <summary>
/// Recurso que representa los datos de un Beneficiario expuestos en la API.
/// </summary>
/// <param name="Id">Identificador único del beneficiario.</param>
/// <param name="Nombres">Nombres del beneficiario.</param>
/// <param name="Apellidos">Apellidos del beneficiario.</param>
/// <param name="TipoDocumento">Descripción abreviada del tipo de documento.</param>
/// <param name="NumeroDocumento">Número de documento de identidad.</param>
/// <param name="FechaNacimiento">Fecha de nacimiento.</param>
/// <param name="Sexo">Sexo (M/F).</param>
public record BeneficiarioResource(
    int Id,
    string Nombres,
    string Apellidos,
    string TipoDocumento, 
    string NumeroDocumento,
    DateTime FechaNacimiento,
    char Sexo
);