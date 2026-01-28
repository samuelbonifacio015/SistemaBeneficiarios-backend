namespace SistemaBeneficiarios.Interfaces.REST.Resources;

/// <summary>
/// Recurso que expone la información de un Tipo de Documento de Identidad.
/// </summary>
/// <param name="Id">ID del tipo de documento.</param>
/// <param name="Nombre">Nombre descriptivo.</param>
/// <param name="Abreviatura">Abreviatura común.</param>
/// <param name="Longitud">Longitud requerida para este tipo de documento.</param>
/// <param name="SoloNumeros">Indicador si solo permite dígitos numéricos.</param>
public record DocumentoIdentidadResource(
    int Id,
    string Nombre,
    string Abreviatura,
    int Longitud,
    bool SoloNumeros
);