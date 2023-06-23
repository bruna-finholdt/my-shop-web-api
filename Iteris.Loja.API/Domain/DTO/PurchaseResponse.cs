using Iteris.Loja.API.Domain.Entity;

namespace Iteris.Loja.API.Domain.DTO
{
    public class PurchaseResponse
    {
        public PurchaseResponse(Order order)
        {
            Id = order.Id;
            OrderDate = order.OrderDate;
            TotalAmount = order.TotalAmount;
        }

        public int Id { get; private set; }
        public DateTime OrderDate { get; private set; }
        public decimal? TotalAmount { get; private set; }
    }
}
