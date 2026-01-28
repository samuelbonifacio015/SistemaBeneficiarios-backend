using MediatR;
using SistemaBeneficiarios.Domain.Model.Aggregates;

namespace SistemaBeneficiarios.Domain.Model.Queries;

/// <summary>
/// Query para retornar la lista completa de Beneficiarios 
/// </summary>
public record GetBeneficiariosQuery : IRequest<IEnumerable<Beneficiario>> {}