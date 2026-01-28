using MediatR;

namespace SistemaBeneficiarios.Domain.Model.Commands;

/// <summary>
/// Comando para crear un Beneficiario con sus datos.
/// </summary>
public record CreateBeneficiarioCommand : IRequest<int>
{
    public string Nombres { get; set; }
    public string Apellidos { get; set; }
    public int DocumentoIdentidadId { get; set; }
    public string NumeroDocumento { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public char Sexo { get; set; }
}