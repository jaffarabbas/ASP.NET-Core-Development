using System;
using System.Collections.Generic;

namespace GenericRepositoryPatternApi.Models;

public partial class TempUserOrder
{
    public int Id { get; set; }

    public string UserToken { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Address { get; set; } = null!;

    public int Pid { get; set; }

    public int Quantity { get; set; }

    public decimal TotalPrice { get; set; }

    public bool TmStatus { get; set; }

    public DateTime Orderat { get; set; }

    public virtual Product PidNavigation { get; set; } = null!;
}
