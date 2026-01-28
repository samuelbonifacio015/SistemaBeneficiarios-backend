using MediatR;

namespace SistemaBeneficiarios.Domain.Model.Events;

/// <summary>
/// Evento para determinar cuando un beneficiario fue creado a través de una notificación
/// </summary>
public class BeneficiarioCreatedEvent : INotification
{
    public int BeneficiarioId { get; }
    public DateTime FechaCreacion { get; }

    public BeneficiarioCreatedEvent(int beneficiarioId)
    {
        BeneficiarioId = beneficiarioId;
        FechaCreacion = DateTime.Now;
    }
}