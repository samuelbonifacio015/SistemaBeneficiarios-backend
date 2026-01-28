namespace SistemaBeneficiarios.Interfaces.REST.Resources;

/// <summary>
/// Recurso para la actualización de un Beneficiario existente.
/// </summary>
/// <param name="Id">ID del beneficiario a actualizar.</param>
/// <param name="Nombres">Nuevos nombres.</param>
/// <param name="Apellidos">Nuevos apellidos.</param>
/// <param name="DocumentoIdentidadId">Nuevo tipo de documento (si aplica).</param>
/// <param name="NumeroDocumento">Nuevo número de documento (si aplica).</param>
/// <param name="FechaNacimiento">Nueva fecha de nacimiento.</param>
/// <param name="Sexo">Sexo actualizado.</param>
public record UpdateBeneficiarioResource(
    int Id,
    string Nombres,
    string Apellidos,
    int DocumentoIdentidadId,
    string NumeroDocumento,
    DateTime FechaNacimiento,
    char Sexo
);