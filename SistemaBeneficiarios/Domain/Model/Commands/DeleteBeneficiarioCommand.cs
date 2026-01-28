using MediatR;

namespace SistemaBeneficiarios.Domain.Model.Commands;

/// <summary>
/// Comando para eliminar a un Beneficiario de la base de datos (a través de su ID)
/// </summary>
public record DeleteBeneficiarioCommand : IRequest<bool>
{
    public int Id { get; set; }

    public DeleteBeneficiarioCommand(int id)
    {
        Id = id;
    }
}