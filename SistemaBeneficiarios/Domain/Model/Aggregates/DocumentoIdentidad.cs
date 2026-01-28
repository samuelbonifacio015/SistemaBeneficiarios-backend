namespace SistemaBeneficiarios.Domain.Model.Aggregates;

/// <summary>
/// Clase que representa el Documento de Identidad de un Beneficiario
/// </summary>
public partial class DocumentoIdentidad
{
    public int Id { get; set; }

    /// <summary>
    /// Nombre completo del documento
    /// </summary>
    public string Nombre { get; set; } = string.Empty;

    /// <summary>
    /// Abreviatura del documento (ej. CC, TI).
    /// </summary>
    public string Abreviatura { get; set; } = string.Empty;

    /// <summary>
    /// País de origen del documento.
    /// </summary>
    public string Pais { get; set; } = string.Empty;

    /// <summary>
    /// Longitud requerida para el número de documento.
    /// </summary>
    public int Longitud { get; set; }

    /// <summary>
    /// Indica si el documento solo debe contener números.
    /// </summary>
    public bool SoloNumeros { get; set; }

    /// <summary>
    /// Indica si el tipo de documento está activo en el sistema.
    /// </summary>
    public bool Activo { get; set; }
}