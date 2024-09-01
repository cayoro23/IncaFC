using IncaFc.Domain.Cancellation.ValueObjects;
using IncaFc.Domain.Common.Models;
using IncaFc.Domain.Sale.ValueObjects;

namespace IncaFc.Domain.Cancellation;

public sealed class Cancellation : AggregateRoot<CancellationId>
{
    public string Reason { get; }
    public SaleId SaleId { get; }
    public DateTime CreatedDateTime { get; set; }

    private Cancellation(
        CancellationId cancellationId,
        string reason,
        SaleId saleId,
        DateTime createdDateTime)
        : base(cancellationId)
    {
        Reason = reason;
        SaleId = saleId;
        CreatedDateTime = createdDateTime;
    }

    public static Cancellation Create(
        string reason,
        SaleId saleId,
        DateTime createdDateTime)
    {
        return new Cancellation(
            CancellationId.CreateUnique(),
            reason,
            saleId,
            DateTime.UtcNow
        );
    }
}