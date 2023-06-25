namespace Iteris.Loja.API.Domain.DTO
{
    public class ProductQueryRequest : PageQueryRequest
    {
        public bool ShowDiscontinuedProducts { get; set; }
    }
}