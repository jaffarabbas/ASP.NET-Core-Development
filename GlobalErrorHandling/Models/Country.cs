using System;
using System.Collections.Generic;

namespace GlobalErrorHandling.Models;

public partial class Country
{
    public int Cid { get; set; }

    public string? Cname { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
}
