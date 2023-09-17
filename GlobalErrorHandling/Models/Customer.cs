using System;
using System.Collections.Generic;

namespace GlobalErrorHandling.Models;

public partial class Customer
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int? Cid { get; set; }

    public string? Address { get; set; }

    public virtual Country? CidNavigation { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
