using System;
using System.Collections.Generic;

namespace GlobalErrorHandling.Models;

public partial class Sale
{
    public int Sid { get; set; }

    public DateTime Sdate { get; set; }

    public int Cid { get; set; }

    public int Iid { get; set; }

    public virtual Customer CidNavigation { get; set; } = null!;

    public virtual Item IidNavigation { get; set; } = null!;
}
