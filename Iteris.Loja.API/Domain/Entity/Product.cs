using System;
using System.Collections.Generic;

namespace Iteris.Loja.API.Domain.Entity;

public partial class Product
{
    public int Id { get; set; }//PK

    public string ProductName { get; set; } = null!;

    public int SupplierId { get; set; }//FK para link com entity Supplier

    public decimal? UnitPrice { get; set; }

    public string? Package { get; set; }

    public bool IsDiscontinued { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual Supplier Supplier { get; set; } = null!;
}
