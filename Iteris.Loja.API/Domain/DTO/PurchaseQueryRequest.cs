namespace Iteris.Loja.API.Domain.DTO
{
    public class PurchaseQueryRequest : PageQueryRequest
    {
        public decimal? MinimumPriceValue { get; set; }
    }
}


