using System;
using System.Collections.Generic;

namespace DbLayer.Models;

public partial class Item
{
    public int ItemId { get; set; }

    public string Iname { get; set; } = null!;

    public string Idescription { get; set; } = null!;

    public decimal? Price { get; set; }

    public int? Quantity { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
