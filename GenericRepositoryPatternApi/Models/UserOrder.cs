using System;
using System.Collections.Generic;

namespace GenericRepositoryPatternApi.Models;

public partial class UserOrder
{
    public int Oid { get; set; }

    public int Uid { get; set; }

    public int Pid { get; set; }

    public int Quantity { get; set; }

    public decimal TotalPrice { get; set; }

    public bool Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Product PidNavigation { get; set; } = null!;

    public virtual User UidNavigation { get; set; } = null!;
}
