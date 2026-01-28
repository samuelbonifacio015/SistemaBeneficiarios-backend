namespace SistemaBeneficiarios.Domain.Model.Aggregates;

/// <summary>
/// Clase que representa a un beneficiario
/// </summary>
public partial class Beneficiario
{
    /// <summary>
    /// Identificador único del beneficiario.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Nombres del beneficiario.
    /// </summary>
    public string Nombres { get; set; } = string.Empty;

    /// <summary>
    /// Apellidos del beneficiario.
    /// </summary>
    public string Apellidos { get; set; } = string.Empty;

    /// <summary>
    /// Identificador foráneo del tipo de documento de identidad.
    /// </summary>
    public int DocumentoIdentidadId { get; set; }

    /// <summary>
    /// Número de documento de identidad.
    /// </summary>
    public string NumeroDocumento { get; set; } = string.Empty;

    /// <summary>
    /// Fecha de nacimiento del beneficiario.
    /// </summary>
    public DateTime FechaNacimiento { get; set; }

    /// <summary>
    /// Sexo del beneficiario.
    /// </summary>
    public char Sexo { get; set; }
    
    /// <summary>
    /// Propiedad de navegación hacia la entidad DocumentoIdentidad.
    /// </summary>
    public DocumentoIdentidad? DocumentoIdentidad { get; set; }
}