namespace SistemaBeneficiarios.Interfaces.REST.Resources;

/// <summary>
/// Recurso para la creación de un nuevo Beneficiario.
/// Contiene la información requerida por la API para registrar un beneficiario.
/// </summary>
/// <param name="Nombres">Nombres del beneficiario.</param>
/// <param name="Apellidos">Apellidos del beneficiario.</param>
/// <param name="DocumentoIdentidadId">Identificador del tipo de documento de identidad.</param>
/// <param name="NumeroDocumento">Número de documento de identidad.</param>
/// <param name="FechaNacimiento">Fecha de nacimiento.</param>
/// <param name="Sexo">Sexo (M/F).</param>
public record CreateBeneficiarioResource(
    string Nombres,
    string Apellidos,
    int DocumentoIdentidadId,
    string NumeroDocumento,
    DateTime FechaNacimiento,
    char Sexo
);