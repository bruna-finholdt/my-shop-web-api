using System;
using System.Collections.Generic;

namespace Iteris.Loja.API.Domain.Entity;

public partial class OrderItem //orderItem e product não seria a msm coisa?...pq tem um Id pra orderItem e 
                               //tb um productId
{
    public int Id { get; set; } //PK

    public int OrderId { get; set; } //FK para link com a entity Order

    public int ProductId { get; set; }

    public decimal UnitPrice { get; set; }

    public int Quantity { get; set; }

    public virtual Order Order { get; set; } = null!;//Order é o pedido que pode ter + de 1 orderItem/product
                                                     //e trouxe esse orderItem/product especifico

    public virtual Product Product { get; set; } = null!;//aqui é o orderItem/produto especifico
}
