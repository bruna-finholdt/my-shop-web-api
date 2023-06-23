using System;
using System.Collections.Generic;

namespace Iteris.Loja.API.Domain.Entity;

public partial class Customer
{
    public int Id { get; set; }//PK

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? City { get; set; }

    public string? Country { get; set; }

    public string? Phone { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>(); //cada customer tem uma lista
                                                                                //de orders
}
