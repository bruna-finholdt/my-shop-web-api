using System.ComponentModel.DataAnnotations;

namespace Iteris.Loja.API.Domain.DTO
{
    public class PurchaseCreateRequest
    {
        [Required]
        public int CustomerId { get; set; }

        [Required]
        public IEnumerable<PurchaseItem> Itens { get; set; } = null!;
    }
}

