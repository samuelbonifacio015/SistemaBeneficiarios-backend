using MediatR;
using SistemaBeneficiarios.Domain.Model.Aggregates;

namespace SistemaBeneficiarios.Domain.Model.Queries;

/// <summary>
/// Query para retornar beneficiarios por ID
/// </summary>
public record GetBeneficiariosByIdQuery : IRequest<Beneficiario>
{
    public int Id { get; set; }

    public GetBeneficiariosByIdQuery(int id)
    {
        Id = id;
    }
}