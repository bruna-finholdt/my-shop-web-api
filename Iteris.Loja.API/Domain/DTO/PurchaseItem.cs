using System.ComponentModel.DataAnnotations;

namespace Iteris.Loja.API.Domain.DTO
{
    public class PurchaseItem
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public float? Discount { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}