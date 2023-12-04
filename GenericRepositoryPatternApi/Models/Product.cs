using System;
using System.Collections.Generic;

namespace GenericRepositoryPatternApi.Models;

public partial class Product
{
    public int Pid { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public decimal? Price { get; set; }

    public string? Image { get; set; }

    public int? Quantity { get; set; }

    public DateTime CreatedOn { get; set; }

    public int? Cid { get; set; }

    public bool ProductStatus { get; set; }

    public virtual Category? CidNavigation { get; set; }

    public virtual ICollection<TempUserOrder> TempUserOrders { get; set; } = new List<TempUserOrder>();

    public virtual ICollection<UserOrder> UserOrders { get; set; } = new List<UserOrder>();
}
