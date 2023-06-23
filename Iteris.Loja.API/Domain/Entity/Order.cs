using System;
using System.Collections.Generic;

namespace Iteris.Loja.API.Domain.Entity;

public partial class Order
{
    public int Id { get; set; } //PK

    public DateTime OrderDate { get; set; }

    public string? OrderNumber { get; set; }

    public int CustomerId { get; set; } //FK para link com a entity Customer

    public decimal? TotalAmount { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    //cada order tem uma lista de orderItems (products)
}
