using MediatR;

namespace SistemaBeneficiarios.Domain.Model.Commands;

/// <summary>
/// Comando para actualizar los datos de un Beneficiario.
/// </summary>
public record UpdateBeneficiarioCommand : IRequest<bool>
{
    public int Id { get; set; }
    public string Nombres { get; set; }
    public string Apellidos { get; set; }
    public int DocumentoIdentidadId { get; set; }
    public string NumeroDocumento { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public char Sexo { get; set; }
}