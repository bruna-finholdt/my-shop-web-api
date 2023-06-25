using Iteris.Loja.API.Domain.Entity;

namespace Iteris.Loja.API.Domain.DTO
{
    public class ProductResponse
    {
        public ProductResponse(Product product)
        {
            Id = product.Id;
            ProductName = product.ProductName;
            UnitPrice = product.UnitPrice;
            IsDiscontinued = product.IsDiscontinued;
        }
        public int Id { get; private set; }
        public string ProductName { get; private set; }
        public decimal? UnitPrice { get; private set; }
        public bool IsDiscontinued { get; private set; }
    }
}
