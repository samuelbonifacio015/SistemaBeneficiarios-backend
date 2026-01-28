namespace SistemaBeneficiarios.Interfaces.REST.Resources;

public record DocumentoIdentidadResource(
    int Id,
    string Nombre,
    string Abreviatura,
    int Longitud,
    bool SoloNumeros
);